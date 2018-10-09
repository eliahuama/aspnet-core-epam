using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Entities;
using Northwind.Services.Interfaces;

namespace Northwind.Pages.Products {
    public class EditProductModel : PageModel {
        private IProductService _productService { get; set; }
        private ICategoryService _categoryService { get; set; }
        private ISupplierService _supplierService { get; set; }
        private IMapper _mapper { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public ICollection<Category> Categories { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }

        public EditProductModel (
            IProductService productService,
            ICategoryService categoryService,
            ISupplierService supplierService,
            IMapper mapper
        ) {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
            _mapper = mapper;
        }

        public IActionResult OnGet (int id) {
            if (id.Equals (-1) || id.Equals (0)) {
                return RedirectToProductList ();
            }

            Product = _productService.GetAll ().FirstOrDefault (x => x.ProductId.Equals (id));

            if (Product == null) {
                return RedirectToProductList ();
            }

            Categories = _categoryService.GetAll().ToList();
            Suppliers = _supplierService.GetAll().ToList();

            return Page ();
        }

        public IActionResult OnPost () {
            if (ModelState.IsValid) {
                _productService.Update (_mapper.Map<Product> (Product));
                _productService.SaveChanges ();
                return RedirectToAction ("Index", "Home");
            }
    
            return Page();
        }

        private IActionResult RedirectToProductList () {
            return RedirectToAction ("Index", "Products");
        }
    }
}