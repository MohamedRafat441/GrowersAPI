using GrowersDomain.Models.Growers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrowersServices.Interfaces.Growers
{
    public interface IOrderDetailsService
    {
        Task<List<OrderDetails>> GetAll();
        Task<bool> Add(OrderDetails entity);
        Task<bool> Edit(OrderDetails entity);
        Task<bool> Remove(int id);
        Task<OrderDetails> GetById(int id);
        Task<List<OrderDetails>> GetAll(int growerId);
    }
}
