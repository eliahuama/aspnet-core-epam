using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.Entities;

namespace Northwind.Models {
    public class CategoriesModel : PageModel {
        public ICollection<Category> Categories { get; set; }
    }
}