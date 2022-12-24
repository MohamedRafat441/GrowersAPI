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
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IGenericRepository _repository;

        public OrderDetailsService(IGenericRepository repository)
        {
            _repository = repository;

        }
        public async Task<List<OrderDetails>> GetAll()
        {
            var res = await _repository.All<OrderDetails>().Where(s => !s.IsDeleted).ToListAsync();
            return res;
        }
        public async Task<List<OrderDetails>> GetAll(int orderId)
        {
            var res = await _repository.All<OrderDetails>().Where(s => s.OrderId== orderId && !s.IsDeleted).ToListAsync();
            return res;
        }
        public async Task<OrderDetails> GetById(int id)
        {
            var res = await _repository.All<OrderDetails>().FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            return res;
        }
        public async Task<bool> Add(OrderDetails entity)
        {
            _repository.Add<OrderDetails>(entity);
            var res = await _repository.SaveChangesAsync();
            return res;
        }

        public async Task<bool> Edit(OrderDetails entity)
        {
            _repository.Update<OrderDetails>(entity);
            var res = await _repository.SaveChangesAsync();
            return res;
        }
        public async Task<bool> Remove(int id)
        {
            var obj = await _repository.Find<OrderDetails>(s => s.Id == id).FirstOrDefaultAsync();
            obj.IsDeleted = true;
            var res = await _repository.SaveChangesAsync();
            return res;
        }

    }
}
