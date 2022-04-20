using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category Category { get; set; }
        public void OnGet(long Id)
        {
            Category = _db.Category.Where(p => p.Id == Id).FirstOrDefault();
        }

        public async Task<IActionResult> OnpostAsync()
        {
            var CategoryFind = _db.Category.Where(p => p.Id == Category.Id).FirstOrDefault();
            if (CategoryFind != null)
            {
                _db.Category.Remove(CategoryFind);
                await _db.SaveChangesAsync();

                TempData["Message"] = "Category deleted successfully";

                return RedirectToPage("Category");
            }

            return Page();
        }

    }
}
