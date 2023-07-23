using Fast_Food_online.Data;
using Fast_Food_online.Models;
using Microsoft.EntityFrameworkCore;

namespace Fast_Food_online.Services
{
    public class CategoryService : IProductService<Category>
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Category model)
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
                context.Categories.Remove(item);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Category> GetValueAsync(int id)
        {
            return await context.Categories.FindAsync(id);

        }

        public async Task<List<Category>> GetValuesAsync()
        {
            var result = await context.Categories.OrderBy(P => P.Name).ToListAsync();
            return result;
        }

        public async Task UpdateAsync(Category model)
        {
            context.Entry(model).State = EntityState.Modified;
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
