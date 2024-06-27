namespace BackendTest.Models
{
    public class Customer
    {
        public string AuthType { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerNo { get; set; }
        public string? Email { get; set; }
        public bool Enabled { get; set; }
        public string? FirstName { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastName { get; set; }//10
        public DateTime? LastVisitTime { get; set; }
        public string? Login { get; set; }
        public string? PhoneHome { get; set; }
        public string? PhoneMobile { get; set; }
        public DateTime PreviousLoginTime { get; set; }
        public DateTime PreviousVisitTime { get; set; }
        public string? C_DefaultDeliveryHome { get; set; }
        public bool C_DefaultDeliveryStore { get; set; }
        public string? C_DoubleOptinLoyaltyResult { get; set; }
        public string? C_DoubleOptinAction { get; set; }//20
        public string? C_FatherName { get; set; }
        public string? C_PreferredPostalCode { get; set; }
        public string? C_PreferredStoreId { get; set; }
        public bool C_ShowInfographicCheckoutAddCard { get; set; }
        public bool C_ShowInfographicCheckoutCvv { get; set; }
        public bool C_ShowInfographicPaymentMethods { get; set; }
        public bool C_ShowInfographicCheckoutBancomer { get; set; }
        public bool C_ShowInfographicCheckoutSantander { get; set; }
        public bool C_ShowInfographicPaymentMethodsBancomer { get; set; }
        public bool C_ShowInfographicPaymentMethodsSantander { get; set; }//30
        public bool C_DateForActivation { get; set; }
        public string? C_TempPostalCode { get; set; }
        public string? C_TempStoreId { get; set; }
        public string? C_Login_Apple { get; set; }
        public string? C_Login_Facebook { get; set; }
        public string? C_Login_Google { get; set; }
        public string? C_Login_Linkedin { get; set; }
        public bool C_SMSVerified { get; set; }
        public string? C_NivelRFM { get; set; }
        public string? C_TempStoreIdNoEsp { get; set; }//40
        public bool C_EmailConfirmed { get; set; }
        public string? C_TempPostalCodeNoEsp { get; set; }
        public string? PreferredLocale { get; set; }
        public DateTime Birthday { get; set; }
        public virtual List<Address>? Addresses { get; set; }
        public string? ErrorMessage { get; set; }
        public string? DefaultStoredId { get; set; }
        public string? DefaultPostalCode { get; set; }
    }
}