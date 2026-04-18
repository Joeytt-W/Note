namespace WinFormMVVM
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPeoples = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddPeople = new System.Windows.Forms.Button();
            this.PeopleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnDeletePeople = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeoples)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPeoples
            // 
            this.dgvPeoples.AllowUserToAddRows = false;
            this.dgvPeoples.AllowUserToDeleteRows = false;
            this.dgvPeoples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeoples.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PeopleName,
            this.Age,
            this.Address});
            this.dgvPeoples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeoples.Location = new System.Drawing.Point(0, 68);
            this.dgvPeoples.Name = "dgvPeoples";
            this.dgvPeoples.RowHeadersVisible = false;
            this.dgvPeoples.RowTemplate.Height = 23;
            this.dgvPeoples.Size = new System.Drawing.Size(999, 430);
            this.dgvPeoples.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeletePeople);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.btnAddPeople);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 68);
            this.panel1.TabIndex = 1;
            // 
            // btnAddPeople
            // 
            this.btnAddPeople.Location = new System.Drawing.Point(885, 21);
            this.btnAddPeople.Name = "btnAddPeople";
            this.btnAddPeople.Size = new System.Drawing.Size(75, 23);
            this.btnAddPeople.TabIndex = 0;
            this.btnAddPeople.Text = "添加";
            this.btnAddPeople.UseVisualStyleBackColor = true;
            this.btnAddPeople.Click += new System.EventHandler(this.btnAddPeople_Click);
            // 
            // PeopleName
            // 
            this.PeopleName.DataPropertyName = "Name";
            this.PeopleName.HeaderText = "姓名";
            this.PeopleName.Name = "PeopleName";
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "年龄";
            this.Age.Name = "Age";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "地址";
            this.Address.Name = "Address";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(724, 21);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "展示";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnDeletePeople
            // 
            this.btnDeletePeople.Location = new System.Drawing.Point(804, 21);
            this.btnDeletePeople.Name = "btnDeletePeople";
            this.btnDeletePeople.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePeople.TabIndex = 2;
            this.btnDeletePeople.Text = "删除";
            this.btnDeletePeople.UseVisualStyleBackColor = true;
            this.btnDeletePeople.Click += new System.EventHandler(this.btnDeletePeople_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 498);
            this.Controls.Add(this.dgvPeoples);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeoples)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPeoples;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeopleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnDeletePeople;
    }
}

