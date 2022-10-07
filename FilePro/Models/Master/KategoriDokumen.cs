using System.ComponentModel.DataAnnotations.Schema;

namespace FilePro.Models.Master
{

    [Table("M_KategoriDokumen")]
    public class KategoriDokumen : BaseModel
    {
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
