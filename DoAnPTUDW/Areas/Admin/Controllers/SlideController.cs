using DoAnPTUDW.Models;
using DoAnPTUDW.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoAnPTUDW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlideController : Controller
    {
        private readonly DataContext _context;
        public SlideController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");

            var mnList = _context.Slides.OrderBy(m => m.SlideID).ToList();
            return View(mnList);
        }
        public IActionResult Create()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");

            var SlideList = (from m in _context.Slides
                            select new SelectListItem()
                            {
                                Text = m.Title,
                                Value = m.SlideID.ToString(),
                            }).ToList();
            SlideList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.SlideList = SlideList;
            return View();
        }
        [HttpPost]

        public IActionResult Create(Slide slide)
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");

            if (ModelState.IsValid)
            {
                _context.Add(slide);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(long? id)
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var slide = _context.Slides.Find(id);
            if (slide == null)
            {
                return NotFound();
            }
            var slideList = (from m in _context.Slides
                            select new SelectListItem()
                            {
                                Text = m.Title,
                                Value = m.SlideID.ToString(),
                            }).ToList();
            slideList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.slideList = slideList;
            return View(slide);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Slide slide)
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");

            if (ModelState.IsValid)
            {
                _context.Slides.Update(slide);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slide);
        }

    }
}
