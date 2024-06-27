namespace BackendTest.DTOs
{
    public class AddressDTO
    {
        public string? AddressId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? C_Street_Number { get; set; }
        public string? C_BuildingNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? StateCode { get; set; }
        public string? CountryCode { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Phone { get; set; }
        public bool Preferred { get; set; }
    }
}
