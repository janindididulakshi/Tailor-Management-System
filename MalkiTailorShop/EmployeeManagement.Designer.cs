namespace MalkiTailorShop
{
    partial class EmployeeManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeManagement));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnreport = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btnfinalpayment = new System.Windows.Forms.Button();
            this.btnMeasurement = new System.Windows.Forms.Button();
            this.Btnadvancedpayment = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btncutomer = new System.Windows.Forms.Button();

            // CRUD controls
            this.btnreport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();

            // Data grid
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            // Input fields
            this.txtemployeeid = new System.Windows.Forms.TextBox();
            this.txtemployeename = new System.Windows.Forms.TextBox();
            this.txtage = new System.Windows.Forms.TextBox();
            this.txttelephoneno1 = new System.Windows.Forms.TextBox();
            this.txttelephoneno2 = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtnicnumber = new System.Windows.Forms.TextBox();
            this.cmbstatusEmployee = new System.Windows.Forms.ComboBox();
            this.lblemployeeid = new System.Windows.Forms.Label();
            this.lblemployeename = new System.Windows.Forms.Label();
            this.lblage = new System.Windows.Forms.Label();
            this.lblnicnumber = new System.Windows.Forms.Label();
            this.lbltelephoneno1 = new System.Windows.Forms.Label();
            this.lbltelephoneno2 = new System.Windows.Forms.Label();
            this.lbladdress = new System.Windows.Forms.Label();
            this.lblstatus = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();

            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();

            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.btnreport);
            this.panel2.Controls.Add(this.btnEmployee);
            this.panel2.Controls.Add(this.pictureBox8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.Btnfinalpayment);
            this.panel2.Controls.Add(this.btnMeasurement);
            this.panel2.Controls.Add(this.Btnadvancedpayment);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.btnOrder);
            this.panel2.Controls.Add(this.btncutomer);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 763);
            this.panel2.TabIndex = 43;

            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(34, 689);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(236, 45);
            this.button3.TabIndex = 45;
            this.button3.Text = "Logout";
            this.button3.UseVisualStyleBackColor = true;

            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(16, 777);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(236, 45);
            this.button4.TabIndex = 44;
            this.button4.Text = "Logout";
            this.button4.UseVisualStyleBackColor = true;

            // 
            // btnreport
            // 
            this.btnreport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnreport.Location = new System.Drawing.Point(34, 602);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(236, 45);
            this.btnreport.TabIndex = 43;
            this.btnreport.Text = "📊 Report";
            this.btnreport.UseVisualStyleBackColor = true;

            // 
            // btnEmployee
            // 
            this.btnEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEmployee.Location = new System.Drawing.Point(34, 544);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(236, 45);
            this.btnEmployee.TabIndex = 42;
            this.btnEmployee.Text = "👥 Employee";
            this.btnEmployee.UseVisualStyleBackColor = true;

            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(92, 3);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(100, 100);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 40;
            this.pictureBox8.TabStop = false;

            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(66, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 23);
            this.label4.TabIndex = 41;
            this.label4.Text = "Welcome, User";

            // 
            // Btnfinalpayment
            // 
            this.Btnfinalpayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnfinalpayment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btnfinalpayment.Location = new System.Drawing.Point(34, 485);
            this.Btnfinalpayment.Name = "Btnfinalpayment";
            this.Btnfinalpayment.Size = new System.Drawing.Size(236, 37);
            this.Btnfinalpayment.TabIndex = 38;
            this.Btnfinalpayment.Text = "💰 Final Payment";
            this.Btnfinalpayment.UseVisualStyleBackColor = true;

            // 
            // btnMeasurement
            // 
            this.btnMeasurement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeasurement.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMeasurement.Location = new System.Drawing.Point(34, 347);
            this.btnMeasurement.Name = "btnMeasurement";
            this.btnMeasurement.Size = new System.Drawing.Size(236, 45);
            this.btnMeasurement.TabIndex = 36;
            this.btnMeasurement.Text = "📏 Measurement";
            this.btnMeasurement.UseVisualStyleBackColor = true;

            // 
            // Btnadvancedpayment
            // 
            this.Btnadvancedpayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnadvancedpayment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btnadvancedpayment.Location = new System.Drawing.Point(34, 413);
            this.Btnadvancedpayment.Name = "Btnadvancedpayment";
            this.Btnadvancedpayment.Size = new System.Drawing.Size(236, 38);
            this.Btnadvancedpayment.TabIndex = 37;
            this.Btnadvancedpayment.Text = "💵 Advance Payment";
            this.Btnadvancedpayment.UseVisualStyleBackColor = true;

            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 534);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 32;

            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(30, 147);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(236, 45);
            this.button5.TabIndex = 33;
            this.button5.Text = "🏠 Home";
            this.button5.UseVisualStyleBackColor = true;

            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOrder.Location = new System.Drawing.Point(30, 281);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(236, 45);
            this.btnOrder.TabIndex = 35;
            this.btnOrder.Text = "📦 Order";
            this.btnOrder.UseVisualStyleBackColor = true;

            // 
            // btncutomer
            // 
            this.btncutomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncutomer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btncutomer.Location = new System.Drawing.Point(30, 216);
            this.btncutomer.Name = "btncutomer";
            this.btncutomer.Size = new System.Drawing.Size(236, 45);
            this.btncutomer.TabIndex = 34;
            this.btncutomer.Text = "👤 Customer";
            this.btncutomer.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(400, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(437, 54);
            this.lblTitle.Text = "Employee Management";
            // 
            // btnadd
            // 
            this.btnadd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnadd.Location = new System.Drawing.Point(400, 350);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(120, 40);
            this.btnadd.Text = "➕ Add";
            this.btnadd.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(550, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 40);
            this.button1.Text = "🔄 Update";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(700, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 40);
            this.button2.Text = "🗑️ Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblemployeeid
            // 
            this.lblemployeeid.AutoSize = true;
            this.lblemployeeid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblemployeeid.Location = new System.Drawing.Point(400, 100);
            this.lblemployeeid.Name = "lblemployeeid";
            this.lblemployeeid.Text = "Employee ID";
            // 
            // txtemployeeid
            // 
            this.txtemployeeid.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtemployeeid.Location = new System.Drawing.Point(550, 100);
            this.txtemployeeid.Name = "txtemployeeid";
            this.txtemployeeid.Size = new System.Drawing.Size(200, 34);
            // 
            // lblemployeename
            // 
            this.lblemployeename.AutoSize = true;
            this.lblemployeename.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblemployeename.Location = new System.Drawing.Point(400, 150);
            this.lblemployeename.Name = "lblemployeename";
            this.lblemployeename.Text = "Full Name";
            // 
            // txtemployeename
            // 
            this.txtemployeename.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtemployeename.Location = new System.Drawing.Point(550, 150);
            this.txtemployeename.Name = "txtemployeename";
            this.txtemployeename.Size = new System.Drawing.Size(200, 34);
            // 
            // lblage
            // 
            this.lblage.AutoSize = true;
            this.lblage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblage.Location = new System.Drawing.Point(400, 200);
            this.lblage.Name = "lblage";
            this.lblage.Text = "Age";
            // 
            // txtage
            // 
            this.txtage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtage.Location = new System.Drawing.Point(550, 200);
            this.txtage.Name = "txtage";
            this.txtage.Size = new System.Drawing.Size(200, 34);
            // 
            // lblnicnumber
            // 
            this.lblnicnumber.AutoSize = true;
            this.lblnicnumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblnicnumber.Location = new System.Drawing.Point(850, 100);
            this.lblnicnumber.Name = "lblnicnumber";
            this.lblnicnumber.Text = "NIC Number";
            // 
            // txtnicnumber
            // 
            this.txtnicnumber.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtnicnumber.Location = new System.Drawing.Point(1000, 100);
            this.txtnicnumber.Name = "txtnicnumber";
            this.txtnicnumber.Size = new System.Drawing.Size(200, 34);
            // 
            // lbltelephoneno1
            // 
            this.lbltelephoneno1.AutoSize = true;
            this.lbltelephoneno1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbltelephoneno1.Location = new System.Drawing.Point(850, 150);
            this.lbltelephoneno1.Name = "lbltelephoneno1";
            this.lbltelephoneno1.Text = "Telephone 1";
            // 
            // txttelephoneno1
            // 
            this.txttelephoneno1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txttelephoneno1.Location = new System.Drawing.Point(1000, 150);
            this.txttelephoneno1.Name = "txttelephoneno1";
            this.txttelephoneno1.Size = new System.Drawing.Size(200, 34);
            // 
            // lbltelephoneno2
            // 
            this.lbltelephoneno2.AutoSize = true;
            this.lbltelephoneno2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbltelephoneno2.Location = new System.Drawing.Point(850, 200);
            this.lbltelephoneno2.Name = "lbltelephoneno2";
            this.lbltelephoneno2.Text = "Telephone 2";
            // 
            // txttelephoneno2
            // 
            this.txttelephoneno2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txttelephoneno2.Location = new System.Drawing.Point(1000, 200);
            this.txttelephoneno2.Name = "txttelephoneno2";
            this.txttelephoneno2.Size = new System.Drawing.Size(200, 34);
            // 
            // lbladdress
            // 
            this.lbladdress.AutoSize = true;
            this.lbladdress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbladdress.Location = new System.Drawing.Point(400, 250);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Text = "Home Address";
            // 
            // txtaddress
            // 
            this.txtaddress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtaddress.Location = new System.Drawing.Point(550, 250);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(650, 34);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblstatus.Location = new System.Drawing.Point(400, 300);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Text = "Status";
            // 
            // cmbstatusEmployee
            // 
            this.cmbstatusEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstatusEmployee.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbstatusEmployee.FormattingEnabled = true;
            this.cmbstatusEmployee.Items.AddRange(new object[] { "Active", "Inactive" });
            this.cmbstatusEmployee.Location = new System.Drawing.Point(550, 300);
            this.cmbstatusEmployee.Name = "cmbstatusEmployee";
            this.cmbstatusEmployee.Size = new System.Drawing.Size(200, 36);
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(325, 410);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(1140, 325);
            // 
            // EmployeeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.cmbstatusEmployee);
            this.Controls.Add(this.txtnicnumber);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.txttelephoneno2);
            this.Controls.Add(this.txttelephoneno1);
            this.Controls.Add(this.txtage);
            this.Controls.Add(this.txtemployeename);
            this.Controls.Add(this.txtemployeeid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblemployeeid);
            this.Controls.Add(this.lblemployeename);
            this.Controls.Add(this.lblage);
            this.Controls.Add(this.lblnicnumber);
            this.Controls.Add(this.lbltelephoneno1);
            this.Controls.Add(this.lbltelephoneno2);
            this.Controls.Add(this.lbladdress);
            this.Controls.Add(this.lblstatus);
            this.Name = "EmployeeManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeManagement";
            this.Load += new System.EventHandler(this.EmployeeManagement_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();

            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreport.FlatAppearance.BorderSize = 0;
            this.btnreport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployee.FlatAppearance.BorderSize = 0;
            this.btnEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnfinalpayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnfinalpayment.FlatAppearance.BorderSize = 0;
            this.Btnfinalpayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMeasurement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeasurement.FlatAppearance.BorderSize = 0;
            this.btnMeasurement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnadvancedpayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnadvancedpayment.FlatAppearance.BorderSize = 0;
            this.Btnadvancedpayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncutomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncutomer.FlatAppearance.BorderSize = 0;
            this.btncutomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreport.FlatAppearance.BorderSize = 0;
            this.btnreport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.FlatAppearance.BorderSize = 0;
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Button button4;
        internal System.Windows.Forms.Button btnreport;
        internal System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button Btnfinalpayment;
        internal System.Windows.Forms.Button btnMeasurement;
        internal System.Windows.Forms.Button Btnadvancedpayment;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Button button5;
        internal System.Windows.Forms.Button btnOrder;
        internal System.Windows.Forms.Button btncutomer;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button btnadd;
        internal System.Windows.Forms.TextBox txtemployeeid;
        internal System.Windows.Forms.TextBox txtemployeename;
        internal System.Windows.Forms.TextBox txtage;
        internal System.Windows.Forms.TextBox txttelephoneno1;
        internal System.Windows.Forms.TextBox txttelephoneno2;
        internal System.Windows.Forms.TextBox txtaddress;
        internal System.Windows.Forms.TextBox txtnicnumber;
        internal System.Windows.Forms.ComboBox cmbstatusEmployee;
        internal System.Windows.Forms.DataGridView dgvEmployees;
        internal System.Windows.Forms.Label lblemployeeid;
        internal System.Windows.Forms.Label lblemployeename;
        internal System.Windows.Forms.Label lblage;
        internal System.Windows.Forms.Label lblnicnumber;
        internal System.Windows.Forms.Label lbltelephoneno1;
        internal System.Windows.Forms.Label lbltelephoneno2;
        internal System.Windows.Forms.Label lbladdress;
        internal System.Windows.Forms.Label lblstatus;
        internal System.Windows.Forms.Label lblTitle;
    }
}







