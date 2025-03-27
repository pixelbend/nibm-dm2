namespace UrbanFood.Controls
{
    partial class SalseReport
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ProductSalseChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            label1 = new Label();
            DailyRevenueChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            label2 = new Label();
            Refresh = new MaterialSkin.Controls.MaterialButton();
            TotalRevenue = new Label();
            TotalOrders = new Label();
            TotalSoldOrders = new Label();
            SuspendLayout();
            // 
            // ProductSalseChart
            // 
            ProductSalseChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProductSalseChart.Location = new Point(21, 345);
            ProductSalseChart.MatchAxesScreenDataRatio = false;
            ProductSalseChart.Name = "ProductSalseChart";
            ProductSalseChart.Size = new Size(800, 250);
            ProductSalseChart.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 311);
            label1.Name = "label1";
            label1.Size = new Size(159, 31);
            label1.TabIndex = 1;
            label1.Text = "Prdouct Salse";
            // 
            // DailyRevenueChart
            // 
            DailyRevenueChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DailyRevenueChart.Location = new Point(21, 47);
            DailyRevenueChart.MatchAxesScreenDataRatio = false;
            DailyRevenueChart.Name = "DailyRevenueChart";
            DailyRevenueChart.Size = new Size(800, 250);
            DailyRevenueChart.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 13);
            label2.Name = "label2";
            label2.Size = new Size(68, 31);
            label2.TabIndex = 3;
            label2.Text = "Salse";
            // 
            // Refresh
            // 
            Refresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Refresh.AutoSize = false;
            Refresh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Refresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Refresh.Depth = 0;
            Refresh.HighEmphasis = true;
            Refresh.Icon = null;
            Refresh.Location = new Point(1120, 13);
            Refresh.Margin = new Padding(4, 6, 4, 6);
            Refresh.MouseState = MaterialSkin.MouseState.HOVER;
            Refresh.Name = "Refresh";
            Refresh.NoAccentTextColor = Color.Empty;
            Refresh.Size = new Size(123, 45);
            Refresh.TabIndex = 4;
            Refresh.Text = "Refresh";
            Refresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Refresh.UseAccentColor = false;
            Refresh.UseVisualStyleBackColor = true;
            Refresh.Click += Refresh_Click;
            // 
            // TotalRevenue
            // 
            TotalRevenue.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TotalRevenue.AutoSize = true;
            TotalRevenue.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalRevenue.Location = new Point(843, 564);
            TotalRevenue.Name = "TotalRevenue";
            TotalRevenue.Size = new Size(157, 31);
            TotalRevenue.TabIndex = 5;
            TotalRevenue.Text = "TotalRevenue";
            // 
            // TotalOrders
            // 
            TotalOrders.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TotalOrders.AutoSize = true;
            TotalOrders.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalOrders.Location = new Point(843, 488);
            TotalOrders.Name = "TotalOrders";
            TotalOrders.Size = new Size(138, 31);
            TotalOrders.TabIndex = 6;
            TotalOrders.Text = "TotalOrders";
            // 
            // TotalSoldOrders
            // 
            TotalSoldOrders.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TotalSoldOrders.AutoSize = true;
            TotalSoldOrders.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalSoldOrders.Location = new Point(843, 526);
            TotalSoldOrders.Name = "TotalSoldOrders";
            TotalSoldOrders.Size = new Size(186, 31);
            TotalSoldOrders.TabIndex = 7;
            TotalSoldOrders.Text = "TotalSoldOrders";
            // 
            // SalseReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TotalSoldOrders);
            Controls.Add(TotalOrders);
            Controls.Add(TotalRevenue);
            Controls.Add(Refresh);
            Controls.Add(label2);
            Controls.Add(DailyRevenueChart);
            Controls.Add(label1);
            Controls.Add(ProductSalseChart);
            Name = "SalseReport";
            Size = new Size(1266, 610);
            Load += SalseReport_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart ProductSalseChart;
        private Label label1;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart DailyRevenueChart;
        private Label label2;
        private MaterialSkin.Controls.MaterialButton Refresh;
        private Label TotalRevenue;
        private Label TotalOrders;
        private Label TotalSoldOrders;
    }
}
