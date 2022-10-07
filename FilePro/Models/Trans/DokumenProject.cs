using FilePro.Models.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilePro.Models.Trans
{

    [Table("T_DokumenProject")]
    public class DokumenProject : BaseModel
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public KategoriDokumen KategoriDokumen { get; set; }
        public int KategoriDokumenId { get; set; }
        public string? Path { get; set; }
        public string? Versi { get; set; }
        public Users Creater { get; set; }
        public string CreaterId { get; set; }
    }
}
