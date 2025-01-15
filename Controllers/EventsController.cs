using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class EventsController : Controller
    {
        private readonly DBContext _context;

        public EventsController(DBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (_context.Etkinlikler == null)
            {
                return NotFound();
            }
            var etkinlikler = _context.Etkinlikler.ToList();
            return View(etkinlikler);
        }

        public IActionResult Details(int id)
        {
            if (_context.Etkinlikler == null)
            {
                return NotFound();
            }
            var etkinlik = _context.Etkinlikler.FirstOrDefault(e => e.ID == id);
            if (etkinlik == null)
            {
                return NotFound();
            }
            return View(etkinlik);
        }

        public IActionResult Create()
        {
            var topluluklar = _context.Topluluklar
                .Where(t => t.Onayli)
                .OrderBy(t => t.Isim)
                .Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(),
                    Text = t.Isim
                })
                .ToList();

            ViewBag.Topluluklar = topluluklar;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Etkinlik etkinlik)
        {
            if (ModelState.IsValid)
            {
                if (_context.Etkinlikler == null)
                {
                    return Problem("Entity set 'DBContext.Etkinlikler' is null.");
                }
                _context.Etkinlikler.Add(etkinlik);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            var topluluklar = _context.Topluluklar
                .Where(t => t.Onayli)
                .OrderBy(t => t.Isim)
                .Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(),
                    Text = t.Isim
                })
                .ToList();

            ViewBag.Topluluklar = topluluklar;
            return View(etkinlik);
        }

        public IActionResult BiletAl(int id)
        {
            var etkinlik = _context.Etkinlikler.FirstOrDefault(e => e.ID == id);

            if (etkinlik == null)
            {
                return NotFound();
            }

            // Burada bilet alma işlemleri yapılacak
            // Örneğin: Kullanıcı bilgileri alınacak, ödeme işlemi yapılacak vs.

            TempData["Message"] = "Bilet alma işleminiz başarıyla tamamlandı!";
            return RedirectToAction(nameof(Details), new { id = etkinlik.ID });
        }
    }
} 