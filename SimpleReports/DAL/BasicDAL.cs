using SimpleReports.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SimpleReports.DAL
{
    public class BasicDAL
    {
        protected string GetStockTransactionByInSql = ConfigurationManager.AppSettings["GetStockTransactionByInSql"].ToString();
        protected string GetStockTransactionByEqualSql = ConfigurationManager.AppSettings["GetStockTransactionByEqualSql"].ToString();
        protected SPHelper spHelper = new SPHelper();
    }
}