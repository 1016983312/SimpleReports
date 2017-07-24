using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleReports
{
    public class StocktransactionData
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal TransQty { get; set; }
        public decimal Price { get; set; }
        public string DepartmentName { get; set; }
        public decimal NoTaxPrice { get; set; }
        public decimal TotalNoTaxExpense { get; set; }
        public int Count { get; set; }
    }
}