using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Add-Migration remark
// Update-Database

//https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-6.0

namespace WebApplication2.Model
{
    [Table("Category", Schema = "dev03")]
    public class Category
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(50), Display(Name = "CateName")]
        public string Name { get; set; }

        [Display(Name = "Display Order"), Range(1, 100, ErrorMessage = "Display order must be in range of 1-100!!!")]
        public int DisplayOrder { get; set; }

    }

}