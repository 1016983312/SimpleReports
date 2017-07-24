using SimpleReports.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace SimpleReports.BLL
{
    public class VendingBLL
    {
        VendingDAL vendingDAL = new VendingDAL();
        public DataTable GetVendingTableByCustomerTable(DataTable cuDataTable)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow item in cuDataTable.Rows)
            {
                sb.Append(item["ID"].ToString());
                sb.Append("','");
            }
            if (sb.Length>=3)
            {
                sb.Remove(sb.Length - 3, 3);
                
            }
           return vendingDAL.GetVendingTableByCuStr(sb.ToString());
        }

        public DataTable GetVendingTableByCustomerId(Guid? cuId)
        {
            return vendingDAL.GetVendingTableByCuStr(cuId.ToString());
        }
    }
}