using BackendTest.DTOs;
using BackendTest.Services;
using Microsoft.AspNetCore.Mvc;




namespace BackendTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService<CustomerDTO, AddressDTO> _customerService;
        public CustomerController(ICustomerService<CustomerDTO, AddressDTO> customerService) {
            _customerService = customerService;
        }

        [HttpGet]
        async public Task<ActionResult<CustomerDTO>> Get() {

            var customer = await _customerService.GetCustomer();
            if (customer == null) {
                return Problem();
            }
            return Ok(customer);
        }

        [HttpGet("Addresses")]
        async public Task<ActionResult<List<AddressDTO>>> GetOrderedAddresses(string sort = "address", string order = "asc") {
            var addresses = await _customerService.GetAddresses(sort, order); 
            return Ok(addresses);
        }

        [HttpGet("Addresses/Preferred")]
        async public Task<ActionResult<AddressDTO>> GetPreferredAddress() { 
            var address = await _customerService.GetPreferredAddress();
            if (address == null) {
                return Problem(); 
            }
            return Ok(address);
        
        }

        [HttpGet("Addresses/PostalCode/{postalCode}")]
        async public Task<ActionResult<List<AddressDTO>>> GetAddressesByPostalCode(string postalCode) {

            var addresses = await _customerService.FindAddressByPostalCode(postalCode);
            if (addresses == null) { 
                return BadRequest();
            }
            if(addresses.Count == 0) { return NotFound(); }
            return Ok(addresses);
        }
        



    }
}
