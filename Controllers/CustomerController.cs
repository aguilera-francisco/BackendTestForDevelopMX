using BackendTest.DTOs;
using BackendTest.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;




namespace BackendTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService<CustomerDTO, AddressDTO> _customerService;
        private IValidator<string> _postalCodeValidator;
        public CustomerController(ICustomerService<CustomerDTO, AddressDTO> customerService, IValidator<string> postalCodeValidator)
        {
            _customerService = customerService;
            _postalCodeValidator = postalCodeValidator;
        }

        [HttpGet]
        async public Task<ActionResult<CustomerDTO>> Get()
        {

            var customer = await _customerService.GetCustomer();
            if (customer == null)
            {
                return Problem();
            }
            return Ok(customer);
        }

        [HttpGet("Addresses")]
        async public Task<ActionResult<List<AddressDTO>>> GetOrderedAddresses(string? sort = "address", string? order = "asc")
        {
            var addresses = await _customerService.GetAddresses(sort, order);
            return Ok(addresses);
        }

        [HttpGet("Addresses/Preferred")]
        async public Task<ActionResult<AddressDTO>> GetPreferredAddress()
        {
            var address = await _customerService.GetPreferredAddress();
            if (address == null)
            {
                return Problem();
            }
            return Ok(address);

        }

        [HttpGet("Addresses/PostalCode/{postalCode}")]
        async public Task<ActionResult<List<AddressDTO>>> GetAddressesByPostalCode(string postalCode)
        {
            var pcValidationResult = await _postalCodeValidator.ValidateAsync(postalCode);
            if (!pcValidationResult.IsValid)
            {
                return BadRequest(pcValidationResult.Errors);
            }
            var addresses = await _customerService.FindAddressByPostalCode(postalCode);
            if (addresses == null)
            {
                return BadRequest();
            }
            if (addresses.Count == 0) { return NotFound(); }
            return Ok(addresses);
        }




    }
}
