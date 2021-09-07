namespace NewOrder
{
    partial class FormCustomerScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpCustomerScreen = new System.Windows.Forms.GroupBox();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.grpCustomerScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCustomerScreen
            // 
            this.grpCustomerScreen.Controls.Add(this.cbCategories);
            this.grpCustomerScreen.Controls.Add(this.label1);
            this.grpCustomerScreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCustomerScreen.Location = new System.Drawing.Point(0, 0);
            this.grpCustomerScreen.Name = "grpCustomerScreen";
            this.grpCustomerScreen.Size = new System.Drawing.Size(795, 63);
            this.grpCustomerScreen.TabIndex = 0;
            this.grpCustomerScreen.TabStop = false;
            // 
            // cbCategories
            // 
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(155, 23);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(187, 28);
            this.cbCategories.TabIndex = 1;
            this.cbCategories.SelectedIndexChanged += new System.EventHandler(this.cbCategories_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kategoriler :";
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpProducts.Location = new System.Drawing.Point(0, 69);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Size = new System.Drawing.Size(795, 482);
            this.flpProducts.TabIndex = 3;
            // 
            // FormCustomerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 551);
            this.Controls.Add(this.flpProducts);
            this.Controls.Add(this.grpCustomerScreen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormCustomerScreen";
            this.Text = "FormCustomerScreen";
            this.Load += new System.EventHandler(this.FormCustomerScreen_Load);
            this.grpCustomerScreen.ResumeLayout(false);
            this.grpCustomerScreen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCustomerScreen;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
    }
}