namespace NewOrder
{
    partial class Form1
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
            this.btnEmployeeSignIn = new System.Windows.Forms.Button();
            this.btnCustomerSignIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmployeeSignIn
            // 
            this.btnEmployeeSignIn.Location = new System.Drawing.Point(51, 21);
            this.btnEmployeeSignIn.Name = "btnEmployeeSignIn";
            this.btnEmployeeSignIn.Size = new System.Drawing.Size(156, 41);
            this.btnEmployeeSignIn.TabIndex = 0;
            this.btnEmployeeSignIn.Text = "Çalışan Girişi";
            this.btnEmployeeSignIn.UseVisualStyleBackColor = true;
            this.btnEmployeeSignIn.Click += new System.EventHandler(this.btnEmployeeSignIn_Click);
            // 
            // btnCustomerSignIn
            // 
            this.btnCustomerSignIn.Location = new System.Drawing.Point(51, 93);
            this.btnCustomerSignIn.Name = "btnCustomerSignIn";
            this.btnCustomerSignIn.Size = new System.Drawing.Size(156, 41);
            this.btnCustomerSignIn.TabIndex = 0;
            this.btnCustomerSignIn.Text = "Müşteri Girişi";
            this.btnCustomerSignIn.UseVisualStyleBackColor = true;
            this.btnCustomerSignIn.Click += new System.EventHandler(this.btnCustomerSignIn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 178);
            this.Controls.Add(this.btnCustomerSignIn);
            this.Controls.Add(this.btnEmployeeSignIn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmployeeSignIn;
        private System.Windows.Forms.Button btnCustomerSignIn;
    }
}

