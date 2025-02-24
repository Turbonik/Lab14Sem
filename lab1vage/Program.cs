namespace lab1vage
{
    class Program
    {
        static void Main(string[] args)
        {
            IMemory memory;
            Console.WriteLine("VM>");
            while (true)
            {
                Console.WriteLine("{имя_файла} {размер_оперативной памяти} - создает файл и выделяет в оперативной памяти указанный размер");
                string choice = Console.ReadLine();
                if (choice != null && choice.Length > 0)
                {
                    string[] words = choice.Split(' ');
                    try
                    {
                        memory = new IntMassive(words[0], long.Parse(words[1]));
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            while (true)
            {
                Console.WriteLine("Введите действие, которое необходимо совершить:");
                Console.WriteLine("Create {имя_файла} {размер_оперативной памяти} - создает файл и выделяет в оперативной памяти указанный размер");
                Console.WriteLine("Input {индекс} {значение} - записывает значение в индекс.");
                Console.WriteLine("Print {индекс} - выводит на экран значение элемента массива элемента с индекс.");
                Console.WriteLine("Exit - завершает работу прораммы.");
                string choice = Console.ReadLine();
                if (choice != null && choice.Length > 0)
                {
                    string[] words = choice.Split(' ');
                    if (words[0].ToLower() == "exit")
                    {
                        break;
                    }
                    switch (words[0].ToLower())
                    {
                        case "create":
                            try
                            {
                                memory = new IntMassive(words[1], long.Parse(words[2]));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case "input":
                            try
                            {
                                memory.Element_Write(int.Parse(words[1]), int.Parse(words[2]));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case "print":
                            try
                            {
                                Console.WriteLine(memory.Element_Definition(int.Parse(words[1])));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                    }
                }
            }
        }
    }
}