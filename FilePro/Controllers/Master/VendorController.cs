using FilePro.Data;
using FilePro.Models.Master;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilePro.Controllers.Master
{
    public class VendorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Users> _userManager;
        public VendorController(AppDbContext context, UserManager<Users> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            try
            {
                var result = _context.Vendors.ToList();
                return Ok(new { data = result });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        public IActionResult Get(int id)
        {
            try
            {
                var result = _context.Vendors.Where(x => x.Id == id).FirstOrDefault();
                return Ok(new { data = result });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _context.Vendors.Where(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    _context.Remove(result);
                    _context.SaveChanges();
                }
                return Ok("Berhasil Dihapus");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Submit(Vendor vendor)
        {
            try
            {
                if (vendor.Id == 0)
                {
                    _context.Vendors.Add(vendor);
                }
                else
                {
                    var data = _context.Projects.Include(x => x.PIC2).Include(x => x.PIC1).Where(x => x.Id == vendor.Id).FirstOrDefault();
                    data.Nama = vendor.NamaVendor;
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Ok(vendor);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
