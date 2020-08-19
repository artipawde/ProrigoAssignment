using System;
using System.IO;

namespace LogToCsvFile
{
    public class CheckExtension
    {
        public string AddExtension(string destinationPath)
        {
            string str = destinationPath; 
            if(!Path.HasExtension(destinationPath))
            {
                if(Path.EndsInDirectorySeparator(destinationPath))
                {
                    str += "log.csv";
                }
                else{
                    str += ".csv";
                }
            }
            else
            {
                string getExtension = Path.GetExtension(destinationPath);
                if(getExtension != ".csv")
                {
                    str = Path.ChangeExtension(destinationPath, ".csv");
                }
            }  
            try{
            Directory.CreateDirectory(Path.GetDirectoryName(str));
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return str;   
        }
    }

}