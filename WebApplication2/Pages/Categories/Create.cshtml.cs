using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnpostAsync()
        {
 
            //if (Category.Name == Category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("DisplayOrder", "Display Order must be a number");
            //}

            if (!ModelState.IsValid)
            {
                return Page();
            }
            

            await _db.Category.AddAsync(Category);
            await _db.SaveChangesAsync();

            TempData["Message"] = $"{Category.Name} has been saved";

            return RedirectToPage("Category");
        }

    }
}
