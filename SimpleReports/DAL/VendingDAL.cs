using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SimpleReports.DAL
{
    public class VendingDAL : BasicDAL
    {
        public DataTable GetVendingTableByCuStr(string cuStr)
        {
            string sql = @"select vd.ID,vd.VD1_CODE
                            from B01_MDM.VD1_Vending as vd
                            left join F01_CERT.CV1_CusVendingPower as cvp on cvp.CV1_VD1_ID = vd.id
                            where cvp.CV1_CU1_ID in ('{0}')";
            sql = string.Format(sql, cuStr);
            return spHelper.ExecuteToDataTable(sql);
        }
    }
}