namespace lab1vage
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("VM>");
            while (true)
            {
                Console.WriteLine("Введите действие, которое необходимо совершить:");
                Console.WriteLine("Create имя_файла - создает новый файл с таким именем.");
                Console.WriteLine("Input индекс значение - записывает значение в индекс.");
                Console.WriteLine("Print индекс - выводит на экран значение элемента массива элемента с индекс.");
                Console.WriteLine("Exit - завершает работу прораммы.");
                string choice = Console.ReadLine();
                if (choice != null)
                {
                    string[] words = choice.Split(' ');
                    switch (words[0])
                    {
                        case "Create":
                            if (int.TryParse(words[1], out _))
                            {

                            }
                            break;
                        default:
                            break;

                    }
                }
            }
        }
    }
}