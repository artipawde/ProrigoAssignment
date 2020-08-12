using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new InMemoryBook("Aaru");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;



            // book.AddGrade(11.1);
            // book.AddGrade(22.2);
            // book.AddGrade(33.3);
            // book.AddGrade(44.4);

            EnterGrades(book);

            var stats = book.GetStatics();

            Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"For The Book Named {book.Name}");
            Console.WriteLine("highgrade :" + stats.HighGrade);
            Console.WriteLine("lowgrade :" + stats.LowGrade);
            Console.WriteLine($"Avg result : {stats.Average:N3}");

        }

        private static void EnterGrades(InMemoryBook book)
        {
            
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to Quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    book.AddGrade('A');
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        
        static void OnGradeAdded(Object sender, EventArgs e)
        {
            Console.WriteLine(" A grade was Added");
        }
    }
}

 


            // if(args.Length > 0)
            // {
            //     Console.WriteLine($"Hello,  {args[0]} ! ");
            // }
            // else
            // {
            //     Console.WriteLine("Hi Everyone");
                
            // }