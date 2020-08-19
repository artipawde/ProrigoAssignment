using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LogToCsvFile
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandArgumentConverter cmdArgConverter = new CommandArgumentConverter();
            cmdArgConverter.Check(args);
            cmdArgConverter.AddHeader();
           // cmdArgConverter.Display();
           try{
            cmdArgConverter.ConvertToLogger(args);
           }
           catch(DirectoryNotFoundException ex)
           {
               Console.WriteLine(ex.Message);
           }
           catch(StackOverflowException ex)
           {
               Console.WriteLine(ex.Message);
           }
        }
      
    }
}
