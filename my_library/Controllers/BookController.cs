using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_library.Data;
using my_library.Models;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Microsoft.Extensions.Logging;
using my_library.ViewModels;
using System.Reflection.Metadata.Ecma335;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace my_library.Controllers
{
    public class BookController : Controller
    {
       
        public BookController()
        {

        }
        public async Task<IActionResult> BookIndex()
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder("Host=127.0.0.1;Server=localhost;Port=5432;Database=myWorker;UserID=postgres;Password=killer89;Pooling=true");

            await using var dataSource = dataSourceBuilder.Build();
            await using var command = dataSource.CreateCommand("SELECT * FROM books");
            await using var reader = await command.ExecuteReaderAsync();

            var bookList = new BookViewModel();
            var localList = new List<book>();
            while (await reader.ReadAsync())
            {
                localList.Add(new book()
                {
                    book_id = (int)reader["book_id"],
                    title = reader[1] as string,
                    mediaId = (int)reader["book_id"]
                });
                  
                  


              
            }
            bookList.allBooks = localList;
            return View(bookList);
        }
        public IActionResult BookForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePage(CreateBookViewModel newBook)
        {
            var book = new CreateBookViewModel();
            if (!ModelState.IsValid)
            {
                book.title = "fake";
            }
            else
            {
                book.title = newBook.title;
                
                await using var conn = new NpgsqlConnection("Host=127.0.0.1;Server=localhost;Port=5432;Database=myWorker;UserID=postgres;Password=killer89;Pooling=true");

                await conn.OpenAsync();
                await using var cmd = new NpgsqlCommand("WITH local_id AS (INSERT INTO media VALUES (DEFAULT, 1, 1) RETURNING media_id) INSERT INTO books VALUES((SELECT media_id from local_id), (@p1), (SELECT media_id from local_id))",conn)
                {
                    Parameters =
                    {
                        new("p1", book.title),
                        
                    }
                };
                await using var reader = await cmd.ExecuteReaderAsync();



            }

            return View(book);

        }


    }

        
    
}
