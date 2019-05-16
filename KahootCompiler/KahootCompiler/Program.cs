using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace KahootCompiler
{
    class Record
    {
        public string name { get; set; }
        public int correct { get; set; }
        public int incorrect { get; set; }
        public int score { get; set; }
        public double percentage { get; set; }
        public int gamecount { get; set; }

        public Record()
        {
            this.name = "";
            this.correct = 0;
            this.incorrect = 0;
            this.score = 0;
            this.percentage = 1;
            this.gamecount = 1;
        }

        //testing purpose
        public override string ToString()
        {
            return "Name: " + name + " Total Corrects: " + correct + " Total Incorrects: " + incorrect + " Total Score: " + score + " Avg. %: " + string.Format("{0:0.00}", 100 * percentage / gamecount) + " in " + gamecount + " games.";
        }

        //equal / gethashcode overrides to change how methods work in lists
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Record objAsRecord = obj as Record;
            if (objAsRecord == null) return false;
            else return Equals(objAsRecord);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public bool Equals(Record record)
        {
            if (record == null) return false;
            return (this.name.Equals(record.name));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //initialize all excel components
            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;
            Excel.Range range;

            //excel installed?
            if (app == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                Console.ReadLine();
                Environment.Exit(0);
            }

            //new dynamic list containing ALL repeating records
            List<Record> completelist = new List<Record>();

            //going through each excel file in same directory
            var enumfile = Directory.EnumerateFiles(Environment.CurrentDirectory, "*.xls");
            foreach (string file in enumfile)
            {
                //assign correct worksheet to component
                workbook = app.Workbooks.Open(file);
                worksheet = workbook.Sheets[1];
                range = worksheet.UsedRange;

                //add records
                for (int i = 4; i <= range.Columns.Count; i++)
                {
                    if ((Convert.ToInt32(worksheet.Cells[i, 2].Value) + Convert.ToInt32(worksheet.Cells[i, 3].Value)) != 0)
                        completelist.Add(new Record()
                        {
                        name = Convert.ToString(worksheet.Cells[i, 1].Value),
                        correct = Convert.ToInt32(worksheet.Cells[i, 2].Value),
                        incorrect = Convert.ToInt32(worksheet.Cells[i, 3].Value),
                        score = Convert.ToInt32(worksheet.Cells[i, 4].Value),
                        percentage = Convert.ToDouble(worksheet.Cells[i, 2].Value) / (Convert.ToDouble(worksheet.Cells[i, 2].Value + worksheet.Cells[i, 3].Value)),
                        gamecount = 1
                        });
                    if ((string)worksheet.Cells[i, 1].Value == "OVERALL PERFORMANCE")
                        break;
                }
            }

            //new dynamic array list containing NO repeating records
            List<Record> trimmedlist = new List<Record>();
            int index = 0;

            //assigning / changing records
            foreach (Record record in completelist)
            {
                if (trimmedlist.Contains(record))
                {
                    index = trimmedlist.FindIndex(c => c.name == record.name);
                    trimmedlist[index].correct += record.correct;
                    trimmedlist[index].incorrect += record.incorrect;
                    trimmedlist[index].score += record.score;
                    trimmedlist[index].percentage += record.percentage;
                    trimmedlist[index].gamecount += 1;
                }
                else
                    trimmedlist.Add(record);
            }

            //OCD
            completelist = null;
            workbook = null;
            worksheet = null;
            range = null;

            workbook = app.Workbooks.Add();
            worksheet = workbook.Sheets[1];
            range = worksheet.UsedRange;

            worksheet.Cells[1, 1] = "Name (ID)";
            worksheet.Cells[1, 2] = "Total";
            worksheet.Cells[2, 2] = "Corrects";
            worksheet.Cells[2, 3] = "Incorrects";
            worksheet.Cells[2, 4] = "Score";
            worksheet.Cells[1, 5] = "Avg. %";
            worksheet.Cells[1, 6] = "Game Count";

            for (int i = 0; i < trimmedlist.Count; i++)
            {
                worksheet.Cells[i + 3, 1] = trimmedlist[i].name;
                worksheet.Cells[i + 3, 2] = trimmedlist[i].correct;
                worksheet.Cells[i + 3, 3] = trimmedlist[i].incorrect;
                worksheet.Cells[i + 3, 4] = trimmedlist[i].score;
                worksheet.Cells[i + 3, 5] = string.Format("{0:0.00}", 100 * trimmedlist[i].percentage / trimmedlist[i].gamecount);
                worksheet.Cells[i + 3, 6] = trimmedlist[i].gamecount;
            }
            Console.WriteLine(Environment.CurrentDirectory);
            workbook.SaveAs("KahootCompiled.xls");

            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(app);

            Console.ReadLine();

        }
    }
}
