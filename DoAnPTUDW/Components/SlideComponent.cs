using DoAnPTUDW.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnPTUDW.Components
{
    [ViewComponent(Name = "Slide")]
    public class SlideComponent : ViewComponent
    {
        private readonly DataContext _context;
        public SlideComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofSlide = (from p in _context.Slides
                               //where (p.IsActive == true) && (p.Status == 1)
                               orderby p.SlideID descending
                              select p).Take(4).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofSlide));
        }
    }
}
