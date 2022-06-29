using System;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace Document.WorkFlow.Models
{
    public class PurchaseOrder
    {
        public int SupplierID { get; set; }

        [Name(" Description")]
        public string? Description { get; set; }

        [Name(" PODate")]
        public string? PODate { get; set; }

        [Name(" PONumber")]
        public string? PONumber { get; set; }

        [Name(" TotalNet £")]
        public decimal TotalNet { get; set; }

        [Name(" TotalGross £")]
        public decimal TotalGross { get; set; }

        [Name(" TotalVat £")]
        public decimal TotalVat { get; set; }

        [Name(" ForeignID")]
        public string? ForeignID { get; set; }

        [Name(" DateUpdated")]
        public DateTime? DateUpdated { get; set; }

        [Name(" DateCreated")]
        public DateTime? DateCreated { get; set; }

        [Name(" Source")]
        public string? Source { get; set; }

        [Name(" SearchString")]
        public string? SearchString { get; set; }

        [Name(" CurrencyId")]
        public string? CurrencyId { get; set; }

        [Name(" Status")]
        public bool? Status { get; set; }

        [Name(" Void")]
        public int Void { get; set; }

        public ICollection<PurchaseOrderLine>? PurchaseOrderLines { get; set; }
    }
}

