using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace COD03
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    // 表單載入
    private void Form1_Load(object sender, EventArgs e)
    {
      using (var testDB = new TestDBEntities()) // 建立TestDB物件
      {
        // 篩選未停用員工
        var ds = from s in testDB.Salary 
                 where s.status == false
                 select s;
        bindingSource1.DataSource = ds.ToList(); // 資料繫結Salary
      }

      hScrollBar1.Maximum = bindingSource1.Count; // 設定hScrollBar1最大值為資料錄筆數
      if (hScrollBar1.Maximum > 0)
      {
        txtId.Enabled = false; // 取消txtId輸入
        btnAdd.Enabled = false; // 取消新增鈕
        hScrollBar1.Minimum = 1; // 設定hScrollBar1最小值
      }
      else
      {
        hScrollBar1.Minimum = 0; // 無資料錄
        MessageBox.Show("無資料!");

        btnDelete.Enabled = false; // 取消刪除鈕
        btnUpdate.Enabled = false; // 取消更新鈕
      }
      hScrollBar1.Value = hScrollBar1.Minimum; // 初始顯示為最小值
      lblCount.Text = hScrollBar1.Value + "/" + hScrollBar1.Maximum; // 顯示資料錄筆數
    }

    // 清除按鈕
    private void btnClean_Click(object sender, EventArgs e)
    {
      // 清除輸入控制項
      txtId.Text = "";
      txtName.Text = "";
      txtBasesalary.Text = "";
      txtBonus.Text = "";
      txtDeduct.Text = "";

      txtId.Enabled = true; // 啟用txtId輸入
      btnAdd.Enabled = true; // 啟用新增鈕
      btnDelete.Enabled = false; // 取消刪除鈕
      btnUpdate.Enabled = false; // 取消更新鈕
    }

    // 新增按鈕
    private void btnAdd_Click(object sender, EventArgs e)
    {
      // 建立Salary資料物件
      var salary = new Salary(); 
      salary.Id = txtId.Text;
      salary.name = txtName.Text;
      salary.basesalary = Convert.ToInt32(txtBasesalary.Text);
      salary.bonus = Convert.ToInt32(txtBonus.Text);
      salary.deduct = Convert.ToInt32(txtDeduct.Text);
      salary.subtotal = salary.basesalary + salary.bonus - salary.deduct; // 小計
      salary.status = false; // 未停用
      salary.photo = textBox1.Text; // 照片檔名

      using (var testDB = new TestDBEntities()) // 建立TestDB物件
      {
        testDB.Salary.Add(salary); // 加入testDB
        testDB.SaveChanges(); // 寫入資料庫

        // 篩選未停用員工
        var ds = from s in testDB.Salary 
                 where s.status == false
                 select s;
        bindingSource1.DataSource = ds.ToList(); // 資料繫結Salary
      }
      hScrollBar1.Maximum = bindingSource1.Count; // 設定hScrollBar1最大值為資料錄筆數
      hScrollBar1.Value = bindingSource1.Position + 1; // 設定顯示為目前資料錄
      lblCount.Text = hScrollBar1.Value + "/" + hScrollBar1.Maximum; // 顯示資料錄筆數
      MessageBox.Show("新增一筆資料!");

      txtId.Enabled = false; // 取消輸入Id
      btnAdd.Enabled = false; // 取消新增鈕
      btnDelete.Enabled = true; // 啟用刪除鈕
      btnUpdate.Enabled = true; // 啟用更新鈕
    }

    // 更新按鈕
    private void btnUpdate_Click(object sender, EventArgs e)
    {
      using (var testDB = new TestDBEntities()) // 建立TestDB物件
      {
        // 更新資料
        var salary = testDB.Salary.Find(txtId.Text); // 查找目前資料錄
        salary.name = txtName.Text;
        salary.basesalary = Convert.ToInt32(txtBasesalary.Text);
        salary.bonus = Convert.ToInt32(txtBonus.Text);
        salary.deduct = Convert.ToInt32(txtDeduct.Text);
        salary.subtotal = salary.basesalary + salary.bonus - salary.deduct; // 小計
        salary.photo = textBox1.Text; // 照片檔名

        testDB.SaveChanges(); // 寫入資料庫

        // 篩選未停用員工
        var ds = from s in testDB.Salary 
                 where s.status == false
                 select s;
        bindingSource1.DataSource = ds.ToList(); // 資料繫結Salary
      }

      MessageBox.Show("資料已更新!");
    }

    // 刪除按鈕
    private void btnDelete_Click(object sender, EventArgs e)
    {
      // 刪除資料
      if (MessageBox.Show("確定刪除?", "刪除資料", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) // 詢問是否刪除?
      {
        using (var testDB = new TestDBEntities()) // 建立TestDB物件
        {
          var salary = testDB.Salary.Find(txtId.Text); // 查找目前資料錄
          salary.status = true; // 停用

          testDB.SaveChanges(); // 寫入資料庫

          // 篩選未停用員工
          var ds = from s in testDB.Salary 
                   where s.status == false
                   select s;
          bindingSource1.DataSource = ds.ToList(); // 資料繫結Salary
        }
        hScrollBar1.Maximum = bindingSource1.Count; // 設定hScrollBar1最大值為資料錄筆數
        // 處理資料筆數歸零
        if (hScrollBar1.Maximum == 0) 
        {
          hScrollBar1.Minimum = 0;
          hScrollBar1.Value = hScrollBar1.Minimum;
          lblCount.Text = hScrollBar1.Value + "/" + hScrollBar1.Maximum; // 顯示資料錄筆數
          MessageBox.Show("無資料!");

          btnClean_Click(sender, e); // 清除控制項
        }
        else
        {
          hScrollBar1.Value = bindingSource1.Position + 1; // 設定顯示為目前資料錄
          lblCount.Text = hScrollBar1.Value + "/" + hScrollBar1.Maximum; // 顯示資料錄筆數
        }

        MessageBox.Show("資料已刪除!");
      }
    }

    // 水平捲動－變更目前資料錄
    private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
    {
      bindingSource1.Position = e.NewValue - 1; // 變更Position
      lblCount.Text = hScrollBar1.Value + "/" + hScrollBar1.Maximum;
    }

    // 驗證員工編號
    private void txtId_Validating(object sender, CancelEventArgs e)
    {
      var ID = txtId.Text.ToArray(); // 取出字元陣列
      string msg = ""; // 錯誤訊息

      if (ID.Length != 6) // 長度預設為6碼
      {
        e.Cancel = true;
        txtId.Select(0, txtId.Text.Length);
        msg = "員工編號不符合驗證規則－長度不為6，請修正！";
        errorProvider1.SetError(txtId, msg);
        return;
      }
      if (ID[0] - 'A' < 0 || ID[0] - 'A' > 5) // 第1碼必須為A-F
      {
        e.Cancel = true;
        txtId.Select(0, txtId.Text.Length);
        msg = "員工編號不符合驗證規則－第1碼不為A-F，請修正！";
        errorProvider1.SetError(txtId, msg);
        return;
      }
      if (ID[1] - '0' < 0 || ID[1] - '0' > 9 || ID[2] - '0' < 0 || ID[2] - '0' > 9 || ID[3] - '0' < 0 || ID[3] - '0' > 9 || ID[4] - '0' < 0 || ID[4] - '0' > 9 || ID[5] - '0' < 0 || ID[5] - '0' > 9) // 第2-6為數字
      {
        e.Cancel = true;
        txtId.Select(0, txtId.Text.Length);
        msg = "員工編號不符合驗證規則－第2-6碼不為數字，請修正！";
        errorProvider1.SetError(txtId, msg);
        return;
      }
      int FN = (ID[0] - 'A' + 1) * 5 + (ID[1] - '0') * 4 + (ID[2] - '0') * 3 + (ID[3] - '0') * 2 + (ID[4] - '0') * 1;
      int check = (FN / 10) + (FN % 10);
      if (check >= 10) check = check % 10;
      if (ID[5] - '0' != check) // 第6碼須符合規則
      {
        e.Cancel = true;
        txtId.Select(0, txtId.Text.Length);
        msg = "員工編號不符合驗證規則－檢查碼錯誤，請修正！";
        errorProvider1.SetError(txtId, msg);
        return;
      }
      if (bindingSource1.Find("Id", txtId.Text) > -1) // 員工編號重複
      {
        e.Cancel = true;
        txtId.Select(0, txtId.Text.Length);
        msg = "員工編號與現有資料重複，請修正！";
        errorProvider1.SetError(txtId, msg);
        return;
      }

      errorProvider1.SetError(txtId, "");
    }

    // 驗證姓名
    private void txtName_Validating(object sender, CancelEventArgs e)
    {
      if (txtName.Text.Length == 0)
      {
        e.Cancel = true;
        txtName.Select(0, txtName.Text.Length);
        errorProvider1.SetError(txtName, "姓名必須輸入");
      }
      else
      {
        errorProvider1.SetError(txtName, "");
      }
    }

    // 驗證本俸
    private void txtBasesalary_Validating(object sender, CancelEventArgs e)
    {
      if (txtBasesalary.Text.Length == 0)
      {
        e.Cancel = true;
        txtBasesalary.Select(0, txtBasesalary.Text.Length);
        errorProvider1.SetError(txtBasesalary, "本俸必須輸入");
      }
      else
      {
        errorProvider1.SetError(txtBasesalary, "");
      }
    }

    // 驗證獎金
    private void txtBonus_Validating(object sender, CancelEventArgs e)
    {
      if (txtBonus.Text.Length == 0)
      {
        e.Cancel = true;
        txtBonus.Select(0, txtBonus.Text.Length);
        errorProvider1.SetError(txtBonus, "獎金必須輸入");
      }
      else
      {
        errorProvider1.SetError(txtBonus, "");
      }
    }

    // 驗證扣款
    private void txtDeduct_Validating(object sender, CancelEventArgs e)
    {
      if (txtDeduct.Text.Length == 0)
      {
        e.Cancel = true;
        txtDeduct.Select(0, txtDeduct.Text.Length);
        errorProvider1.SetError(txtDeduct, "扣款必須輸入");
      }
      else
      {
        errorProvider1.SetError(txtDeduct, "");
      }
    }

    // 資料錄移動
    private void bindingSource1_CurrentChanged(object sender, EventArgs e)
    {
      txtId.Text = ((Salary)bindingSource1.Current).Id; // 員工編號
      txtName.Text = ((Salary)bindingSource1.Current).name; // 姓名
      txtBasesalary.Text = ((Salary)bindingSource1.Current).basesalary.ToString(); // 本俸
      txtBonus.Text = ((Salary)bindingSource1.Current).bonus.ToString(); // 獎金
      txtDeduct.Text = ((Salary)bindingSource1.Current).deduct.ToString(); // 扣款
      textBox1.Text = ((Salary)bindingSource1.Current).photo; // 照片檔名
      if (textBox1.Text.Length > 0)
      {
        var photo = System.IO.Directory.GetCurrentDirectory() + "\\" + textBox1.Text;
        pictureBox1.Image = Image.FromFile(photo);
      }
      else
        pictureBox1.Image = null;
    }

    // 開啟圖檔
    private void pictureBox1_DoubleClick(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK) // 指定圖檔
      {
        pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        textBox1.Text = "Staff_Picture\\" + System.IO.Path.GetFileName(openFileDialog1.FileName);
      }
    }

    // 匯入資料
    private void btnShow_Click(object sender, EventArgs e)
    {
      if (openFileDialog2.ShowDialog() == DialogResult.OK) // 選定圖檔
      {
        COMOffice.ImportExcel(openFileDialog2.FileName, this); // 匯入Excel

        MessageBox.Show("匯入成功!");
        progressBar1.Value = progressBar1.Minimum;

        using (var testDB = new TestDBEntities())
        {
          // 篩選未停用員工
          var ds = from s in testDB.Salary 
                   where s.status == false
                   select s;
          bindingSource1.DataSource = ds.ToList(); // 資料繫結Salary
          hScrollBar1.Maximum = bindingSource1.Count; // 設定hScrollBar1最大值為資料錄筆數
          hScrollBar1.Value = bindingSource1.Position + 1; // 設定顯示為目前資料錄
          lblCount.Text = hScrollBar1.Value + "/" + hScrollBar1.Maximum; // 顯示資料錄筆數
        }
      }
    }

    // 開啟Form2表單－薪資統計表
    private void button1_Click(object sender, EventArgs e)
    {
      var f2 = new Form2();
      f2.ShowDialog();
    }
  }
}
