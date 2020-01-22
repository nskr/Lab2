using System;

namespace Labs2
{
    class TestClainTwo
    {
        public void TestTwoInterfaces()
        {
            ClainTwo claintwo = new ClainTwo();
            claintwo.Prop1("Склейка свойства двух интерфейсов");
            claintwo.Prop2("перегрузка .: ", 99);
            claintwo.Prop2(9999);
            claintwo.Prop3FromInterface1();
            claintwo.Prop3FromInterface2();
            Console.WriteLine("Интерфейсный объект вызывает методы 1-го интерфейса!");
            IProps ip1 = (IProps)claintwo;
            ip1.Prop1("интерфейс IProps: свойство 1");
            ip1.Prop3();
            Console.WriteLine("Интерфейсный объект вызывает методы 2-го интерфейса!");
            IPropsOne ip2 = (IPropsOne)claintwo;
            ip2.Prop1("интерфейс IPropsOne: свойство 1");
            ip2.Prop3();
        }
    }
    public interface IProps
    {
        void Prop1(string s);
        void Prop2(string name, int val);
        void Prop3();
    }
    public interface IPropsOne
    {
        void Prop1(string s);
        void Prop2(int val);
        void Prop3();
    }

    public class ClainTwo : IProps, IPropsOne
    {
        public void Prop1(string s)
        {
            Console.WriteLine(s);
        }
        public void Prop2(string s, int x)
        {
            Console.WriteLine(s + x);
        }
        public void Prop2(int x)
        {
            Console.WriteLine(x);
        }
        void IProps.Prop3()
        {
            Console.WriteLine("Метод 3 интерфейса 1");
        }
        void IPropsOne.Prop3()
        {
            Console.WriteLine("Метод 3 интерфейса 2");
        }
        public void Prop3FromInterface1()
        {
            ((IProps)this).Prop3();
        }
        public void Prop3FromInterface2()
        {
            ((IPropsOne)this).Prop3();
        }
    }
}
