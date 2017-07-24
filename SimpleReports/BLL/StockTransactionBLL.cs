using SimpleReports.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SimpleReports.BLL
{
    public class StockTransactionBLL
    {
        StockTransactionDAL stockTransactionDal = new StockTransactionDAL();
        /// <summary>
        /// 获取交易记录明细
        /// </summary>
        /// <param name="customerStr">客户guid字符串，如：00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000</param>
        /// <param name="vendingStr">售货机guid字符串，如：00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000</param>
        /// <param name="startTime">开始时间，如：2017/07/17 10:25:43</param>
        /// <param name="endTime">结束时间，如：2017/07/17 10:25:58</param>
        /// <returns></returns>
        public DataTable GetStockTransactionBy(string customerStr, string vendingStr, string startTime, string endTime)
        {
            if (customerStr.IndexOf(',') < 0)
            {
                return stockTransactionDal.GetStockTransactionByEqual(customerStr, vendingStr, startTime, endTime);

            }
            else
            {
                return stockTransactionDal.GetStockTransactionByIn(customerStr, vendingStr, startTime, endTime);
            }
        }
    }
}