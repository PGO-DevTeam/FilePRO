using System.ComponentModel.DataAnnotations.Schema;

namespace FilePro.Models.Master
{

    [Table("M_Vendor")]
    public class Vendor : BaseModel
    {
        public int Id { get; set; }
        public string NamaVendor { get; set; }
    }
}
