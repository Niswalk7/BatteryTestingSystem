using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace BatteryTestingSystem.Utils
{
    public class ReportGenerator
    {
        public static void GenerateReport(DataTable reportData, string title, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write report header
                    writer.WriteLine("==========================================================");
                    writer.WriteLine($"                    {title}");
                    writer.WriteLine($"                Generated on {DateTime.Now}");
                    writer.WriteLine("==========================================================");
                    writer.WriteLine();

                    // Write column headers
                    string headerLine = "";
                    foreach (DataColumn column in reportData.Columns)
                    {
                        headerLine += column.ColumnName.PadRight(20) + " | ";
                    }
                    writer.WriteLine(headerLine);
                    writer.WriteLine(new string('-', headerLine.Length));

                    // Write data rows
                    foreach (DataRow row in reportData.Rows)
                    {
                        string dataLine = "";
                        foreach (var item in row.ItemArray)
                        {
                            dataLine += item.ToString().PadRight(20) + " | ";
                        }
                        writer.WriteLine(dataLine);
                    }

                    writer.WriteLine();
                    writer.WriteLine("==========================================================");
                    writer.WriteLine("End of Report");
                }

                MessageBox.Show($"Report successfully generated and saved to:\n{filePath}", 
                    "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", 
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void PrintReport(DataTable reportData, string title)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (sender, e) => PrintPage(sender, e, reportData, title);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private static void PrintPage(object sender, PrintPageEventArgs e, DataTable reportData, string title)
        {
            // Set up fonts and formatting
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font dataFont = new Font("Arial", 10);
            
            int yPos = 100;
            int leftMargin = 50;
            int topMargin = 50;
            
            // Print title
            e.Graphics.DrawString(title, titleFont, Brushes.Black, leftMargin, topMargin);
            yPos = topMargin + 30;
            
            e.Graphics.DrawString($"Generated on {DateTime.Now}", dataFont, Brushes.Black, leftMargin, yPos);
            yPos += 30;
            
            // Calculate column widths
            int[] columnWidths = new int[reportData.Columns.Count];
            int totalWidth = e.MarginBounds.Width - leftMargin;
            int columnWidth = totalWidth / reportData.Columns.Count;
            
            for (int i = 0; i < columnWidths.Length; i++)
            {
                columnWidths[i] = columnWidth;
            }
            
            // Print column headers
            for (int i = 0; i < reportData.Columns.Count; i++)
            {
                e.Graphics.DrawString(reportData.Columns[i].ColumnName, headerFont, 
                    Brushes.Black, leftMargin + (i * columnWidth), yPos);
            }
            
            yPos += 20;
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + totalWidth, yPos);
            yPos += 5;
            
            // Print data rows
            foreach (DataRow row in reportData.Rows)
            {
                for (int i = 0; i < reportData.Columns.Count; i++)
                {
                    e.Graphics.DrawString(row[i].ToString(), dataFont, 
                        Brushes.Black, leftMargin + (i * columnWidth), yPos);
                }
                
                yPos += 20;
                
                // Check if we need a new page
                if (yPos > e.MarginBounds.Height - 50)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            
            e.HasMorePages = false;
        }

        public static void ExportToCSV(DataTable dataTable, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write headers
                    string headerLine = "";
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        headerLine += dataTable.Columns[i].ColumnName;
                        if (i < dataTable.Columns.Count - 1)
                            headerLine += ",";
                    }
                    writer.WriteLine(headerLine);

                    // Write data rows
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string dataLine = "";
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            // Handle commas and quotes in the data
                            string value = row[i].ToString();
                            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
                            {
                                value = "\"" + value.Replace("\"", "\"\"") + "\"";
                            }
                            
                            dataLine += value;
                            if (i < dataTable.Columns.Count - 1)
                                dataLine += ",";
                        }
                        writer.WriteLine(dataLine);
                    }
                }

                MessageBox.Show($"Data successfully exported to CSV file:\n{filePath}", 
                    "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to CSV: {ex.Message}", 
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}