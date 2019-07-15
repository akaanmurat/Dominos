using Dominos.Common.Classes;
using Dominos.Common.DTO.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominos.Business.OrderService
{
    public interface IOrderService
    {
        Task<ResponseEntity<List<OrderOutputDTO>>> GetOrderList(int customerId);
    }
}