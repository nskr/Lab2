using System;


namespace Labs2
{
    public class Derived : Found
    {
        protected int debet;
        public Derived() { }
        public Derived(String name, int cred, int deb) : base(name, cred)
        {
            debet = deb;
        }
        public void DerivedMethod()
        { 
            Console.WriteLine("Это метод класса Derived");
        }
        new public void Analysis()
        {
            base.Analysis();
            Console.WriteLine("Сложный анализ");
        }
        public void Analysis(int level)
        { 
            base.Analysis();
            Console.WriteLine("Анализ глубины {0}", level);
        }
        public override String ToString()
        {
            return (String.Format("поля: name = {0}, credit = {1},debet ={2}", name, credit, debet));
        }
        public override void VirtMethod()
        {
            Console.WriteLine("Сын: " + this.ToString());
        }
    }
}
