namespace UrbanFood
{
    partial class RoleSelection
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SupplierSelectionBtn = new MaterialSkin.Controls.MaterialButton();
            CustomerSelectionBtn = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // SupplierSelectionBtn
            // 
            SupplierSelectionBtn.AutoSize = false;
            SupplierSelectionBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SupplierSelectionBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            SupplierSelectionBtn.Depth = 0;
            SupplierSelectionBtn.HighEmphasis = true;
            SupplierSelectionBtn.Icon = null;
            SupplierSelectionBtn.Location = new Point(98, 200);
            SupplierSelectionBtn.Margin = new Padding(4, 6, 4, 6);
            SupplierSelectionBtn.MouseState = MaterialSkin.MouseState.HOVER;
            SupplierSelectionBtn.Name = "SupplierSelectionBtn";
            SupplierSelectionBtn.NoAccentTextColor = Color.Empty;
            SupplierSelectionBtn.Size = new Size(200, 60);
            SupplierSelectionBtn.TabIndex = 0;
            SupplierSelectionBtn.Text = "supplier";
            SupplierSelectionBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            SupplierSelectionBtn.UseAccentColor = false;
            SupplierSelectionBtn.UseVisualStyleBackColor = true;
            SupplierSelectionBtn.Click += SupplierSelectionBtn_Click;
            // 
            // CustomerSelectionBtn
            // 
            CustomerSelectionBtn.AutoSize = false;
            CustomerSelectionBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CustomerSelectionBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            CustomerSelectionBtn.Depth = 0;
            CustomerSelectionBtn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CustomerSelectionBtn.HighEmphasis = true;
            CustomerSelectionBtn.Icon = null;
            CustomerSelectionBtn.Location = new Point(98, 105);
            CustomerSelectionBtn.Margin = new Padding(4, 6, 4, 6);
            CustomerSelectionBtn.MouseState = MaterialSkin.MouseState.HOVER;
            CustomerSelectionBtn.Name = "CustomerSelectionBtn";
            CustomerSelectionBtn.NoAccentTextColor = Color.Empty;
            CustomerSelectionBtn.Size = new Size(200, 60);
            CustomerSelectionBtn.TabIndex = 1;
            CustomerSelectionBtn.Text = "customer";
            CustomerSelectionBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            CustomerSelectionBtn.UseAccentColor = false;
            CustomerSelectionBtn.UseVisualStyleBackColor = true;
            CustomerSelectionBtn.Click += CustomerSelectionBtn_Click;
            // 
            // RoleSelection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 300);
            Controls.Add(CustomerSelectionBtn);
            Controls.Add(SupplierSelectionBtn);
            MaximizeBox = false;
            Name = "RoleSelection";
            RightToLeft = RightToLeft.No;
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "What Is Your Role";
            FormClosing += RoleSelection_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton SupplierSelectionBtn;
        private MaterialSkin.Controls.MaterialButton CustomerSelectionBtn;
    }
}
