namespace LINQ
{
    partial class Form2
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMSSVF2 = new System.Windows.Forms.TextBox();
            this.txtNameSVF2 = new System.Windows.Forms.TextBox();
            this.txtDTBF2 = new System.Windows.Forms.TextBox();
            this.cbbLopF2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(69, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(236, 332);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "MSSV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "NameSV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "DTB";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "LopSH";
            // 
            // txtMSSVF2
            // 
            this.txtMSSVF2.Location = new System.Drawing.Point(139, 57);
            this.txtMSSVF2.Name = "txtMSSVF2";
            this.txtMSSVF2.Size = new System.Drawing.Size(100, 20);
            this.txtMSSVF2.TabIndex = 6;
            // 
            // txtNameSVF2
            // 
            this.txtNameSVF2.Location = new System.Drawing.Point(139, 107);
            this.txtNameSVF2.Name = "txtNameSVF2";
            this.txtNameSVF2.Size = new System.Drawing.Size(100, 20);
            this.txtNameSVF2.TabIndex = 6;
            // 
            // txtDTBF2
            // 
            this.txtDTBF2.Location = new System.Drawing.Point(139, 169);
            this.txtDTBF2.Name = "txtDTBF2";
            this.txtDTBF2.Size = new System.Drawing.Size(100, 20);
            this.txtDTBF2.TabIndex = 6;
            // 
            // cbbLopF2
            // 
            this.cbbLopF2.FormattingEnabled = true;
            this.cbbLopF2.Location = new System.Drawing.Point(139, 231);
            this.cbbLopF2.Name = "cbbLopF2";
            this.cbbLopF2.Size = new System.Drawing.Size(121, 21);
            this.cbbLopF2.TabIndex = 7;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 450);
            this.Controls.Add(this.cbbLopF2);
            this.Controls.Add(this.txtDTBF2);
            this.Controls.Add(this.txtNameSVF2);
            this.Controls.Add(this.txtMSSVF2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMSSVF2;
        private System.Windows.Forms.TextBox txtNameSVF2;
        private System.Windows.Forms.TextBox txtDTBF2;
        private System.Windows.Forms.ComboBox cbbLopF2;
    }
}