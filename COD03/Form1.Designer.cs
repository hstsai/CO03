namespace COD03
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.txtId = new System.Windows.Forms.TextBox();
      this.txtBasesalary = new System.Windows.Forms.TextBox();
      this.txtName = new System.Windows.Forms.TextBox();
      this.txtBonus = new System.Windows.Forms.TextBox();
      this.txtDeduct = new System.Windows.Forms.TextBox();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnUpdate = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.lblCount = new System.Windows.Forms.Label();
      this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
      this.btnClean = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
      this.button2 = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label6 = new System.Windows.Forms.Label();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.label1.Location = new System.Drawing.Point(20, 33);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(80, 18);
      this.label1.TabIndex = 0;
      this.label1.Text = "員工編號";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.label2.Location = new System.Drawing.Point(20, 71);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(44, 18);
      this.label2.TabIndex = 0;
      this.label2.Text = "本俸";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.label3.Location = new System.Drawing.Point(176, 28);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(44, 18);
      this.label3.TabIndex = 0;
      this.label3.Text = "姓名";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.label4.Location = new System.Drawing.Point(176, 71);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(44, 18);
      this.label4.TabIndex = 0;
      this.label4.Text = "獎金";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.label5.Location = new System.Drawing.Point(310, 71);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(44, 18);
      this.label5.TabIndex = 0;
      this.label5.Text = "扣款";
      // 
      // txtId
      // 
      this.txtId.Enabled = false;
      this.txtId.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.txtId.Location = new System.Drawing.Point(79, 25);
      this.txtId.MaxLength = 5;
      this.txtId.Name = "txtId";
      this.txtId.Size = new System.Drawing.Size(80, 29);
      this.txtId.TabIndex = 0;
      this.txtId.Validating += new System.ComponentModel.CancelEventHandler(this.txtId_Validating);
      // 
      // txtBasesalary
      // 
      this.txtBasesalary.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.txtBasesalary.Location = new System.Drawing.Point(79, 68);
      this.txtBasesalary.Name = "txtBasesalary";
      this.txtBasesalary.Size = new System.Drawing.Size(80, 29);
      this.txtBasesalary.TabIndex = 2;
      this.txtBasesalary.Validating += new System.ComponentModel.CancelEventHandler(this.txtBasesalary_Validating);
      // 
      // txtName
      // 
      this.txtName.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.txtName.Location = new System.Drawing.Point(211, 23);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(80, 29);
      this.txtName.TabIndex = 1;
      this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
      // 
      // txtBonus
      // 
      this.txtBonus.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.txtBonus.Location = new System.Drawing.Point(211, 66);
      this.txtBonus.Name = "txtBonus";
      this.txtBonus.Size = new System.Drawing.Size(80, 29);
      this.txtBonus.TabIndex = 3;
      this.txtBonus.Validating += new System.ComponentModel.CancelEventHandler(this.txtBonus_Validating);
      // 
      // txtDeduct
      // 
      this.txtDeduct.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.txtDeduct.Location = new System.Drawing.Point(345, 66);
      this.txtDeduct.Name = "txtDeduct";
      this.txtDeduct.Size = new System.Drawing.Size(80, 29);
      this.txtDeduct.TabIndex = 4;
      this.txtDeduct.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeduct_Validating);
      // 
      // btnAdd
      // 
      this.btnAdd.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.btnAdd.Location = new System.Drawing.Point(110, 118);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(56, 23);
      this.btnAdd.TabIndex = 6;
      this.btnAdd.Text = "新增";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnUpdate
      // 
      this.btnUpdate.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.btnUpdate.Location = new System.Drawing.Point(193, 118);
      this.btnUpdate.Name = "btnUpdate";
      this.btnUpdate.Size = new System.Drawing.Size(56, 23);
      this.btnUpdate.TabIndex = 7;
      this.btnUpdate.Text = "更新";
      this.btnUpdate.UseVisualStyleBackColor = true;
      this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.btnDelete.Location = new System.Drawing.Point(276, 118);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(56, 23);
      this.btnDelete.TabIndex = 8;
      this.btnDelete.Text = "刪除";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // lblCount
      // 
      this.lblCount.AutoSize = true;
      this.lblCount.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.lblCount.Location = new System.Drawing.Point(20, 167);
      this.lblCount.Name = "lblCount";
      this.lblCount.Size = new System.Drawing.Size(62, 18);
      this.lblCount.TabIndex = 3;
      this.lblCount.Text = "資料錄";
      // 
      // hScrollBar1
      // 
      this.hScrollBar1.LargeChange = 1;
      this.hScrollBar1.Location = new System.Drawing.Point(79, 162);
      this.hScrollBar1.Name = "hScrollBar1";
      this.hScrollBar1.Size = new System.Drawing.Size(170, 23);
      this.hScrollBar1.TabIndex = 4;
      this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
      // 
      // btnClean
      // 
      this.btnClean.CausesValidation = false;
      this.btnClean.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.btnClean.Location = new System.Drawing.Point(27, 118);
      this.btnClean.Name = "btnClean";
      this.btnClean.Size = new System.Drawing.Size(56, 23);
      this.btnClean.TabIndex = 5;
      this.btnClean.Text = "清除";
      this.btnClean.UseVisualStyleBackColor = true;
      this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.button1.Location = new System.Drawing.Point(313, 162);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(142, 30);
      this.button1.TabIndex = 10;
      this.button1.Text = "顯示薪資統計";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // bindingSource1
      // 
      this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
      // 
      // button2
      // 
      this.button2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.button2.Location = new System.Drawing.Point(359, 118);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(95, 23);
      this.button2.TabIndex = 11;
      this.button2.Text = "匯入資料";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.btnShow_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(345, 4);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(80, 50);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 12;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.label6.Location = new System.Drawing.Point(310, 28);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(44, 18);
      this.label6.TabIndex = 13;
      this.label6.Text = "相片";
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.Filter = "JPG 檔案|*.jpg";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(432, 21);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(50, 34);
      this.textBox1.TabIndex = 14;
      this.textBox1.Visible = false;
      // 
      // openFileDialog2
      // 
      this.openFileDialog2.FileName = "*";
      this.openFileDialog2.Filter = "Excel 檔案|*.xls;*.xlsx";
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(27, 207);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(427, 29);
      this.progressBar1.Step = 1;
      this.progressBar1.TabIndex = 15;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(485, 248);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.hScrollBar1);
      this.Controls.Add(this.lblCount);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnUpdate);
      this.Controls.Add(this.btnClean);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.txtDeduct);
      this.Controls.Add(this.txtBonus);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.txtBasesalary);
      this.Controls.Add(this.txtId);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Form1";
      this.Text = "薪資發放";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtBasesalary;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBonus;
        private System.Windows.Forms.TextBox txtDeduct;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button btnClean;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.BindingSource bindingSource1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.OpenFileDialog openFileDialog2;
    public System.Windows.Forms.ProgressBar progressBar1;
  }
}

