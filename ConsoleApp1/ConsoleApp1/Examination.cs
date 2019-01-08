using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Lab
{
    public class Examination : IMarkName
    {
        public int SemesterNumber;
        public string Name;
        public string TeacherName;
        public int Mark;
        public Differentiation Diff;
        public DateTime Date;
        
        public enum Differentiation
        {
            Differentiated,
            NonDifferentiated
        }

        public Examination()
        {   
            SemesterNumber = 0;
            Name = "Anonymous";
            TeacherName = "Anonymous";
            Diff = Differentiation.NonDifferentiated;
            Date = DateTime.Now;
            Mark = 0;
        }

        public Examination(
            int semesterNumber,
            string name,
            string teacherName,
            int mark,
            Differentiation diff,
            string date)
            : this(semesterNumber, name, teacherName, mark, diff,
                DateTime.ParseExact(date, Person.FORMAT, Person.CI))
        { }
        
        public Examination(
            int semesterNumber, 
            string name, 
            string teacherName, 
            int mark, 
            Differentiation diff, 
            DateTime date)
        {
            SemesterNumber = semesterNumber;
            Name = name;
            TeacherName = teacherName;
            Mark = mark;
            Diff = diff;
            Date = date;
        }

        public string EctsScaleName()
        {
            switch (Mark)
            {
                case 0:
                    return "F";
                case 1:
                    return "E";
                case 2:
                    return "D";
                case 3:
                    return "C";
                case 4:
                    return "B";
                case 5:
                    return "A";
            }
            
            throw new ArgumentException();
        }
        
        public string NationalScaleName()
        {
            switch (Mark)
            {
                case 0:
                    return "Незадовільно";
                case 1:
                    return "Задовільно";
                case 2:
                    return "Задовільно";
                case 3:
                    return "Добре";
                case 4:
                    return "Добре";
                case 5:
                    return "Відмінно";
            }

            throw new ArgumentException();
        }
        
        public override string ToString()
        {
            return Name + " " + TeacherName + " " + Mark;
        }
    }
}