using BackendTest.Models;

namespace BackendTest.DTOs
{
    public class CustomerDTO
    {
        public string customerId { get; set; }
        public string? Email { get; set; }
        public string? PhoneHome { get; set; }
        public string? PhoneMobile { get; set; }
        public virtual List<AddressDTO>? Addresses { get; set; }
        public DateTime Birthday { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
    }
}
