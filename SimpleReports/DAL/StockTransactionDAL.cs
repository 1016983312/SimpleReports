using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SimpleReports.DAL
{
    public class StockTransactionDAL : BasicDAL
    {
        public DataTable GetStockTransactionByIn(string customerStr, string vendingStr, string startTime, string endTime)
        {
            string sql = GetStockTransactionByInSql;
            sql = string.Format(sql, customerStr, vendingStr, startTime,endTime);
            return spHelper.ExecuteToDataTable(sql);
        }

        public DataTable GetStockTransactionByEqual(string customerStr, string vendingStr, string startTime, string endTime)
        {
            string sql = GetStockTransactionByEqualSql;
            sql = string.Format(sql, customerStr, vendingStr, startTime, endTime);
            return spHelper.ExecuteToDataTable(sql);
        }
    }
}