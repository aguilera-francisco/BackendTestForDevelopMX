using BackendTest.DTOs;
using BackendTest.Models;
using BackendTest.Repositories;

namespace BackendTest.Services
{
    public class CustomerService : ICustomerService<CustomerDTO, AddressDTO>
    {
        IRepository<Customer> _repository;
        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        async public Task<CustomerDTO?> BuildCustomer()
        {

            var customer = await _repository.Get();
            if (customer == null)
            {
                return null;
            }
            var addressesDTO = customer.Addresses?.Select(a => new AddressDTO
            {
                Address1 = a.Address1,
                Address2 = a.Address2,
                AddressId = a.AddressId,
                City = a.City,
                CountryCode = a.CountryCode,
                CreationDate = a.CreationDate,
                C_BuildingNumber = a.C_BuildingNumber,
                C_Street_Number = a.C_Street_Number,
                Phone = a.Phone,
                PostalCode = a.PostalCode,
                Preferred = a.Preferred,
                StateCode = a.StateCode
            }).ToList<AddressDTO>();

            return new CustomerDTO
            {
                customerId = customer.CustomerId,
                Email = customer.Email,
                PhoneHome = customer.PhoneHome,
                PhoneMobile = customer.PhoneMobile,
                Birthday = customer.Birthday,
                FirstName = customer.FirstName,
                Lastname = customer.LastName,
                Addresses = addressesDTO,
            };
        }
        async public Task<CustomerDTO?> GetCustomer()
        {
            return await BuildCustomer();
        }
        async public Task<List<AddressDTO>?> GetAddresses(string sort, string order)
        {
            var customer = await BuildCustomer();
            if (customer == null)
            {
                return null;
            }
            IEnumerable<AddressDTO>? addresses = null;
            switch (sort.ToLower())
            {
                case "address":
                    addresses = from a in customer.Addresses
                                orderby a.Address1 ascending
                                select a;
                    if (order.ToLower().Equals("desc"))
                    {
                        addresses = from a in customer.Addresses
                                    orderby a.Address1 descending
                                    select a;
                    }
                    break;

                case "date":
                    addresses = from a in customer.Addresses
                                orderby a.CreationDate ascending
                                select a;
                    if (order.ToLower().Equals("desc"))
                    {
                        addresses = from a in customer.Addresses
                                    orderby a.CreationDate descending
                                    select a;
                    }
                    break;

            }
            return addresses?.ToList() ?? null;
        }
        async public Task<AddressDTO?> GetPreferredAddress()
        {
            var customer = await BuildCustomer();
            if (customer == null)
            {
                return null;
            }
            var preferred = from a in customer.Addresses
                            where a.Preferred == true
                            select a;
            return preferred.FirstOrDefault();
        }
        async public Task<List<AddressDTO>?> FindAddressByPostalCode(string postalCode)
        {
            var customer = await BuildCustomer();
            if (customer == null)
            {
                return null;
            }
            var addresses = from a in customer.Addresses
                            where a.PostalCode == postalCode
                            select a;
            return addresses?.ToList() ?? null;
        }
    }
}
