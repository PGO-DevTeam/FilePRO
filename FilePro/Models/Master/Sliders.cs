using System.ComponentModel.DataAnnotations.Schema;

namespace FilePro.Models.Master
{

    [Table("M_Sliders")]
    public class Sliders : BaseModel
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Path { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }

    }
}
