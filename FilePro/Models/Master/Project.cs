using System.ComponentModel.DataAnnotations.Schema;

namespace FilePro.Models.Master
{

    [Table("M_Project")]
    public class Project
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public Users PIC1 { get; set; }
        public string PIC1Id { get; set; }
        public Users PIC2 { get; set; }
        public string? PIC2Id { get; set; }
        public string Alamat { get; set; }
    }
}
