using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using MaterialSkin.Controls;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrbanFood.Database.OracleDB;
using UrbanFood.LocalState;
using UrbanFood.Utils;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace UrbanFood.Controls
{
    public partial class SalseReport : UserControl
    {
        public class SupplierProductSales
        {
            public string? ProductID { get; set; }
            public string? ProductName { get; set; }
            public int TotalQuantitySold { get; set; }
            public decimal TotalRevenue { get; set; }
        }

        public class SupplierSummary
        {
            public string? SupplierID { get; set; }
            public string? SupplierName { get; set; }
            public int TotalOrders { get; set; }
            public int TotalQuantitySold { get; set; }
            public decimal TotalRevenue { get; set; }
        }

        public class DailySales
        {
            public DateTime SalesDate { get; set; }
            public decimal DailyRevenue { get; set; }
        }


        public SalseReport()
        {
            InitializeComponent();
        }

        private void SalseReport_Load(object sender, EventArgs e)
        {
            PopulateSalseData();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            PopulateSalseData();
        }

        private void PopulateSalseData()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                string supplierID = UserState.Instance.GetUserId();

                List<SupplierProductSales> totalSalesPerProduct = new();
                SupplierSummary? supplierSalesSummary = null;
                List<DailySales> supplierSalesLast30Days = new();

                using (OracleCommand cmd = new("Get_TotalSalesPerProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    cmd.Parameters.Add(cursor);
                    cmd.Parameters.Add("pSupplierID", OracleDbType.Varchar2).Value = supplierID;

                    using OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        totalSalesPerProduct.Add(new SupplierProductSales
                        {
                            ProductID = reader["ProductID"].ToString(),
                            ProductName = reader["ProductName"].ToString(),
                            TotalQuantitySold = Convert.ToInt32(reader["TotalQuantitySold"]),
                            TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                        });
                    }
                }

                using (OracleCommand cmd = new("Get_SupplierSalesSummary", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    cmd.Parameters.Add(cursor);
                    cmd.Parameters.Add("pSupplierID", OracleDbType.Varchar2).Value = supplierID;

                    using OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        supplierSalesSummary = new SupplierSummary
                        {
                            SupplierID = reader["SupplierID"].ToString(),
                            SupplierName = reader["SupplierName"].ToString(),
                            TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                            TotalQuantitySold = Convert.ToInt32(reader["TotalQuantitySold"]),
                            TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                        };
                    }
                }

                using (OracleCommand cmd = new("Get_SupplierSalesLast30Days", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    cmd.Parameters.Add(cursor);
                    cmd.Parameters.Add("pSupplierID", OracleDbType.Varchar2).Value = supplierID;

                    using OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        supplierSalesLast30Days.Add(new DailySales
                        {
                            SalesDate = Convert.ToDateTime(reader["SalesDate"]),
                            DailyRevenue = Convert.ToDecimal(reader["DailyRevenue"])
                        });
                    }
                }

                if (totalSalesPerProduct.Any())
                {
                   LoadTotalSalesPerProductChart(totalSalesPerProduct);
                }

                if (supplierSalesSummary != null)
                {
                    LoadSupplierSalesSummary(supplierSalesSummary);
                }

                if (supplierSalesLast30Days.Any())
                {
                    LoadSupplierSalesLast30DaysChart(supplierSalesLast30Days);
                }
            }
            catch (OracleException ex)
            {
                MaterialMessageBox.Show(ErrorHandler.GetOracleErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                OracleDBConnection.Instance.CloseConnection();
            }
        }

        private void LoadTotalSalesPerProductChart(List<SupplierProductSales> totalSalesPerProduct)
        {
            ProductSalseChart.Series =
            [
                new ColumnSeries<int>
                {
                    Name = "Total Quantity Sold",
                    Values = totalSalesPerProduct.Select(p => p.TotalQuantitySold).ToArray(),
                }
            ];

            ProductSalseChart.XAxes =
            [
                new Axis
                {
                    Labels = totalSalesPerProduct.Select(p => p.ProductName).ToArray(),
                    LabelsPaint = new SolidColorPaint(SKColors.White),
                    NamePaint = new SolidColorPaint(SKColors.White),
                }
            ];

            ProductSalseChart.YAxes =
            [
                new Axis
                {
                    Name = "Units Sold",
                    LabelsPaint = new SolidColorPaint(SKColors.White),
                    NamePaint = new SolidColorPaint(SKColors.White),
                }
            ];
        }

        private void LoadSupplierSalesLast30DaysChart(List<DailySales> supplierSalesLast30Days)
        {
            DailyRevenueChart.Series =
            [
                new LineSeries<decimal>
                {
                    Name = "Daily Revenue",
                    Values = supplierSalesLast30Days.Select(s => s.DailyRevenue).ToArray()
                }
            ];

            DailyRevenueChart.XAxes =
            [
                new Axis
                {
                    Labels = supplierSalesLast30Days.Select(s => s.SalesDate.ToShortDateString()).ToArray(),
                    LabelsPaint = new SolidColorPaint(SKColors.White),
                    NamePaint = new SolidColorPaint(SKColors.White),
                }
            ];

            DailyRevenueChart.YAxes =
            [
                new Axis
                {
                    Name = "Revenue (Rs)",
                    LabelsPaint = new SolidColorPaint(SKColors.White),
                    NamePaint = new SolidColorPaint(SKColors.White),
                }
            ];
        }


        public void LoadSupplierSalesSummary(SupplierSummary supplierSummary)
        {
            TotalOrders.Text = $"Total Orders: {supplierSummary.TotalOrders.ToString()}";
            TotalOrders.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            TotalSoldOrders.Text = $"Total Units Sold: {supplierSummary.TotalQuantitySold.ToString()}";
            TotalSoldOrders.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            TotalRevenue.Text = $"Total Revenue Rs: {supplierSummary.TotalRevenue.ToString()}";
            TotalRevenue.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        }
    }
}
