
namespace ProjectLib
{
    partial class Form_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.dgvBook = new System.Windows.Forms.DataGridView();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_view = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radBtn_aut = new System.Windows.Forms.RadioButton();
            this.radBtn_title = new System.Windows.Forms.RadioButton();
            this.radBtn_keyword = new System.Windows.Forms.RadioButton();
            this.txtBox_search = new System.Windows.Forms.TextBox();
            this.btnUpdGrid = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBook
            // 
            this.dgvBook.AllowUserToAddRows = false;
            this.dgvBook.AllowUserToDeleteRows = false;
            this.dgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBook.Location = new System.Drawing.Point(0, 0);
            this.dgvBook.Name = "dgvBook";
            this.dgvBook.ReadOnly = true;
            this.dgvBook.RowHeadersWidth = 51;
            this.dgvBook.RowTemplate.Height = 24;
            this.dgvBook.Size = new System.Drawing.Size(829, 292);
            this.dgvBook.TabIndex = 0;
            this.dgvBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBook_CellClick);
            // 
            // btn_add
            // 
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.Image")));
            this.btn_add.Location = new System.Drawing.Point(133, 302);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(64, 64);
            this.btn_add.TabIndex = 1;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_del
            // 
            this.btn_del.FlatAppearance.BorderSize = 0;
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_del.Image = ((System.Drawing.Image)(resources.GetObject("btn_del.Image")));
            this.btn_del.Location = new System.Drawing.Point(203, 372);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(64, 64);
            this.btn_del.TabIndex = 2;
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.FlatAppearance.BorderSize = 0;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit.Image")));
            this.btn_edit.Location = new System.Drawing.Point(133, 372);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(64, 64);
            this.btn_edit.TabIndex = 3;
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_view
            // 
            this.btn_view.FlatAppearance.BorderSize = 0;
            this.btn_view.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view.Image = ((System.Drawing.Image)(resources.GetObject("btn_view.Image")));
            this.btn_view.Location = new System.Drawing.Point(203, 302);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(64, 64);
            this.btn_view.TabIndex = 4;
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(390, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Поиск издания:";
            // 
            // radBtn_aut
            // 
            this.radBtn_aut.AutoSize = true;
            this.radBtn_aut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radBtn_aut.Location = new System.Drawing.Point(394, 327);
            this.radBtn_aut.Name = "radBtn_aut";
            this.radBtn_aut.Size = new System.Drawing.Size(332, 24);
            this.radBtn_aut.TabIndex = 9;
            this.radBtn_aut.TabStop = true;
            this.radBtn_aut.Text = "По первому автору (Фамилия, И. О.)";
            this.radBtn_aut.UseVisualStyleBackColor = true;
            // 
            // radBtn_title
            // 
            this.radBtn_title.AutoSize = true;
            this.radBtn_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radBtn_title.Location = new System.Drawing.Point(394, 354);
            this.radBtn_title.Name = "radBtn_title";
            this.radBtn_title.Size = new System.Drawing.Size(138, 24);
            this.radBtn_title.TabIndex = 10;
            this.radBtn_title.TabStop = true;
            this.radBtn_title.Text = "По заглавию";
            this.radBtn_title.UseVisualStyleBackColor = true;
            // 
            // radBtn_keyword
            // 
            this.radBtn_keyword.AutoSize = true;
            this.radBtn_keyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radBtn_keyword.Location = new System.Drawing.Point(394, 382);
            this.radBtn_keyword.Name = "radBtn_keyword";
            this.radBtn_keyword.Size = new System.Drawing.Size(210, 24);
            this.radBtn_keyword.TabIndex = 11;
            this.radBtn_keyword.TabStop = true;
            this.radBtn_keyword.Text = "По ключевым словам";
            this.radBtn_keyword.UseVisualStyleBackColor = true;
            // 
            // txtBox_search
            // 
            this.txtBox_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_search.Location = new System.Drawing.Point(394, 412);
            this.txtBox_search.Name = "txtBox_search";
            this.txtBox_search.Size = new System.Drawing.Size(260, 27);
            this.txtBox_search.TabIndex = 12;
            this.txtBox_search.TextChanged += new System.EventHandler(this.txtBox_search_TextChanged);
            // 
            // btnUpdGrid
            // 
            this.btnUpdGrid.FlatAppearance.BorderSize = 0;
            this.btnUpdGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdGrid.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdGrid.Image")));
            this.btnUpdGrid.Location = new System.Drawing.Point(774, 298);
            this.btnUpdGrid.Name = "btnUpdGrid";
            this.btnUpdGrid.Size = new System.Drawing.Size(49, 49);
            this.btnUpdGrid.TabIndex = 13;
            this.btnUpdGrid.UseVisualStyleBackColor = true;
            this.btnUpdGrid.Click += new System.EventHandler(this.btnUpdGrid_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 454);
            this.Controls.Add(this.btnUpdGrid);
            this.Controls.Add(this.txtBox_search);
            this.Controls.Add(this.radBtn_keyword);
            this.Controls.Add(this.radBtn_title);
            this.Controls.Add(this.radBtn_aut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.dgvBook);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список изданий";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBook;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radBtn_aut;
        private System.Windows.Forms.RadioButton radBtn_title;
        private System.Windows.Forms.RadioButton radBtn_keyword;
        private System.Windows.Forms.TextBox txtBox_search;
        private System.Windows.Forms.Button btnUpdGrid;
        private System.Windows.Forms.ImageList imageList1;
    }
}