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
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository _repository;

        public OrderService(IGenericRepository repository)
        {
            _repository = repository;

        }
        public async Task<List<Order>> GetAll()
        {
            var res = await _repository.All<Order>().Include(s=>s.Customer).Include(s=>s.Grower).Include(s => s.OrderDetails).Where(s => !s.IsDeleted).ToListAsync();
            return res;
        }
        public async Task<List<Order>> GetAll(int growerId)
        {
            var res = await _repository.All<Order>().Include(s => s.Customer).Include(s => s.Grower).Include(s => s.OrderDetails).Where(s => s.GrowerId== growerId && !s.IsDeleted).ToListAsync();
            return res;
        }
        public async Task<List<Order>> GetAllByCustomerId(int customerId)
        {
            var res = await _repository.All<Order>().Include(s => s.Customer).Include(s => s.Grower).Include(s => s.OrderDetails).Where(s => s.CustomerId == customerId && !s.IsDeleted).ToListAsync();
            return res;
        }
        public async Task<Order> GetById(int id)
        {
            var res = await _repository.All<Order>().FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            return res;
        }
        public async Task<Order> Add(Order entity)
        {
            try
            {
                _repository.Add<Order>(entity);
                var res = await _repository.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        public async Task<bool> Edit(Order entity)
        {
            _repository.Update<Order>(entity);
            var res = await _repository.SaveChangesAsync();
            return res;
        }
        public async Task<bool> Remove(int id)
        {
            var obj = await _repository.Find<Order>(s => s.Id == id).FirstOrDefaultAsync();
            obj.IsDeleted = true;
            var res = await _repository.SaveChangesAsync();
            return res;
        }

    }
}
