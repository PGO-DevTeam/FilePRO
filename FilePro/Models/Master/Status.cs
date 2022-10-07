using System.ComponentModel.DataAnnotations.Schema;

namespace FilePro.Models.Master
{

    [Table("M_Status")]
    public class Status
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string? warna { get; set; }
        public string? icon { get; set; }
    }
}
