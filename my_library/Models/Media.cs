using System.ComponentModel.DataAnnotations;

namespace my_library.Models
{
    public class Media
    {
        [Key]
        public int media_id { get; set; }
        public int location_floor { get; set; }
        public int location_asile { get; set; }
    }
}
