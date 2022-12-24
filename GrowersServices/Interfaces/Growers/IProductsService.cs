using GrowersDomain.Models.Growers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrowersServices.Interfaces.Growers
{
    public interface IProductsService
    {
        Task<List<Product>> GetAll();
        Task<bool> Add(Product entity);
        Task<bool> Edit(Product entity);
        Task<bool> Remove(int id);
        Task<Product> GetById(int id);
        Task<List<Product>> GetAll(int growerId);
    }
}
