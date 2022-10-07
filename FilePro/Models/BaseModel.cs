namespace FilePro.Models
{
    public class BaseModel
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEdited { get; set; }

    }
}
