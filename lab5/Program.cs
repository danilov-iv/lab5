using System;
using System.Collections.Generic;
namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            var structure = new Bank();
            structure.Add(new Person { Name = "Федук Федукович", Number = "4512420" });
            structure.Add(new Person { Name = "Илья Или", Number = "82248we" });
            structure.Add(new Company { Name = "Cisco", RegNumber = "ewuir32141324", Number = "3424131445" });
            structure.Accept(new HtmlVisitor());
            structure.Accept(new XmlVisitor());

            Console.Read();
        }
    }
    /// <summary>
    /// Интерфейс класса Посетителя
    /// </summary>
    interface IVisitor
    {
        void VisitPersonAcc(Person acc);
        void VisitCompanyAcc(Company acc);
    }

    /// <summary>
    /// Класс HTML сериализации для Person и Company
    /// </summary>
    class HtmlVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            if (acc.Name == "" || acc.Number == "" || acc.Name.Replace(" ", "") == "" || acc.Number.Replace(" ", "") == "")
            {
                throw new FormatException();
            }
            string result;
            result = "Name: " + acc.Name;
            result += ", Number: " + acc.Number;
            Console.WriteLine(result);
        }

        public void VisitCompanyAcc(Company acc)
        {
            if (acc.Name == "" || acc.RegNumber == "" || acc.Number == "" || acc.Name.Replace(" ", "") == "" || acc.RegNumber.Replace(" ", "") == "" || acc.Number.Replace(" ", "") == "")
            {
                throw new FormatException();
            }
            string result;
            result = "Name: " + acc.Name;
            result += ", RegNumber: " + acc.RegNumber;
            result += ", Number: " + acc.Number;
            Console.WriteLine(result);
        }
    }

    /// <summary>
    /// Класс XML сериализации для Person и Company
    /// </summary>
    class XmlVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            if (acc.Name == "" || acc.Number == "" || acc.Name.Replace(" ", "") == "" || acc.Number.Replace(" ", "") == "")
            {
                throw new FormatException();
            }
            string result =acc.Name  + " " + acc.Number;
            Console.WriteLine(result);
        }

        public void VisitCompanyAcc(Company acc)
        {
            if (acc.Name == "" || acc.RegNumber == "" || acc.Number == "" || acc.Name.Replace(" ", "") == "" || acc.RegNumber.Replace(" ", "") == "" || acc.Number.Replace(" ", "") == "")
            {
                throw new FormatException();
            }
            string result = acc.Name + " " + acc.RegNumber + " " + acc.Number;
            Console.WriteLine(result);
        }
    }
    /// <summary>
    /// Класс для добавления в список, удаления из него и счетчика для записей
    /// </summary>
    class Bank
    {
        List<IAccount> accounts = new List<IAccount>();
        public void Add(IAccount acc)
        {
            accounts.Add(acc);
        }
        public void Remove(IAccount acc)
        {
            accounts.Remove(acc);
        }
        public void Accept(IVisitor visitor)
        {
            foreach (IAccount acc in accounts)
                acc.Accept(visitor);
        }
    }
    /// <summary>
    /// Интерфэйс класса IAccount
    /// </summary>
    interface IAccount
    {
        void Accept(IVisitor visitor);
    }
    /// <summary>
    /// Класс информации которую имеем первоначально для клиента
    /// </summary>
    class Person : IAccount
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitPersonAcc(this);
        }
    }
    /// <summary>
    /// Класс информации которую имеем первоначально для компании
    /// </summary>
    class Company : IAccount
    {
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public string Number { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCompanyAcc(this);
        }
    }
}
