using GrowersDomain.Models.Growers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrowersServices.Interfaces.Growers
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<List<Order>> GetAll(int growerId);
        Task<Order> Add(Order entity);
        Task<bool> Edit(Order entity);
        Task<bool> Remove(int id);
        Task<Order> GetById(int id);
        Task<List<Order>> GetAllByCustomerId(int customerId);
    }
}
