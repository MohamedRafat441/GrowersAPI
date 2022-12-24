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
    public class Categoryervice : ICategoryService
    {
        private readonly IGenericRepository _repository;

        public Categoryervice(IGenericRepository repository)
        {
            _repository = repository;

        }
        public async Task<List<Category>> GetAll()
        {
            var res = await _repository.All<Category>().Where(s => !s.IsDeleted).ToListAsync();
            return res;
        }
     
        public async Task<Category> GetById(int id)
        {
            var res = await _repository.All<Category>().FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            return res;
        }
        public async Task<bool> Add(Category entity)
        {
            _repository.Add<Category>(entity);
            var res = await _repository.SaveChangesAsync();
            return res;
        }

        public async Task<bool> Edit(Category entity)
        {
            _repository.Update<Category>(entity);
            var res = await _repository.SaveChangesAsync();
            return res;
        }
        public async Task<bool> Remove(int id)
        {
            var obj = await _repository.Find<Category>(s => s.Id == id).FirstOrDefaultAsync();
            obj.IsDeleted = true;
            var res = await _repository.SaveChangesAsync();
            return res;
        }

    }
}
