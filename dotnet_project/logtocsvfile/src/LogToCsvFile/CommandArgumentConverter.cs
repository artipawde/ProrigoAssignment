using System;
using System.Collections.Generic;
using System.IO;


namespace LogToCsvFile
{
    public class CommandArgumentConverter
    {
        private string sourcePath;

        private string destinationPath;

        private List<string> level = new List<string>();

        public void AddHeader()
        {
            string str = "| No | Level |  Date | Time | Text |\n";
            if (!File.Exists (destinationPath))
            File.Create (destinationPath).Close ();
            if (new FileInfo (destinationPath).Length == 0)
            File.AppendAllText (destinationPath, str);
        }

        public void Check(string[] args)
        {
            for(int i =0; i < args.Length; i++)
            {
            if(args[i].ToLower() == "--log-dir")
            {
                this.sourcePath = args[i + 1];
            }
            else if(args[i].ToLower() == "--csv")
            {
                this.destinationPath = args[i + 1];
            }
            else if(args[i].ToLower() == "--log-level")
            {
                level.Add(args[i + 1].ToUpper());
            }
            }
        }

        public void ValidateSourceFile()
        {
            //if(sourcePat)
        }

        public void Display()
        {
            Console.WriteLine($"source path {this.sourcePath}");
            Console.WriteLine($"destnation Path {this.destinationPath}");
            foreach(var no in level)
            {
                Console.WriteLine(no);
            }
        }
        LoggerConverter lc = new LoggerConverter();

        public void ConvertToLogger(string[] args)
        {
            if( args.Length == 1 && args != null)
            {
              if(args[0].ToLower() == "help")
                {
                    DisplayHelp();
                }
            }
            else if(level.Count == 0)
            {
            try{
               lc.ReadData(this.sourcePath, this.destinationPath);
               }
            catch(UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }  
            }
            else
            {
                lc.SetLevelList(level);
                lc.ReadData(this.sourcePath, this.destinationPath);
            }
        }

        public void DisplayHelp()
        {
            Console.WriteLine("\n  LogParser --log-dir <dir> --log-level <level> --csv <out>");
            Console.WriteLine("  --log-dir      Directory to parse resursively for .log files");
            Console.WriteLine("  --csv          Out file path ");
            Console.WriteLine("  --log-level    INFO|WARN|DEBUG|TRACE|ERROR|EVENT");
        }
        
    }

}
