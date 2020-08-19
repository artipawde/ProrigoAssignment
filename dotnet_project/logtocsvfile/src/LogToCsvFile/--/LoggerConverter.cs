using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LogToCsvFile
{
    public class LoggerConverter
    {    
        CheckExtension checkExt = new CheckExtension();
        public void ReadData(string sourcePath , string destinationPath)
        {
            this.destWithExt = checkExt.AddExtension(destinationPath);
            List<string> lines = File.ReadAllLines(sourcePath).ToList();

            foreach(string line in lines)
            {    
                string strRegex = @"(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])\s(0[1-9]|1[012])[:](0[1-9]|[12345][0-9])[:](0[1-9]|[12345][0-9])\s(INFO|WARN|DEBUG|TRACE|ERROR|EVENT)";
                this.regex = new Regex(strRegex);
                WriteData(line);
            }
        }

        public void WriteData(string line)
        {
            if(regex.IsMatch(line))
            {   
                ++No;
                string[] words = line.Split(" ");
                for(int i = 0 ; i < words.Length; i++)
                {
                    string[] dateString = words[0].Split('/');  
                    string[] timeString = words[1].Split(':');

                    try{
                    DateTime datetime = new DateTime (DateTime.Now.Year, Int32.Parse(dateString[0]), Int32.Parse (dateString[1]), Int32.Parse(timeString[0]),Int32.Parse(timeString[1]),Int32.Parse(timeString[2]));
                    date = datetime;
                    }
                    catch(FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Level = words[2];
                }
                var logText=string.Join(" ",words.Skip(3));
                Descr = logText;
              
                if(levelList.Count > 0)
                {
                AddData(date,Level,Descr,destWithExt,levelList);
                }
                else{
                AddData(No,date,Level,Descr,destWithExt);
               }
            }
        }



        public void AddData(int no, DateTime date, string level, string text,string filepath)
        {
            try
            {
                using(System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    file.WriteLine(no + "|" + date + "|" + level + "|" + text);   
                    Console.WriteLine(no);
                    Console.WriteLine(date);
                    Console.WriteLine(level);
                    Console.WriteLine(text);

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private int no = 0;
        public void AddData(DateTime date, string level, string text,string filepath, List<string> list1)
        {
            try
            {
                using(System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    foreach(string str in list1)
                    {
                        if(level == str)
                        {
                            ++no;
                            file.WriteLine(no + "|" + date + "|" + level + "|" + text);   
                            Console.WriteLine(no);
                            Console.WriteLine(date);
                            Console.WriteLine(level);
                            Console.WriteLine(text);
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayData()
        {
            Console.WriteLine($"No : {No}");
            Console.WriteLine($"level : {Level}");
            Console.WriteLine($"date : {date}");
            Console.WriteLine($"Text : {Descr}");
        }

        
        private int No ;
        private String Level;
        private DateTime date;
        private String Descr;

        private Regex regex;

        private List<string> levelList = new List<string>();

        public void SetLevelList(List<string> l1)
        {
            if(l1.Count > 0)
            this.levelList = l1;     
        }


        private  string destWithExt;


    }    
}