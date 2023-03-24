using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_library.Models
{
    public class computer
    {
        [Key]
        public int Id { get; set; } 
        public string name{ get; set; }
        [ForeignKey("Media")]
        public int mediaId { get; set; }
        public Media media { get; set; }
       
    }
}
