using System;
namespace Document.WorkFlow.Models
{
    public class PurchaseOrderLine
    {
        public string? ForeignID { get; set; }
        public string? PartNumber { get; set; }
        public decimal NetValue { get; set; }
        public decimal VatValue { get; set; }
        public decimal Value { get; set; }
        public int QuantityOrdered { get; set; }
        public int QuantityReceived { get; set; }
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string? UnitMeasure { get; set; }
    }
}

