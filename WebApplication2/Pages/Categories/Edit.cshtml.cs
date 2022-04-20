using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(long Id)
        {
            Category = _db.Category.Find(Id);
        }

        public async Task<IActionResult> OnpostAsync()
        {

            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("DisplayOrder", "Display Order must be a number");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Category.Update(Category);
            await _db.SaveChangesAsync();

            TempData["Message"] = $"{Category.Name} has been updated";

            return RedirectToPage("Category");
        }

    }
}
