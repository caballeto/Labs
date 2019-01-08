using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab
{
    public class Student : Person
    {
        public static int Count = 0;
        
        public Education Level;
        public int GroupNumber;
        public int OffsetNumber;
        public List<Examination> Exams;
        public double AverageMark
        {
            get
            {
                double acc = 0;
                foreach (var variable in Exams)
                {
                    acc += variable.Mark;
                }
                return acc / Exams.Count;
            }
        }
        
        public enum Education
        {
            Master,
            Bachelor,
            SecondEducation,
            PhD
        }

        public Student(string name, string surname, string date,
            Education education, int groupNumber, int offsetNumber)
            : base(name, surname, date)
        {
            Level = education;
            Exams = new List<Examination>();
            GroupNumber = groupNumber;
            OffsetNumber = offsetNumber;
            Interlocked.Increment(ref Count);
        }
        
        public Student(string name, string surname, string date, int groupNumber, int offsetNumber)
            : base(name, surname, date)
        {
            Level = Education.Bachelor;
            Exams = new List<Examination>();
            GroupNumber = groupNumber;
            OffsetNumber = offsetNumber;
            Interlocked.Increment(ref Count);
        }
        
        public Student(string name, string surname, string date, Education education)
            : base(name, surname, date)
        {
            Level = education;
            Exams = new List<Examination>();
            GroupNumber = 1;
            Interlocked.Increment(ref Count);
        }

        ~Student()
        {
            Interlocked.Decrement(ref Count);
        }
        
        public void AddExams(Examination[] examList)
        {
            foreach (var examination in examList)
            {
                Exams.Add(examination);
            }
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + GroupNumber + " " + Date;
        }

        public IEnumerable<Examination> iterate(int x)
        {
            foreach (var exam in Exams)
            {
                if (exam.Mark >= x)
                    yield return exam;
            }
        }
        public override void PrintFullInfo()
        {
            Console.WriteLine(Name + " " + Surname + " " + Date +  " " + Level + " "
                              + GroupNumber + " " + OffsetNumber + " " + AverageMark);
            Console.WriteLine("Examinations:");
            
            foreach (var exam in Exams)
            {
                Console.WriteLine(exam);
            }
        }
    }
}