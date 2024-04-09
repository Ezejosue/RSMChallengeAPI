namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class UpdateSaleOrderHeaderDto
    {
        public int SalesOrderId { get; set; }
        public byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDue { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
    }
}