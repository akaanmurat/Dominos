using Dominos.Common.Classes;
using Dominos.Common.DTO.Input;
using Dominos.Common.DTO.Output;
using System.Threading.Tasks;

namespace Dominos.Business.CustomerService
{
    public interface ICustomerService
    {
        Task<ResponseEntity<CustomerOutputDTO>> GetCustomerById(int customerId);

        Task<ResponseEntity<CustomerOutputDTO>> Login(LoginInputDTO input);

        Task<ResponseEntity<CustomerOutputDTO>> Register(RegisterInputDTO input);
    }
}