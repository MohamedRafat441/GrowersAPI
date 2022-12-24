using GrowersDomain.Models.Growers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrowersServices.Interfaces.Growers
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<bool> Add(Category entity);
        Task<bool> Edit(Category entity);
        Task<bool> Remove(int id);
        Task<Category> GetById(int id);
    }
}
