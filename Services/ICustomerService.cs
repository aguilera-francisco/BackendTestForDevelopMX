namespace BackendTest.Services
{
    public interface ICustomerService<TCustomer, TAddress>
    {
        Task<TCustomer?> GetCustomer();
        Task<List<TAddress>?> GetAddresses(string? sort, string? order);
        Task<TAddress?> GetPreferredAddress();
        Task<List<TAddress>?> FindAddressByPostalCode(string postalCode);
    }
}
