using Fast_Food_online.Models;
using Fast_Food_online.Services;
using Fast_Food_online.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fast_Food_online.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService<Product> productService;
        private readonly IProductService<Category> cateService;
        private readonly IWebHostEnvironment webHost;

        public ProductController(IProductService<Product> productService,IProductService<Category> cateService,IWebHostEnvironment webHost )
        {
            this.productService = productService;
            this.cateService = cateService;
            this.webHost = webHost;
        }
        // GET: ProductController

        public async Task<IActionResult> Index()
        {
            
            var items=await productService.GetValuesAsync();
            var VMS = new List<ProductVM>();
            if (items != null)
            {
                foreach (var item in items)
                {
                    var cate =  productService.GetValueAsync(item.Id).Result.category;
                    var VM = new ProductVM()
                    {
                        ProductId=item.Id,
                        category=cate,
                        Name=item.Name,
                        Description=item.Description,
                        Price=item.Price,
                        ImageURl=item.ImageUrl,
                        CatId=cate.Id,

                    };
                    VMS.Add(VM);
                }
                return View(VMS);

            }
            return Problem("Entity set 'ApplicationDbContext.Cinemas'  is null.");
        }
        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (await productService.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var product = await productService.GetValueAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // GET: ProductController/Create
        public async Task< ActionResult> Create()
        {
            var cates = await cateService.GetValuesAsync();
            var VM = new ProductVM()
            {
                Categories=cates
            };
            return View(VM);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                string ImageName = string.Empty;
                if (model.Image!=null)
                {
                    string uploads = Path.Combine(webHost.WebRootPath, "Uploads");
                    ImageName = model.Image.FileName;
                    string fullpath = Path.Combine(uploads, ImageName);
                    model.Image.CopyTo(new FileStream(fullpath, FileMode.Create));
                }
                var cate = await cateService.GetValueAsync(model.CatId);
                var prod = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    category = cate,
                    ImageUrl = ImageName
                };
                await productService.AddAsync(prod);
                return RedirectToAction(nameof(Index));

            }
            return View(model);


        }

        // GET: ProductController/Edit/5
        public async Task< ActionResult> Edit(int id)
        {
            var cates = await cateService.GetValuesAsync();
            var oldprod = await productService.GetValueAsync(id);
            var VM = new ProductVM()
            {
                ProductId=oldprod.Id,
                Name=oldprod.Name,
                Price=oldprod.Price,
                ImageURl=oldprod.ImageUrl,
                Description=oldprod.Description,
                CatId=oldprod.category.Id,
                Categories = cates
            };
            return View(VM);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Edit( ProductVM model)
        {
            if (ModelState.IsValid)
            {
                string ImageName = string.Empty;
                if (model.Image != null)
                {
                    string uploads = Path.Combine(webHost.WebRootPath, "Uploads");
                    ImageName = model.Image.FileName;
                    string fullpath = Path.Combine(uploads, ImageName);
                    string oldImageName =  productService.GetValueAsync(model.ProductId).Result.ImageUrl;
                    string oldfullpath = Path.Combine(uploads, oldImageName);
                    if (fullpath!=oldfullpath)
                    {
                        System.IO.File.Delete(oldfullpath);
                        model.Image.CopyTo(new FileStream(fullpath, FileMode.Create));

                    }

                }
                var cate = await cateService.GetValueAsync(model.CatId);
                var prod = new Product()
                {
                    Id=model.ProductId,
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    category = cate,
                    ImageUrl = ImageName
                };
                await productService.UpdateAsync(prod);
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }

        // GET: ProductController/Delete/5
        public async Task< ActionResult> Delete(int id)
        {
            if (await productService.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var product = await productService.GetValueAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> DeleteConfirmed( int Id)
        {
            if (await productService.GetValuesAsync() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cinemas'  is null.");
            }
            var prod = await productService.GetValueAsync(Id);
            if (prod != null)
            {
                await productService.DeleteAsync(Id);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
