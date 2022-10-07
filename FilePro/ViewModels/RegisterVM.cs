namespace FilePro.ViewModels
{
    public class RegisterVM
    {
        public string Id { get; set; }
        public string NoPeg { get; set; }
        public string Nama { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
        public int VendorId { get; set; }
        public DateTime TanggalJoin { get; set; }
        public IFormFile File { get; set; }
    }
}
