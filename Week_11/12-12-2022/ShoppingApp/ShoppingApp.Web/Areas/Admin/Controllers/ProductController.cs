using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Core;
using ShoppingApp.Entity.Concrete;
using ShoppingApp.Web.Areas.Admin.Models.Dtos;
using System;

namespace ShoppingApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsWithCategories();
            var productListDto = products
                .Select(p => new ProductListDto
                {
                    Product = p
                }).ToList();
     
            return View(productListDto);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            var productAddDto = new ProductAddDto
            {
                Categories = categories
            };
            return View(productAddDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductAddDto productAddDto)
        {
           if(ModelState.IsValid)
            {
                var url = Jobs.InitUrl(productAddDto.Name);
                var product = new Product
                {
                    Name = productAddDto.Name,
                    Price = productAddDto.Price,
                    Description = productAddDto.Description,
                    Url = url,
                    IsApproved = productAddDto.IsApproved,
                    IsHome = productAddDto.IsHome,
                    ImageUrl = Jobs.UploadImage(productAddDto.ImageFile)// şimdi image upload etmek için kod yazmaya gidiyoruz
                    //bizim yeni ürün eklede resim eklediğimiz zaman  dosya yolunu alamıyoruz bunun için Core içindeki jobs da  metot tanımlıyoruz o yolu kullnarak burada kullanıcaz
                };
                await _productService.CreateProductAsyn(product, productAddDto.SelectedCategoryIds); // product ve  CreateProductAsyn metodumuza  productAddDto daki  SelectedCategoryIds propu yolluyoruz
                return RedirectToAction("Index");

            }
            // üstteki if bloğu çalışmazsa boş bir form elemanı vardır ve hata veriri bizde o form sayfasına önceden yazılan verileri view le buraya gelen  productAddDto gönderiyoruz ve seçili kategorileri de gönderiyoruz. bunun için creat formunda seçili olan kategorilerine koşul koyucaz
            var categories = await _categoryService.GetAllAsync();
            productAddDto.Categories=categories;
            return View(productAddDto);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await _categoryService.GetAllAsync();
            var product = await _productService.GetProductWithCategories(id);
            var url = Jobs.InitUrl(product.Name);

            ProductUpdateDto productUpdateDto = new ProductUpdateDto
            {

                Id= product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Url = url,
                IsApproved = product.IsApproved,
                IsHome = product.IsHome,
                ImageUrl=product.ImageUrl,
                Categories = categories,
                SelectedCategoryIds=product.ProductCategories.Select(pc=>pc.CategoryId).ToArray()
                // üstteki satır bizim productUpdateDto da seçili olarak tutacağımız category id leri yerine product ile category id si ortak olan  ProductCategories tablosundan verileri çektik
            };
            
            return View(productUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductUpdateDto productUpdateDto, int[]selectedCategoryIds)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.GetByIdAsync(productUpdateDto.Id);
                if (product == null)
                {
                    return NotFound();
                }
                var url = Jobs.InitUrl(product.Name);

                product.Name = productUpdateDto.Name;
                product.Price = productUpdateDto.Price;
                product.Description = productUpdateDto.Description;
                productUpdateDto.Url = Jobs.InitUrl(productUpdateDto.Name);
                product.IsApproved=productUpdateDto.IsApproved;
                product.IsHome = productUpdateDto.IsHome;
                product.ImageUrl = Jobs.UploadImage(productUpdateDto.ImageFile);
                product.Url = url;
                await _productService.UpdateProductAsync(product, selectedCategoryIds);
               


                _productService.Update(product);
                return RedirectToAction("Index");
               


            }
            var categories = await _categoryService.GetAllAsync();
            productUpdateDto.Categories = categories;
            return View(productUpdateDto);
        }
    }
}
