using System;

namespace Labs2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тестирование структур. Программа 1\n");
            TestStruct.TestWithConstruct();
            TestStruct.TestWithoutConstruct();

            Console.WriteLine("\nТестирование класса. Программа 2\n");
            TestPerson TestPersonProps = new TestPerson();
            TestPersonProps.TestPersonProps();

            Console.WriteLine("\nТестирование индексатора. Программа 3\n");
            TestPerson TestPersonChildren = new TestPerson();
            TestPersonChildren.TestPersonChildren();

            Console.WriteLine("\nТестирование наследование. Программа 4\n");
            Found found = new Found("found", 10);
            found.Work();

            Console.WriteLine("\nТестирование наследование. Перегрузка. Программа 5\n");
            Derived derived = new Derived("derived", 10, 100);
            derived.Work();

            Console.WriteLine("\nТестирование интерфейса. Программа 6\n");
            TestClainTwo testClainTwo = new TestClainTwo();
            testClainTwo.TestTwoInterfaces();

            Console.WriteLine("\nТестирование задачи 7\n");
            TestLibrary.test();
        }
    }
}
