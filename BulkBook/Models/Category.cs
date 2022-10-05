using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        //https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel?view=net-6.0
        [DisplayName("Display Order")] // This makes it so that instead of DisplayOrder being shown, it will be Display Order instead.. adding a space in between
        [Range(1,100,ErrorMessage ="Display Order must be between 1 and 100")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
