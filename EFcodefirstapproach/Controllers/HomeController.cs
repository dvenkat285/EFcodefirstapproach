using EFcodefirstapproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EFcodefirstapproach.Controllers
{
    public class HomeController : Controller
    {


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly MtrDBContext dtrDB;
        public HomeController(MtrDBContext DtrDB)
        {
            this.dtrDB = DtrDB;
        }
        public async Task<IActionResult> Index()
        {
            var dtrdb = await dtrDB.Dtrs.ToListAsync();
            return View(dtrdb);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Dtr dt)
        {
            if (ModelState.IsValid) 
            {
                await dtrDB.Dtrs.AddAsync(dt);
                await dtrDB.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(dt);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || dtrDB.Dtrs == null) 
            {
                return NotFound();
            }
            var dtrdb = await dtrDB.Dtrs.FirstOrDefaultAsync(x => x.MtId == id);

            if (dtrdb == null) 
            {
                return NotFound();

            }
            return View(dtrdb);
        }

        public async Task< IActionResult> Edit(int? id)
        {
            if (id == null || dtrDB.Dtrs == null)
            {
                return NotFound();
            }
            var dtrdb = await dtrDB.Dtrs.FindAsync(id);

            if (dtrdb == null)
            {
                return NotFound();

            }
            return View(dtrdb);
        }

        [HttpPost]
        public async Task< IActionResult> Edit(int? id, Dtr dt)
        {
            if(id != dt.MtId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                dtrDB.Dtrs.Update(dt);
                await dtrDB.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(dt);
        }

        public async Task< IActionResult> Delete(int? id)
        {
            if (id == null || dtrDB.Dtrs == null)
            {
                return NotFound();
            }
            var dtrdb = await dtrDB.Dtrs.FirstOrDefaultAsync(x => x.MtId == id);
            if (dtrdb == null)
            {
                return NotFound();

            }

            return View(dtrdb);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var dtrdb = await dtrDB.Dtrs.FindAsync(id);
            if(dtrdb != null)
            {
                dtrDB.Dtrs.Remove(dtrdb);
            }
            await dtrDB.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
