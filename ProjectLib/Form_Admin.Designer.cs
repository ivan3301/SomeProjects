
namespace ProjectLib
{
    partial class Form_Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Admin));
            this.dgvAdmin = new System.Windows.Forms.DataGridView();
            this.lbl_login = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txtB_login = new System.Windows.Forms.TextBox();
            this.txtB_password = new System.Windows.Forms.TextBox();
            this.txtB_name = new System.Windows.Forms.TextBox();
            this.btn_changeuser = new System.Windows.Forms.Button();
            this.btn_deluser = new System.Windows.Forms.Button();
            this.btn_adduser = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAdmin
            // 
            this.dgvAdmin.AllowUserToAddRows = false;
            this.dgvAdmin.AllowUserToDeleteRows = false;
            this.dgvAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmin.Location = new System.Drawing.Point(2, 2);
            this.dgvAdmin.Name = "dgvAdmin";
            this.dgvAdmin.ReadOnly = true;
            this.dgvAdmin.RowHeadersWidth = 51;
            this.dgvAdmin.RowTemplate.Height = 24;
            this.dgvAdmin.Size = new System.Drawing.Size(398, 261);
            this.dgvAdmin.TabIndex = 0;
            this.dgvAdmin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_login.Location = new System.Drawing.Point(433, 16);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(68, 25);
            this.lbl_login.TabIndex = 1;
            this.lbl_login.Text = "Логин";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_password.Location = new System.Drawing.Point(421, 52);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(80, 25);
            this.lbl_password.TabIndex = 2;
            this.lbl_password.Text = "Пароль";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_name.Location = new System.Drawing.Point(426, 89);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(75, 25);
            this.lbl_name.TabIndex = 3;
            this.lbl_name.Text = "Ф.И.О.";
            // 
            // txtB_login
            // 
            this.txtB_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtB_login.Location = new System.Drawing.Point(507, 19);
            this.txtB_login.Name = "txtB_login";
            this.txtB_login.Size = new System.Drawing.Size(100, 24);
            this.txtB_login.TabIndex = 4;
            // 
            // txtB_password
            // 
            this.txtB_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtB_password.Location = new System.Drawing.Point(507, 55);
            this.txtB_password.Name = "txtB_password";
            this.txtB_password.Size = new System.Drawing.Size(100, 24);
            this.txtB_password.TabIndex = 5;
            // 
            // txtB_name
            // 
            this.txtB_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtB_name.Location = new System.Drawing.Point(507, 92);
            this.txtB_name.Name = "txtB_name";
            this.txtB_name.Size = new System.Drawing.Size(100, 24);
            this.txtB_name.TabIndex = 6;
            // 
            // btn_changeuser
            // 
            this.btn_changeuser.FlatAppearance.BorderSize = 0;
            this.btn_changeuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_changeuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_changeuser.Image = ((System.Drawing.Image)(resources.GetObject("btn_changeuser.Image")));
            this.btn_changeuser.Location = new System.Drawing.Point(524, 121);
            this.btn_changeuser.Name = "btn_changeuser";
            this.btn_changeuser.Size = new System.Drawing.Size(64, 64);
            this.btn_changeuser.TabIndex = 7;
            this.btn_changeuser.UseVisualStyleBackColor = true;
            this.btn_changeuser.Click += new System.EventHandler(this.btn_changeuser_Click);
            // 
            // btn_deluser
            // 
            this.btn_deluser.FlatAppearance.BorderSize = 0;
            this.btn_deluser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deluser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_deluser.Image = ((System.Drawing.Image)(resources.GetObject("btn_deluser.Image")));
            this.btn_deluser.Location = new System.Drawing.Point(524, 191);
            this.btn_deluser.Name = "btn_deluser";
            this.btn_deluser.Size = new System.Drawing.Size(64, 64);
            this.btn_deluser.TabIndex = 8;
            this.btn_deluser.UseVisualStyleBackColor = true;
            this.btn_deluser.Click += new System.EventHandler(this.btn_deluser_Click);
            // 
            // btn_adduser
            // 
            this.btn_adduser.FlatAppearance.BorderSize = 0;
            this.btn_adduser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adduser.Image = ((System.Drawing.Image)(resources.GetObject("btn_adduser.Image")));
            this.btn_adduser.Location = new System.Drawing.Point(454, 121);
            this.btn_adduser.Name = "btn_adduser";
            this.btn_adduser.Size = new System.Drawing.Size(64, 64);
            this.btn_adduser.TabIndex = 9;
            this.btn_adduser.UseVisualStyleBackColor = true;
            this.btn_adduser.Click += new System.EventHandler(this.btn_adduser_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.FlatAppearance.BorderSize = 0;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Image = ((System.Drawing.Image)(resources.GetObject("btn_clear.Image")));
            this.btn_clear.Location = new System.Drawing.Point(454, 191);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(64, 64);
            this.btn_clear.TabIndex = 10;
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Form_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 266);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_adduser);
            this.Controls.Add(this.btn_deluser);
            this.Controls.Add(this.btn_changeuser);
            this.Controls.Add(this.txtB_name);
            this.Controls.Add(this.txtB_password);
            this.Controls.Add(this.txtB_login);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_login);
            this.Controls.Add(this.dgvAdmin);
            this.Name = "Form_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель администратора";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Admin_FormClosing);
            this.Load += new System.EventHandler(this.Form_Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAdmin;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txtB_login;
        private System.Windows.Forms.TextBox txtB_password;
        private System.Windows.Forms.TextBox txtB_name;
        private System.Windows.Forms.Button btn_changeuser;
        private System.Windows.Forms.Button btn_deluser;
        private System.Windows.Forms.Button btn_adduser;
        private System.Windows.Forms.Button btn_clear;
    }
}