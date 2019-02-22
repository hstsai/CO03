using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Excel = Microsoft.Office.Interop.Excel; // 必須先加入參考Microsoft.office.interop.Excel

namespace COD03
{
  class COMOffice
  {
    // 匯入Excel
    public static void ImportExcel(string fileName, Form1 f1)
    {
      Excel.Application app = new Excel.Application(); // 建立Excel應用程式
      //app.Visible = true; // 顯示Excel應用程式
      Excel.Workbook wb = app.Workbooks.Open(fileName); // 讀取Excel活頁簿
      Excel.Worksheet ws = app.ActiveSheet; // 取得目前工作表
      f1.progressBar1.Minimum = 1; // 完成進度下限值
      f1.progressBar1.Maximum = ws.UsedRange.Rows.Count; // 完成進度上限值
      f1.progressBar1.Value = 1; // 目前進度值
      f1.progressBar1.Step = 1; // 完成進度增量

      using (var testDB = new TestDBEntities()) // 建立TestDB物件
      {
        var errFileName = System.IO.Path.GetDirectoryName(fileName) + "/Import_ErrLog.txt"; // 錯誤紀錄
        using (var errFile = new System.IO.StreamWriter(errFileName))
        {
          for (int r = 2; r <= ws.UsedRange.Rows.Count; r++) // 取得Excel使用範圍
          {
            // 暫存入Salary資料表
            var salary = new Salary();
            salary.Id = Convert.ToString(ws.UsedRange.Cells[r, 1].Value);
            salary.name = Convert.ToString(ws.UsedRange.Cells[r, 2].Value);
            salary.basesalary = Convert.ToInt32(ws.UsedRange.Cells[r, 3].Value);
            salary.bonus = Convert.ToInt32(ws.UsedRange.Cells[r, 4].Value);
            salary.deduct = Convert.ToInt32(ws.UsedRange.Cells[r, 5].Value);
            salary.subtotal = Convert.ToInt32(ws.UsedRange.Cells[r, 6].Value);
            salary.status = Convert.ToBoolean(ws.UsedRange.Cells[r, 7].Value);
            salary.photo = Convert.ToString(ws.UsedRange.Cells[r, 8].Value);

            var msg = ValidateData(salary); // 匯入資料驗證
            if (msg.Length == 0) // 無訊息表示無誤
            {
              testDB.Salary.Add(salary); // 新增資料
              testDB.SaveChanges(); // 更新資料庫
            }
            else
            {
              errFile.WriteLine(msg); // 輸出錯誤訊息
            }

            f1.progressBar1.PerformStep(); // 前進完成度
          }
        }
      }

      app.Quit(); // 結束Excel
    }

    // 驗證匯入資料
    private static string ValidateData(Salary salary)
    {
      string msg = ""; // 錯誤訊息

      using (var testDB = new TestDBEntities()) // 建立TestDB物件
      {
        char[] id = salary.Id.ToArray(); // 取出字元陣列

        if (id.Length != 6) // 長度預設為6碼
        {
          msg = salary.Id + "：員工編號不符合驗證規則－長度不為6碼，請修正！";
          return msg;
        }
        if (id[0] - 'A' < 0 || id[0] - 'A' > 5) // 第1碼必須為A-F
        {
          msg = salary.Id + "：員工編號不符合驗證規則－第1碼不為A-F，請修正！";
          return msg;
        }
        if (id[1] - '0' < 0 || id[1] - '0' > 9 || id[2] - '0' < 0 || id[2] - '0' > 9 || id[3] - '0' < 0 || id[3] - '0' > 9 || id[4] - '0' < 0 || id[4] - '0' > 9 || id[5] - '0' < 0 || id[5] - '0' > 9) // 第2-6為數字
        {
          msg = salary.Id + "：員工編號不符合驗證規則－第2-6碼不為數字，請修正！";
          return msg;
        }
        int fn = (id[0] - 'A' + 1) * 5 + (id[1] - '0') * 4 + (id[2] - '0') * 3 + (id[3] - '0') * 2 + (id[4] - '0') * 1;
        int check = (fn / 10) + (fn % 10);
        if (check >= 10) check = check % 10;
        if (id[5] - '0' != check) // 第6碼須符合規則
        {
          msg = salary.Id + "：員工編號不符合驗證規則－檢查碼錯誤，請修正！";
          return msg;
        }
        var query = from x in testDB.Salary // 員工編號重複
                    where x.Id == salary.Id
                    select x;
        if (query.Count() > 0)
        {
          msg = salary.Id + "：員工編號與現有資料重複，請修正！";
          return msg;
        }
      }

      return msg;
    }

    // 匯出Excel
    static public void ExportExcel(string fileName)
    {
      Excel.Application app = new Excel.Application(); // 建立Excel應用程式
      app.Visible = true; // 顯示Excel應用程式
      Excel.Workbook wb = app.Workbooks.Add(); // 新增Excel活頁簿
      Excel.Worksheet ws = app.ActiveSheet; // 取得目前工作表

      using (var testDB = new TestDBEntities()) // 建立TestDB物件
      {
        ws.Cells[1, "A"] = "薪資小計<15000"; // 填入Excel資料
        var query = from x in testDB.Salary
                    where x.subtotal < 15000
                    select x;
        ws.Cells[1, "B"] = query.Count();
        ws.Cells[2, "A"] = "15000≦薪資小計<25000";
        query = from x in testDB.Salary
                where x.subtotal >= 15000 && x.subtotal < 25000
                select x;
        ws.Cells[2, "B"] = query.Count();
        ws.Cells[3, "A"] = "25000≦薪資小計<50000";
        query = from x in testDB.Salary
                where x.subtotal >= 25000 && x.subtotal < 50000
                select x;
        ws.Cells[3, "B"] = query.Count();
        ws.Cells[4, "A"] = "50000≦薪資小計<75000";
        query = from x in testDB.Salary
                where x.subtotal >= 50000 && x.subtotal < 75000
                select x;
        ws.Cells[4, "B"] = query.Count();
        ws.Cells[5, "A"] = "75000≦薪資小計<95000";
        query = from x in testDB.Salary
                where x.subtotal >= 75000 && x.subtotal < 95000
                select x;
        ws.Cells[5, "B"] = query.Count();
        ws.Cells[6, "A"] = "薪資小計≧95000";
        query = from x in testDB.Salary
                where x.subtotal >= 95000
                select x;
        ws.Cells[6, "B"] = query.Count();
      }

      Excel.ChartObjects cos = ws.ChartObjects(); // 取得圖表物件集合
      Excel.ChartObject co = cos.Add(100, 100, 300, 200); // 加入圖表物件
      Excel.Chart chart = co.Chart; // 取得圖表
      chart.SetSourceData(ws.UsedRange); // 設定圖表資料來源
      chart.ChartType = Excel.XlChartType.xlPie; // 設定圖表類型

      //wb.SaveAs(fileName); // 另存新檔
      //app.Quit(); // 離開Excel
    }

  }
}
