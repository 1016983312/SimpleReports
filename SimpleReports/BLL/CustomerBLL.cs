using SimpleReports.DAL;
using SimpleReports.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SimpleReports.BLL
{
    public class CustomerBLL
    {
        CustomerDAL customerDAL = new CustomerDAL();
        Customer customerInfo = new Customer();
        DataTable dt = new DataTable();

        public Customer GetGustomerInfoByIdFromAM(string cuId)
        {
            dt = customerDAL.GetCustomerInfoByIdFromAM(cuId);
            if (dt != null && dt.Rows.Count > 0)
            {
                customerInfo.CuId = (Guid)dt.Rows[0]["ID"];
                customerInfo.CuAccount = dt.Rows[0]["CU1_Account"].ToString();
                customerInfo.CuName = dt.Rows[0]["CU1_Name"].ToString();
            }
            return customerInfo;
        }

        //public List<Customer> GetGustomerListById(string cuId)
        //{
        //    List<Customer> customerList = new List<Customer>();
        //    dt = customerDAL.GetGustomerListById(cuId);
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow item in dt.Rows)
        //        {
        //            Customer customer = new Customer();
        //            customer.CuId = (Guid)item["ID"];
        //            customer.CuCode = item["CU1_CODE"].ToString();
        //            customer.CuName = item["CU1_Name"].ToString();
        //            customer.CuRelationName = item["CU1_Relation"] == DBNull.Value ? "" : item["CU1_Relation"].ToString();
        //            customer.CuRelationPhone = item["CU1_RelationPhone"] == DBNull.Value ? "" : item["CU1_RelationPhone"].ToString();
        //            customer.CuFatherCode = item["CU1_CODE_Father"] == DBNull.Value ? "" : item["CU1_CODE_Father"].ToString();
        //            customer.CuAccount = item["CU1_Account"] == DBNull.Value ? "" : item["CU1_Account"].ToString();

        //            customerList.Add(customer);
        //        }
        //    }
        //    return customerList;
        //}

        public DataTable GetCustomerTableByName(string cuName)
        {
            dt = customerDAL.GetGustomerListByName(cuName);
            return dt;
        }
    }
}