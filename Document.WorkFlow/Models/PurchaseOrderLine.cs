using System;
using CsvHelper.Configuration.Attributes;

namespace Document.WorkFlow.Models
{
    public class PurchaseOrderLine
    {
        [Name("ForeignID")]
        public string? ForeignID { get; set; }

        [Name(" PartNumber")]
        public string? PartNumber { get; set; }

        [Name(" NetValue")]
        public string? NetValue { get; set; }

        [Name(" VatValue")]
        public string? VatValue { get; set; }

        [Name(" Value")]
        public string? Value { get; set; }

        [Name(" QuantityOrdered")]
        public string? QuantityOrdered { get; set; }

        [Name(" QuantityReceived")]
        public string? QuantityReceived { get; set; }

        [Name(" Description")]
        public string? Description { get; set; }

        [Name(" UnitPrice")]
        public string? UnitPrice { get; set; }

        [Name(" UnitOfMeasure")]
        public string? UnitMeasure { get; set; }
    }
}

