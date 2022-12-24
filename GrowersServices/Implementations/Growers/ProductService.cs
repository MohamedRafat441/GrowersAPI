using GrowersDomain.Models.Growers;
using GrowersServices.Interfaces.Growers;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowersServices.Implementations.Growers
{
    public class ProductService : IProductsService
    {
        private readonly IGenericRepository _repository;

        public ProductService(IGenericRepository repository)
        {
            _repository = repository;

        }
        public async Task<List<Product>> GetAll()
        {
            var res = await _repository.All<Product>().Where(s => !s.IsDeleted).ToListAsync();
            return res;
        }
        public async Task<List<Product>> GetAll(int growerId)
        {
            var res = await _repository.All<Product>().Where(s => s.GrowerId== growerId && !s.IsDeleted).ToListAsync();
            return res;
        }
        public async Task<Product> GetById(int id)
        {
            var res = await _repository.All<Product>().FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            return res;
        }
        public async Task<bool> Add(Product entity)
        {
            _repository.Add<Product>(entity);
            var res = await _repository.SaveChangesAsync();
            return res;
        }

        public async Task<bool> Edit(Product entity)
        {
            _repository.Update<Product>(entity);
            var res = await _repository.SaveChangesAsync();
            return res;
        }
        public async Task<bool> Remove(int id)
        {
            var obj = await _repository.Find<Product>(s => s.Id == id).FirstOrDefaultAsync();
            obj.IsDeleted = true;
            var res = await _repository.SaveChangesAsync();
            return res;
        }

    }
}
