namespace lab1vage
{
    class Program
    {
        static void Main(string[] args)
        {
            IControl control= new Controller();
            control.Menu();
        }
    }
}