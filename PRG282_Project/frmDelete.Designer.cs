
namespace PRG282_Assignment_GUI
{
    partial class frmDelete
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(274, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 41);
            this.label3.TabIndex = 9;
            this.label3.Text = "Delete Entry";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(225, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 28);
            this.label1.TabIndex = 11;
            this.label1.Text = "Student ID:";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(341, 109);
            this.txtStudentID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(125, 22);
            this.txtStudentID.TabIndex = 10;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Info;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDelete.Location = new System.Drawing.Point(386, 166);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(132, 40);
            this.btnDelete.TabIndex = 44;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Info;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBack.Location = new System.Drawing.Point(204, 166);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(132, 40);
            this.btnBack.TabIndex = 45;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // frmDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 360);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDelete";
            this.Text = "frmDelete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
    }
}