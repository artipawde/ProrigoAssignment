
using System.Collections.Generic;
using System;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(Object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(String name)
        {
            this.name = name;
        }
        public string name;
        public String Name
        {
            get;
            set; 
        }
    }
    public abstract class Book : NamedObject
    {
        public Book(string name) : base(name)
        {

        }
        public abstract void AddGrade(double grade);
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base (name)
        {
            grades = new List<double>();
            Name = name;
        }

        

        // public void AddLetterGrade(char letter)
        // {
        //     switch(letter)
        //     {
        //         case 'A':
        //         AddGrade(90);
        //         break;
        //         case 'B':
        //         AddGrade(80);
        //         break;
        //         case 'C':
        //         AddGrade(70);
        //         break;
        //         default:
        //         AddGrade(0);
        //         break;
        //     }
        // }
        


        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                AddGrade(90);
                break;
                case 'B':
                AddGrade(80);
                break;
                case 'C':
                AddGrade(70);
                break;
                default:
                AddGrade(0);
                break;
            }
        }
        double result;
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public void Display()
        {
        foreach( var nb  in grades)
        {
             result += nb;
             System.Console.WriteLine(nb);
        }
        System.Console.WriteLine("result of class book :"+result);
        }
        public Statistics GetStatics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.HighGrade = double.MinValue;
            result.LowGrade = double.MaxValue;
            // foreach( var grade in grades)
            // {
            //     result.Average += grade;
            //     result.LowGrade = Math.Min(grade, result.LowGrade);
            //     result.HighGrade = Math.Max(grade,result.HighGrade);
            // }

            var index = 0;
            while(grades.Count  > index)
            {
                result.Average += grades[index];
                result.LowGrade = Math.Min(grades[index], result.LowGrade);
                result.HighGrade = Math.Max(grades[index],result.HighGrade);
                index++;
            }
 
            result.Average /= grades.Count;
            return result; 
        }

        public event GradeAddedDelegate GradeAdded;
        private List<double> grades ;


        public const string CATEGORY = "Science" ;
    }
}