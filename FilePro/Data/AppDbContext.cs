using FilePro.Models.Master;
using FilePro.Models.Trans;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FilePro.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<KategoriDokumen> KategoriDokumens { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Sliders> Slider { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<DokumenProject> DokumenProjects { get; set; }
        public DbSet<DokumenTimesheet> DokumenTimesheets { get; set; }


    }
}
