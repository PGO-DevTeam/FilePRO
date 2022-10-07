using FilePro.Models.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilePro.Models.Trans
{

    [Table("T_DokumenTimesheet")]
    public class DokumenTimesheet : BaseModel
    {
        public int Id { get; set; }
        public DateTime Periode { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public Users User { get; set; }
        public string UserId { get; set; }
        public KategoriDokumen KategoriDokumen { get; set; }
        public int KategoriDokumenId { get; set; }
        public string? Path { get; set; }
    }
}
