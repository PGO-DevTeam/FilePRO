using Microsoft.AspNetCore.Identity;

namespace FilePro.Models.Master
{
    public class Users :IdentityUser
    {
        public string Nama { get; set; }
        public string NoPeg { get; set; }
        public string Contact { get; set; }
        public string ProfilePicPath { get; set; }
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
        public DateTime? TanggalJoin { get; set; }
        public bool IsDeleted { get; set; }
    }
}
