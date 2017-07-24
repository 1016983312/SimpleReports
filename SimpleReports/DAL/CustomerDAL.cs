using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SimpleReports.DAL
{
    public class CustomerDAL : BasicDAL
    {
        public DataTable GetCustomerInfoByIdFromEVM(string cuId)
        {
            string sql = "select ID, CU1_CODE, CU1_Name, CU1_Relation, CU1_RelationPhone, CU1_CODE_Father, CU1_Account from B01_MDM.CU1_Customer where id='{0}'";
            sql = string.Format(sql, cuId);
            return spHelper.ExecuteToDataTable(sql);
        }

        public DataTable GetCustomerInfoByIdFromAM(string cuId)
        {
            string sql = "select cu.ID,cu.CU1_Account,cu.CU1_Name from zkh_am.dbo.WMS_User as u left join zkh_evm.B01_MDM.CU1_Customer as cu on cu.CU1_Account=u.UserName where u.id='{0}'";
            sql = string.Format(sql, cuId);
            return spHelper.ExecuteToDataTable(sql);
        }

        public DataTable GetGustomerListByName(string cuName)
        {
            string sql = @"select ID, CU1_CODE, CU1_Name, CU1_Relation, CU1_RelationPhone, CU1_CODE_Father, CU1_Account from B01_MDM.CU1_Customer where  CU1_Name='{0}'
                            union 
                            select ID, CU1_CODE, CU1_Name, CU1_Relation, CU1_RelationPhone, CU1_CODE_Father, CU1_Account from B01_MDM.CU1_Customer where CU1_CODE_Father in (
                            select CU1_CODE 
                            from B01_MDM.CU1_Customer
                            where CU1_Name='{0}')";
            sql = string.Format(sql, cuName);
            return spHelper.ExecuteToDataTable(sql);
        }
    }
}