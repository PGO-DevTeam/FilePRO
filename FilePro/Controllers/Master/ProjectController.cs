using FilePro.Data;
using FilePro.Models.Master;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilePro.Controllers.Master
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Users> _userManager;
        public ProjectController(AppDbContext context, UserManager<Users> userManager)
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
                var result = _context.Projects.ToList();
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
                var result = _context.Projects.Where(x=>x.Id == id).FirstOrDefault();
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
                var result = _context.Projects.Where(x => x.Id == id).FirstOrDefault();
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
        public IActionResult Submit(Project project)
        {
            try
            {
                if (project.Id == 0)
                {
                    _context.Projects.Add(project);
                }
                else
                {
                    var data = _context.Projects.Include(x => x.PIC2).Include(x => x.PIC1).Where(x => x.Id == project.Id).FirstOrDefault();
                    data.Nama = project.Nama;
                    data.PIC1Id = project.PIC1Id;
                    data.PIC2Id = project.PIC2Id;
                    data.Alamat = project.Alamat;
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Ok(project);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
