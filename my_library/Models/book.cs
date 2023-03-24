using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_library.Models
{
    public class book
    {
        [Key]

        public int book_id { get; set; }
        public string title { get; set; }
        [ForeignKey("Media")]
        public int mediaId { get; set; }
        public Media media { get; set; }
        
    }
}
