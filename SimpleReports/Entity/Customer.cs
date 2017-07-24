using System;

namespace SimpleReports.Entity
{
    public class Customer
    {
        public Guid  CuId { get; set; }
        public string CuCode { get; set; }
        public string CuName { get; set; }
        public string CuRelationName { get; set; }
        public string CuRelationPhone { get; set; }
        public string CuFatherCode { get; set; }
        public string CuAccount { get; set; }
       

    }
}