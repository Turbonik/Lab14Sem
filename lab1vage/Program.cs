namespace lab1vage
{
    class Program
    {
        static void Main(string[] args)
        {
            IIntMemory int_memory;
            ICharMemory char_memory;
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
                        int_memory = new IntMassive(words[0], long.Parse(words[1]));
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
                        int_memory.Exit_Command();
                        break;
                    }
                    switch (words[0].ToLower())
                    {
                        case "create":
                            try
                            {
                                int_memory = new IntMassive(words[1], long.Parse(words[2]));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case "input":
                            //memory.Element_Write(int.Parse(words[1]), int.Parse(words[2]));
                            try
                            {
                                int_memory.Element_Write(int.Parse(words[1]), int.Parse(words[2]));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case "print":
                            //Console.WriteLine(memory.Element_Definition(int.Parse(words[1])));
                            try
                            {
                                Console.WriteLine(int_memory.Element_Definition(int.Parse(words[1])));
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