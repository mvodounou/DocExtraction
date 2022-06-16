using System;
using CsvHelper.Configuration.Attributes;

namespace Document.WorkFlow.Models
{
    public class Supplier
    {
        [Name(" Supplier ID")]
        public int SupplierID { get; set; }

        [Name(" Name")]
        public string? Name { get; set; }

        [Name(" Address Line 1")]
        public string? Address_Line { get; set; }

        [Name(" Accounts Ref")]
        public string? Accounts_Ref { get; set; }

        [Name(" Postcode")]
        public string? PostCode { get; set; }

        [Name(" Void")]
        public int Void { get; set; }

        [Name(" Vat Reg")]
        public string? Vat_Reg { get; set; }

        [Name("Created Date")]
        public DateTime Created_dATE { get; set; }
    }
}

