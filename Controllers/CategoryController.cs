using Fast_Food_online.Models;
using Fast_Food_online.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fast_Food_online.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService<Category> cateservice;

        public CategoryController(IProductService<Category> cateservice)
        {
            this.cateservice = cateservice;
        }
        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            return await cateservice.GetValuesAsync() != null ?
                          View(await cateservice.GetValuesAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
        }

        // GET: CategoryController/Details/5
        public async Task< ActionResult> Details(int id)
        {
            if (await cateservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var Cat = await cateservice.GetValueAsync(id);

            if (Cat == null)
            {
                return NotFound();
            }

            return View(Cat);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create([Bind("Name","Description")]Category model)
        {
           
                if (ModelState.IsValid)
                {
                    await cateservice.AddAsync(model);
                    return RedirectToAction(nameof(Index));

                }
                return View(model);
                
           
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (await cateservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var cinema = await cateservice.GetValueAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }
            return View(cinema);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Edit(Category model)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    await cateservice.UpdateAsync( model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await cateservice.GetValueAsync(model.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: CategoryController/Delete/5
        public async Task< ActionResult> Delete(int id)
        {
            if (await cateservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var cinema = await cateservice.GetValueAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }

            return View(cinema);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> DeleteConfirmed(int id)
        {
            if (await cateservice.GetValuesAsync() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cinemas'  is null.");
            }
            var cinema = await cateservice.GetValueAsync(id);
            if (cinema != null)
            {
                await cateservice.DeleteAsync(id);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
