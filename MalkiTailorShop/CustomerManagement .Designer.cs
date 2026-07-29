using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MalkiTailorShop
{
    partial class CustomerManagement
    {
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerManagement));
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.txttelephoneno1 = new System.Windows.Forms.TextBox();
            this.txtcustomername = new System.Windows.Forms.TextBox();
            this.txttelephoneno2 = new System.Windows.Forms.TextBox();
            this.txtcustomerid = new System.Windows.Forms.TextBox();
            this.lbltelephoneno = new System.Windows.Forms.Label();
            this.lblcustomername = new System.Windows.Forms.Label();
            this.lblcustomerid = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblcustomermanagement = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.btnreport = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btnfinalpayment = new System.Windows.Forms.Button();
            this.btnMeasurement = new System.Windows.Forms.Button();
            this.Btnadvancedpayment = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btncutomer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(344, 210);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 65;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(344, 157);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 64;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(344, 107);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 63;
            this.pictureBox2.TabStop = false;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.Black;
            this.btnsave.Location = new System.Drawing.Point(593, 292);
            this.btnsave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(119, 45);
            this.btnsave.TabIndex = 62;
            this.btnsave.Text = "💾 Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnupdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnupdate.FlatAppearance.BorderSize = 0;
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.ForeColor = System.Drawing.Color.Black;
            this.btnupdate.Location = new System.Drawing.Point(454, 292);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(122, 45);
            this.btnupdate.TabIndex = 61;
            this.btnupdate.Text = "🔄 Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Crimson;
            this.btndelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.Black;
            this.btndelete.Location = new System.Drawing.Point(731, 292);
            this.btndelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(127, 45);
            this.btndelete.TabIndex = 60;
            this.btndelete.Text = "🗑️ Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.MediumPurple;
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.FlatAppearance.BorderSize = 0;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.Color.Black;
            this.btnadd.Location = new System.Drawing.Point(336, 292);
            this.btnadd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(104, 45);
            this.btnadd.TabIndex = 59;
            this.btnadd.Text = "➕ Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txttelephoneno1
            // 
            this.txttelephoneno1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttelephoneno1.Location = new System.Drawing.Point(593, 210);
            this.txttelephoneno1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txttelephoneno1.Name = "txttelephoneno1";
            this.txttelephoneno1.Size = new System.Drawing.Size(223, 32);
            this.txttelephoneno1.TabIndex = 58;
            // 
            // txtcustomername
            // 
            this.txtcustomername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcustomername.Location = new System.Drawing.Point(593, 157);
            this.txtcustomername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcustomername.Name = "txtcustomername";
            this.txtcustomername.Size = new System.Drawing.Size(223, 32);
            this.txtcustomername.TabIndex = 57;
            // 
            // txttelephoneno2
            // 
            this.txttelephoneno2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttelephoneno2.Location = new System.Drawing.Point(593, 235);
            this.txttelephoneno2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txttelephoneno2.Name = "txttelephoneno2";
            this.txttelephoneno2.Size = new System.Drawing.Size(223, 32);
            this.txttelephoneno2.TabIndex = 56;
            this.txttelephoneno2.TextChanged += new System.EventHandler(this.txttelephoneno2_TextChanged);
            // 
            // txtcustomerid
            // 
            this.txtcustomerid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcustomerid.Location = new System.Drawing.Point(593, 109);
            this.txtcustomerid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcustomerid.Name = "txtcustomerid";
            this.txtcustomerid.Size = new System.Drawing.Size(223, 32);
            this.txtcustomerid.TabIndex = 55;
            // 
            // lbltelephoneno
            // 
            this.lbltelephoneno.AutoSize = true;
            this.lbltelephoneno.BackColor = System.Drawing.Color.Transparent;
            this.lbltelephoneno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltelephoneno.Location = new System.Drawing.Point(393, 210);
            this.lbltelephoneno.Name = "lbltelephoneno";
            this.lbltelephoneno.Size = new System.Drawing.Size(143, 28);
            this.lbltelephoneno.TabIndex = 54;
            this.lbltelephoneno.Text = "Telephone No";
            // 
            // lblcustomername
            // 
            this.lblcustomername.AutoSize = true;
            this.lblcustomername.BackColor = System.Drawing.Color.Transparent;
            this.lblcustomername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcustomername.Location = new System.Drawing.Point(388, 157);
            this.lblcustomername.Name = "lblcustomername";
            this.lblcustomername.Size = new System.Drawing.Size(164, 28);
            this.lblcustomername.TabIndex = 53;
            this.lblcustomername.Text = "Customer Name";
            // 
            // lblcustomerid
            // 
            this.lblcustomerid.AutoSize = true;
            this.lblcustomerid.BackColor = System.Drawing.Color.Transparent;
            this.lblcustomerid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcustomerid.Location = new System.Drawing.Point(388, 107);
            this.lblcustomerid.Name = "lblcustomerid";
            this.lblcustomerid.Size = new System.Drawing.Size(129, 28);
            this.lblcustomerid.TabIndex = 52;
            this.lblcustomerid.Text = "Customer ID";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(460, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // lblcustomermanagement
            // 
            this.lblcustomermanagement.AutoSize = true;
            this.lblcustomermanagement.BackColor = System.Drawing.Color.Transparent;
            this.lblcustomermanagement.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcustomermanagement.Location = new System.Drawing.Point(515, 47);
            this.lblcustomermanagement.Name = "lblcustomermanagement";
            this.lblcustomermanagement.Size = new System.Drawing.Size(375, 45);
            this.lblcustomermanagement.TabIndex = 50;
            this.lblcustomermanagement.Text = "Customer Management";
            this.lblcustomermanagement.Click += new System.EventHandler(this.lblcustomermanagement_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.btnreport);
            this.panel2.Controls.Add(this.btnEmployee);
            this.panel2.Controls.Add(this.pictureBox8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.Btnfinalpayment);
            this.panel2.Controls.Add(this.btnMeasurement);
            this.panel2.Controls.Add(this.Btnadvancedpayment);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.btnOrder);
            this.panel2.Controls.Add(this.btncutomer);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 763);
            this.panel2.TabIndex = 126;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(16, 777);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 24);
            this.button1.TabIndex = 44;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 534);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 32;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(336, 333);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.Size = new System.Drawing.Size(522, 128);
            this.dgvCustomers.TabIndex = 23;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(36, 706);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(236, 45);
            this.button3.TabIndex = 56;
            this.button3.Text = "Logout";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnreport
            // 
            this.btnreport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnreport.FlatAppearance.BorderSize = 0;
            this.btnreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnreport.Location = new System.Drawing.Point(36, 619);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(236, 45);
            this.btnreport.TabIndex = 55;
            this.btnreport.Text = "📊 Report";
            this.btnreport.UseVisualStyleBackColor = true;
            // 
            // btnEmployee
            // 
            this.btnEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployee.FlatAppearance.BorderSize = 0;
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEmployee.Location = new System.Drawing.Point(36, 561);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(236, 45);
            this.btnEmployee.TabIndex = 54;
            this.btnEmployee.Text = "👥 Employee";
            this.btnEmployee.UseVisualStyleBackColor = true;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(94, 20);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(100, 100);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 52;
            this.pictureBox8.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(68, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 23);
            this.label4.TabIndex = 53;
            this.label4.Text = "Welcome, User";
            // 
            // Btnfinalpayment
            // 
            this.Btnfinalpayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnfinalpayment.FlatAppearance.BorderSize = 0;
            this.Btnfinalpayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnfinalpayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnfinalpayment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btnfinalpayment.Location = new System.Drawing.Point(36, 502);
            this.Btnfinalpayment.Name = "Btnfinalpayment";
            this.Btnfinalpayment.Size = new System.Drawing.Size(236, 37);
            this.Btnfinalpayment.TabIndex = 51;
            this.Btnfinalpayment.Text = "💰 Final Payment";
            this.Btnfinalpayment.UseVisualStyleBackColor = true;
            // 
            // btnMeasurement
            // 
            this.btnMeasurement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMeasurement.FlatAppearance.BorderSize = 0;
            this.btnMeasurement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeasurement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeasurement.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMeasurement.Location = new System.Drawing.Point(36, 364);
            this.btnMeasurement.Name = "btnMeasurement";
            this.btnMeasurement.Size = new System.Drawing.Size(236, 45);
            this.btnMeasurement.TabIndex = 49;
            this.btnMeasurement.Text = "📏 Measurement";
            this.btnMeasurement.UseVisualStyleBackColor = true;
            // 
            // Btnadvancedpayment
            // 
            this.Btnadvancedpayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnadvancedpayment.FlatAppearance.BorderSize = 0;
            this.Btnadvancedpayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnadvancedpayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnadvancedpayment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btnadvancedpayment.Location = new System.Drawing.Point(36, 430);
            this.Btnadvancedpayment.Name = "Btnadvancedpayment";
            this.Btnadvancedpayment.Size = new System.Drawing.Size(236, 38);
            this.Btnadvancedpayment.TabIndex = 50;
            this.Btnadvancedpayment.Text = "💵 Advance Payment";
            this.Btnadvancedpayment.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(32, 164);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(236, 45);
            this.button5.TabIndex = 46;
            this.button5.Text = "🏠 Home";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnOrder
            // 
            this.btnOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOrder.Location = new System.Drawing.Point(32, 298);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(236, 45);
            this.btnOrder.TabIndex = 48;
            this.btnOrder.Text = "📦 Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            // 
            // btncutomer
            // 
            this.btncutomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncutomer.FlatAppearance.BorderSize = 0;
            this.btncutomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncutomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncutomer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btncutomer.Location = new System.Drawing.Point(32, 233);
            this.btncutomer.Name = "btncutomer";
            this.btncutomer.Size = new System.Drawing.Size(236, 45);
            this.btncutomer.TabIndex = 47;
            this.btncutomer.Text = "👤 Customer";
            this.btncutomer.UseVisualStyleBackColor = true;
            // 
            // CustomerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1573, 753);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txttelephoneno1);
            this.Controls.Add(this.txtcustomername);
            this.Controls.Add(this.txttelephoneno2);
            this.Controls.Add(this.txtcustomerid);
            this.Controls.Add(this.lbltelephoneno);
            this.Controls.Add(this.lblcustomername);
            this.Controls.Add(this.lblcustomerid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblcustomermanagement);
            this.Name = "CustomerManagement";
            this.Text = "CustomerManagement";
            this.Load += new System.EventHandler(this.CustomerManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.Button btnsave;
        internal System.Windows.Forms.Button btnupdate;
        internal System.Windows.Forms.Button btndelete;
        internal System.Windows.Forms.Button btnadd;
        internal System.Windows.Forms.TextBox txttelephoneno1;
        internal System.Windows.Forms.TextBox txtcustomername;
        internal System.Windows.Forms.TextBox txttelephoneno2;
        internal System.Windows.Forms.TextBox txtcustomerid;
        internal System.Windows.Forms.Label lbltelephoneno;
        internal System.Windows.Forms.Label lblcustomername;
        internal System.Windows.Forms.Label lblcustomerid;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label lblcustomermanagement;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.DataGridView dgvCustomers;
        internal Button button3;
        internal Button btnreport;
        internal Button btnEmployee;
        private PictureBox pictureBox8;
        private Label label4;
        internal Button Btnfinalpayment;
        internal Button btnMeasurement;
        internal Button Btnadvancedpayment;
        internal Button button5;
        internal Button btnOrder;
        internal Button btncutomer;
    }
}











