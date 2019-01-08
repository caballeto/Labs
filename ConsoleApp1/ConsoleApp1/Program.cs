using System;
using System.Globalization;

namespace Lab
{
    class Program
    {
        public static string FORMAT = "-------------------------";
        static void Main(string[] args)
        {   
            Student student = new Student("Sherlock", "Holmes", "16/07/1887", Student.Education.Master);
            
            Examination[] examinations = {
                new Examination(1, "math", "Diocletion", 5,
                    Examination.Differentiation.Differentiated, "15/01/2019"),
                new Examination(1, "computer acrhitecture", "Julian", 2,
                    Examination.Differentiation.Differentiated, "18/01/2019"),
                new Examination(1, "programming", "Cicero", 4,
                    Examination.Differentiation.Differentiated, "13/01/2019"),
            };
            
            student.AddExams(examinations);
            Console.WriteLine(student);
            Console.WriteLine(FORMAT);
            student.PrintFullInfo();
            Console.WriteLine(FORMAT);

            Person p1 = new Person("John", "Tolkien", "16/04/2024");
            Person p2 = new Person("Jim", "Carlile", "17/05/2026");
            
            Console.WriteLine("Testing Person Equals");
            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1 != p2);
            Console.WriteLine(new Person() == new Person());
            
            Console.WriteLine(FORMAT);
            Console.WriteLine(examinations[0].NationalScaleName() + " " + examinations[0].EctsScaleName());
            Console.WriteLine(examinations[1].NationalScaleName() + " " + examinations[1].EctsScaleName());
            Console.WriteLine(examinations[2].NationalScaleName() + " " + examinations[2].EctsScaleName());

            Console.WriteLine(FORMAT);
            Console.WriteLine("Exams, that student has more than points " + 3);
            foreach (var exam in student.iterate(3))
            {
                Console.WriteLine(exam);
            }
            
            Console.WriteLine(FORMAT);
            Console.WriteLine("Number of student instances: " + Student.Count);
        }
    }
}