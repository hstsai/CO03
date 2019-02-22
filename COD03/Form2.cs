using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Entity;


namespace COD03
{
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();
    }

    // 表單載入
    private void Form2_Load(object sender, EventArgs e)
    {
      using (var testDB = new TestDBEntities()) // 建立TestDB物件
      {
        var ds = from s in testDB.Salary // 篩選未停用員工
                 where s.status == false
                 select s;
        var oc = new System.Collections.ObjectModel.ObservableCollection<Salary>(ds); // 建立可視集合
        bindingSource1.DataSource = oc.ToBindingList(); // 產生可排序清單
        bindingSource1.Sort = "subtotal DESC"; // 指定依照subtotal由大到小排序
        dataGridView1.DataSource = bindingSource1; // 指定DataGridView資料來源為BindingSource
      }
    }

    // 查詢
    private void button1_Click(object sender, EventArgs e)
    {
      using (var testDB = new TestDBEntities()) // 建立TestDB物件
      {
        var list = testDB.Salary.AsEnumerable(); // 取得可數集合
        if (textBox1.Text.Length > 0) // 欄位篩選
          list = from x in list
                 where x.Id.Contains(textBox1.Text)
                 select x;
        if (textBox2.Text.Length > 0)
          list = from x in list
                 where x.name.Contains(textBox2.Text)
                 select x;
        if (textBox3.Text.Length > 0)
          list = from x in list
                 where x.basesalary == Convert.ToInt32(textBox3.Text)
                 select x;
        if (textBox4.Text.Length > 0)
          list = from x in list
                 where x.bonus == Convert.ToInt32(textBox4.Text)
                 select x;
        if (textBox5.Text.Length > 0)
          list = from x in list
                 where x.deduct == Convert.ToInt32(textBox5.Text)
                 select x;
        if (textBox6.Text.Length > 0)
          list = from x in list
                 where x.subtotal == Convert.ToInt32(textBox6.Text)
                 select x;
        var oc = new System.Collections.ObjectModel.ObservableCollection<Salary>(list); // 建立可視集合
        bindingSource1.DataSource = oc.ToBindingList(); // 產生可排序清單
        dataGridView1.DataSource = bindingSource1; // 指定DataGrid資料來源
      }
    }

    // 匯出Excel圖表
    private void button2_Click(object sender, EventArgs e)
    {
      if (saveFileDialog1.ShowDialog() == DialogResult.OK) // 選定檔名
      {
        COMOffice.ExportExcel(saveFileDialog1.FileName);

        MessageBox.Show("匯出Excel成功!");
      }
    }
  }
}
