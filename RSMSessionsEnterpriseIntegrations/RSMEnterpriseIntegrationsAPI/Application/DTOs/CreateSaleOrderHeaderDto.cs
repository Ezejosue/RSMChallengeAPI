namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{

    public class CreateSaleOrderHeaderDto
    {
        public byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public int BillToAddressId { get; set; }
        public int ShipToAddressId { get; set; }
        public int ShipMethodId { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal SubTotal { get; set; }
    }
}