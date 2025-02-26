namespace lab1vage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Controller
    {
        private IIntMemory _int_memory;
        private ICharMemory _char_memory;
        private string _file_path;

        public void Int_Control()
        {
            if (!Directory.Exists("Directory/IntDirectory"))
            {
                Directory.CreateDirectory("Directory/IntDirectory");
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
                        if (_int_memory != null)
                        {
                            _int_memory.Exit_Command();
                        }
                        break;
                    }
                    switch (words[0].ToLower())
                    {
                        case "create":
                            _file_path = Path.Combine("Directory/IntDirectory", words[1]);
                            _int_memory = new IntMassive(_file_path, long.Parse(words[2]));
                            // try
                            // {
                            //     _int_memory = new IntMassive(words[1], long.Parse(words[2]));
                            // }
                            // catch (Exception ex)
                            // {
                            //     Console.WriteLine(ex.Message);
                            // }
                            break;
                        case "input":
                            _int_memory.Element_Write(int.Parse(words[1]), int.Parse(words[2]));
                            // try
                            // {
                            //     _int_memory.Element_Write(int.Parse(words[1]), int.Parse(words[2]));
                            // }
                            // catch (Exception ex)
                            // {
                            //     Console.WriteLine(ex.Message);
                            // }
                            break;
                        case "print":
                            Console.WriteLine(_int_memory.Element_Definition(int.Parse(words[1])));
                            // try
                            // {
                            //     Console.WriteLine(_int_memory.Element_Definition(int.Parse(words[1])));
                            // }
                            // catch (Exception ex)
                            // {
                            //     Console.WriteLine(ex.Message);
                            // }
                            break;
                    }
                }
            }
        }

        public void Char_Control()
        {
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
                        if (_char_memory != null)
                        {
                            _char_memory.Exit_Command();
                        }
                        break;
                    }
                    switch (words[0].ToLower())
                    {
                        case "create":
                            _file_path = Path.Combine("Directory/CharDirectory", words[1]);
                            _char_memory = new CharMassive(_file_path, long.Parse(words[2]));
                            // try
                            // {
                            //     _char_memory = new CharMassive(_file_path, long.Parse(words[2]));
                            // }
                            // catch (Exception ex)
                            // {
                            //     Console.WriteLine(ex.Message);
                            // }
                            break;
                        case "input":
                            if (_char_memory == null)
                            {
                                Console.WriteLine("NULL HERE!!!!!");
                            }
                            _char_memory.Element_Write(int.Parse(words[1]), char.Parse(words[2]));
                            // try
                            // {
                            //     _char_memory.Element_Write(int.Parse(words[1]), char.Parse(words[2]));
                            // }
                            // catch (Exception ex)
                            // {
                            //     Console.WriteLine(ex.Message);
                            // }
                            break;
                        case "print":
                            Console.WriteLine(_char_memory.Element_Definition(int.Parse(words[1])));
                            // try
                            // {
                            //     Console.WriteLine(_char_memory.Element_Definition(int.Parse(words[1])));
                            // }
                            // catch (Exception ex)
                            // {
                            //     Console.WriteLine(ex.Message);
                            // }
                            break;
                    }
                }
            }
        }
    }
}