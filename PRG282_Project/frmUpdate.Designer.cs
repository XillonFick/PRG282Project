
namespace PRG282_Assignment_GUI
{
    partial class frmUpdate
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
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(284, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(344, 41);
            this.label3.TabIndex = 8;
            this.label3.Text = "Update Phone/Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.Location = new System.Drawing.Point(305, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 28);
            this.label7.TabIndex = 38;
            this.label7.Text = "Address: ";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(485, 178);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(125, 22);
            this.txtAddress.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.Location = new System.Drawing.Point(305, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 28);
            this.label8.TabIndex = 36;
            this.label8.Text = "Phone:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(485, 141);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PasswordChar = '*';
            this.txtPhone.Size = new System.Drawing.Size(125, 22);
            this.txtPhone.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(305, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 28);
            this.label1.TabIndex = 27;
            this.label1.Text = "Student ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(485, 102);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(125, 22);
            this.txtID.TabIndex = 26;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Info;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnUpdate.Location = new System.Drawing.Point(496, 255);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(132, 42);
            this.btnUpdate.TabIndex = 43;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Info;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBack.Location = new System.Drawing.Point(271, 255);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(132, 42);
            this.btnBack.TabIndex = 42;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(951, 409);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmUpdate";
            this.Text = "frmUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnBack;
    }
}