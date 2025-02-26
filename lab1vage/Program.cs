namespace lab1vage
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Controller controller = new Controller();
            if (!Directory.Exists("Directory"))
            {
                Directory.CreateDirectory("Directory");
            }
            Console.WriteLine("VM>");
            while (true)
            {
                Console.WriteLine("Выберите тип массива, с которым хотите работать: int, char. Для выхода: exit");
                string choice = Console.ReadLine();
                if (choice == "exit")
                {
                    break;
                }
                switch (choice)
                {
                    case "int":

                        controller.Int_Control();
                        break;
                    case "char":
                        controller.Char_Control();
                        break;
                }
            }
        }
    }
}