namespace StepsConsoleApp.Contracts.Dtos
{
    public class AddressDto
    {
        public long ReturnHeadId { get; set; }
        public string AccountNumber { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Carrier { get; set; }
    }
}