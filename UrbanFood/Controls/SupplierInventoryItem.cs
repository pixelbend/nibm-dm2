using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrbanFood.Forms;
using MaterialSkin.Controls;
using Oracle.ManagedDataAccess.Client;
using UrbanFood.Database.OracleDB;
using UrbanFood.Utils;
using UrbanFood.LocalState;
using Oracle.ManagedDataAccess.Types;
using UrbanFood.Database.MongoDB;
using MongoDB.Driver;

namespace UrbanFood.Controls
{
    public partial class SupplierInventoryItem : UserControl
    {
        private string _productID;
        private string _productName;
        private string _productDescription;
        private string _productStockQuantity;
        private string _productPrice;
        private string _productCatogory;


        public SupplierInventoryItem()
        {
            InitializeComponent();
        }


        [Category("Custom Props")]
        public string ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        [Category("Custom Props")]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; ProductNameLable.Text = _productName; }
        }

        [Category("Custom Props")]
        public string ProductDescription
        {
            get { return _productDescription; }
            set { _productDescription = value; ProductDescriptionLable.Text = _productDescription; }
        }

        [Category("Custom Props")]
        public string ProductStockQuantity
        {
            get { return _productStockQuantity; }
            set { _productStockQuantity = value; ProdcutQuantityLable.Text = $"Stock Quantity: {_productStockQuantity}"; }
        }

        [Category("Custom Props")]
        public string ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; PriceLable.Text = $"Unit Price Rs: {_productPrice}"; }
        }

        [Category("Custom Props")]
        public string ProductCatogory
        {
            get { return _productCatogory; }
            set { _productCatogory = value; CategoryLable.Text = _productCatogory; }
        }

        private void ProdcutQuantityLable_Click(object sender, EventArgs e)
        {

        }

        private void UpdateProductButton_Click(object sender, EventArgs e)
        {
            UpdateProduct updateProduct = new(_productID);
            updateProduct.FormClosed += UpdateProduct_FormClosed;
            updateProduct.ShowDialog();
        }

        private void UpdateProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshProductData();
        }

        private void RefreshProductData()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand getProductByIdCmd = new("Get_Product_By_ID", conn);
                getProductByIdCmd.CommandType = CommandType.StoredProcedure;

                OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                getProductByIdCmd.Parameters.Add(cursor);


                getProductByIdCmd.Parameters.Add("pProductID", OracleDbType.Varchar2).Value = _productID;


                using OracleDataReader reader = getProductByIdCmd.ExecuteReader();
                if (reader.Read())
                {
                    ProductNameLable.Text = reader["Name"].ToString();
                    ProductNameLable.Font = new("Segoe UI", 16, FontStyle.Bold);
                    ProductDescriptionLable.Text = reader["Description"] == DBNull.Value ? "No Description" : reader["Description"].ToString();
                    ProdcutQuantityLable.Text = $"Stock Quantity: {reader["StockQuantity"].ToString()}";
                    PriceLable.Text = $"Unit Price Rs: {reader["Price"].ToString()}";
                    CategoryLable.Text = reader["Category"] == DBNull.Value ? "Category: N/A" : $"Category: {reader["Category"].ToString()}";
                }
            }
            catch (OracleException ex)
            {
                MaterialMessageBox.Show(ErrorHandler.GetOracleErrorMessage(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            var result = MaterialMessageBox.Show("This Product will be permenantly deleted", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                string qresult = DeleteProductQuery(_productID, UserState.Instance.GetUserId());
                if (qresult != null)
                {
                    DeleteProductReviews(_productID);
                    Dispose();
                }
            }
        }

        public string DeleteProductQuery(string productId, string supplierId)
        {
            string deletedProductId = null;

            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Delete_Product", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                OracleParameter resultParam = new OracleParameter("vProductID", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(resultParam);

                cmd.Parameters.Add("pProductID", OracleDbType.Varchar2).Value = productId;
                cmd.Parameters.Add("pSupplierID", OracleDbType.Varchar2).Value = supplierId;

                cmd.ExecuteNonQuery();

                deletedProductId = resultParam.Value?.ToString();
            }
            catch (OracleException ex)
            {
                MaterialMessageBox.Show(ErrorHandler.GetOracleErrorMessage(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                OracleDBConnection.Instance.CloseConnection();
            }

            return deletedProductId;
        }

        private void DeleteProductReviews(string productID)
        {
            var collection = ReviewCollection.Instance.GetCollection();
            var filter = Builders<ReviewModel>.Filter.Eq(r => r.ProductID, productID);
            collection.DeleteMany(filter);
        }

    }
}
