using System;

namespace Labs2
{
    class TestPerson
    {
        public void TestPersonProps()
        {
            Person pers1 = new Person();
            pers1.Fam = "Петров";
            pers1.Age = 21;
            pers1.Salary = 1000;
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}", pers1.Fam, pers1.Age, pers1.Status);
            pers1.Fam = "Иванов"; 
            pers1.Age += 1;
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}", pers1.Fam, pers1.Age, pers1.Status);
        }
        public void TestPersonChildren()
        {
            Person pers1, pers2;
            pers1 = new Person();
            pers2 = new Person();
            pers1.Fam = "Петров";
            pers1.Age = 42;
            pers1.Salary = 10000;
            pers1[pers1.count_children] = pers2;
            pers2.Fam = "Петров";
            pers2.Age = 21;
            pers2.Salary = 1000;
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}", pers1.Fam, pers1.Age, pers1.Status);
            Console.WriteLine("Сын={0}, возраст={1}, статус={2}", pers1[0].Fam, pers1[0].Age, pers1[0].Status);
        }
    }
    class Person
    {
        const int Child_Max = 10;
        string fam = "", status = "";
        int age = 0, salary = 0;
        public int count_children = 0;
        Person[] children = new Person[Child_Max];
        public string Fam
        {
            set { if (fam == "") fam = value; }
            get { return (fam); }
        }
        public string Status
        {
            get { return (status); }
        }
        public int Age
        {
            set
            {
                age = value;
                if (age < 7) status = "ребёнок";
                else if (age < 17) status = "школьник";
                else if (age < 22) status = "студент";
                else status = "служащий"; 
            }
            get { return (age); }
        }
        public int Salary
        {
            set { salary = value; }
        }
        public Person this[int i]
        {
            get
            {
                if (i < 0 || i >= count_children) i = 0;
                return (children[i]);
            }
            set
            {
                if (i == count_children && i < Child_Max) { 
                    children[i] = value; 
                    count_children++;
                }
            }
        }
    }
}
