using Fast_Food_online.Data;
using Fast_Food_online.Models;
using Microsoft.EntityFrameworkCore;

namespace Fast_Food_online.Services
{
    public class ProductService : IProductService<Product>
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Product model)
        {
            await context.AddAsync(model);
            try
            {
                 await context.SaveChangesAsync();
                 
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetValueAsync(id);
            try
            {
                context.Products.Remove(item);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> GetValueAsync(int id)
        {
            return await  context.Products.Include(p=>p.category).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<List<Product>> GetValuesAsync()
        {
            var result = await context.Products.OrderBy(P => P.Name).ToListAsync();
            return result;
        }

        public async Task UpdateAsync(Product model)
        {
            ////context.Products.Entry(model).State = EntityState.Modified;
            var prod = await context.Products.FindAsync(model.Id);
            prod.Name = model.Name;
            prod.Description = model.Description;
            prod.Price = model.Price;
            prod.category = model.category;
            prod.ImageUrl = model.ImageUrl;

              
            try
            {
                await context.SaveChangesAsync();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
