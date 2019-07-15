using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Dominos.Common.Classes;
using Dominos.Common.DTO.Output;
using Dominos.Data.Models;
using Dominos.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Dominos.Business.OrderService
{
    public class OrderService : IOrderService
    {
        public OrderService(IRepository<Order> orderRepository,
                            IRepository<Customer> customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Customer> _customerRepository;

        public async Task<ResponseEntity<List<OrderOutputDTO>>> GetOrderList(int customerId)
        {
            var response = new ResponseEntity<List<OrderOutputDTO>>();

            try
            {
                response.Result = await (from o in _orderRepository.Table
                                         join c in _customerRepository.Table on o.CustomerId equals c.Id
                                         where o.CustomerId == customerId
                                         select new OrderOutputDTO
                                         {
                                             CustomerAddress = c.Address,
                                             CustomerId = c.Id,
                                             CustomerName = c.Name + " " + c.Surname,
                                             DiscountPrice = o.DiscountPrice,
                                             OrderId = o.Id,
                                             TotalPrice = o.TotalPrice
                                         })
                                         .ToListAsync();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Exception = ex;
                response.HttpCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}