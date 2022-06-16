using System;
using System.ComponentModel.DataAnnotations;

namespace Document.WorkFlow.Models
{
    public class PurchaseOrder
    {
        public int SupplierID { get; set; }
        public string? Description { get; set; }
        public string? PODate { get; set; }
        public string? PONumber { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalGross { get; set; }
        public decimal TotalVat { get; set; }
        public int ForeignID { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? Source { get; set; }
        public string? SearchString { get; set; }
        public string? CurrencyId { get; set; }
        public bool? Status { get; set; }
        public int Void { get; set; }

        public ICollection<PurchaseOrderLine>? PurchaseOrderLines { get; set; }
    }
}

