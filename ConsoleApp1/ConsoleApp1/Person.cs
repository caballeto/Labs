using System;
using System.Globalization;

namespace Lab
{
    public class Person
    {
        public static string FORMAT = "dd/MM/yyyy";
        public static CultureInfo CI = CultureInfo.InvariantCulture;
        
        public string Name;
        public string Surname;
        public DateTime Date;
        private int _year;
        
        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                Date = new DateTime(value, this.Date.Month, this.Date.Day);
            }
        }

        public Person()
        {
            Name = "Anonymous";
            Surname = "Anonymous";
            Year = DateTime.Now.Year;
            Date = DateTime.Now;
        }

        public Person(string name, string surname, string date) 
            : this(name, surname, DateTime.ParseExact(date, FORMAT, CI), 
                DateTime.ParseExact(date, FORMAT, CI).Year)
        { }

        public Person(string name, string surname, DateTime date, int year)
        {
            Name = name;
            Surname = surname;
            Date = date;
            Year = year;
        }

        public virtual void PrintFullInfo()
        {
            Console.WriteLine(this.Name + " " + Surname + " " + this.Date);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (this.GetType() != obj.GetType()) return false;
            Person that = (Person) obj;
            return this.Name.Equals(that.Name) && that.Surname.Equals(that.Surname)
                                               && this.Year.Equals(that.Year);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return p1.Name != p2.Name || p1.Surname != p2.Surname || p1.Year != p2.Year;
        }
        
        public static bool operator ==(Person p1, Person p2)
        {
            return p1.Name.Equals(p2.Name) && p1.Surname.Equals(p2.Surname) && p1.Year.Equals(p2.Year);
        }
    }
}