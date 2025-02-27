namespace lab1vage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IControl
    {
        void Int_Control();
        void Char_Control();
    }
    public class Controller : IControl
    {
        private IIntMemory _int_memory;
        private ICharMemory _char_memory;
        private IStringMemory _string_memory;
        //private string _file_path;

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
                Console.WriteLine("Input {индекс} {значение} - записывает значение в индекс. Значение должно быть ");
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
                            string file_path = Path.Combine("Directory/IntDirectory", words[1]);
                            checked{
                            _int_memory = new IntMassive(file_path, long.Parse(words[2]));
                            }
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
                            checked{
                            _int_memory.Element_Write(int.Parse(words[1]), int.Parse(words[2]));
                            }
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
                            checked{
                            Console.WriteLine(_int_memory.Element_Definition(int.Parse(words[1])));
                            }
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
            if (!Directory.Exists("Directory/CharDirectory"))
            {
                Directory.CreateDirectory("Directory/CharDirectory");
            }
            while (true)
            {
                Console.WriteLine("Введите действие, которое необходимо совершить:");
                Console.WriteLine("Create {имя_файла} {размер_оперативной памяти} - создает файл и выделяет в оперативной памяти указанный размер");
                Console.WriteLine("Input {индекс} {символ} - записывает символ в индекс.");
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
                            string file_path = Path.Combine("Directory/CharDirectory", words[1]);
                            checked{
                            _char_memory = new CharMassive(file_path, long.Parse(words[2]));
                            }
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
                            checked{
                            _char_memory.Element_Write(int.Parse(words[1]), char.Parse(words[2]));
                            }
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
                            checked{
                            Console.WriteLine(_char_memory.Element_Definition(int.Parse(words[1])));
                            }
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

        public void String_Control()
        {
            if (!Directory.Exists("Directory/StringDirectory/Values"))
            {
                Directory.CreateDirectory("Directory/StringDirectory/Values");
            }
            if (!Directory.Exists("Directrory/StringDirectory/Links")){
                Directory.CreateDirectory("Directrory/StringDirectory/Links");
            }
            while (true)
            {
                Console.WriteLine("Введите действие, которое необходимо совершить:");
                Console.WriteLine("Create {имя_файла_ссылок} {имя_файла_значений} {размер_оперативной памяти} - создает файлы и выделяет в оперативной памяти указанный размер");
                Console.WriteLine("Input {индекс} {значение} - записывает значение в индекс. Длина строки меньше 10 элементов");
                Console.WriteLine("Print {индекс} - выводит на экран значение элемента массива элемента с индекс.");
                Console.WriteLine("Exit - завершает работу прораммы.");
                string choice = Console.ReadLine();
                if (choice != null && choice.Length > 0)
                {
                    string[] words = choice.Split(' ');
                    if (words[0].ToLower() == "exit")
                    {
                        if (_string_memory != null)
                        {
                            _string_memory.Exit_Command();
                        }
                        break;
                    }
                    switch (words[0].ToLower())
                    {
                        case "create":
                            string file_path_values = Path.Combine("Directory/StringDirectory/Links", words[1]);
                            string file_path_links = Path.Combine("Directory/StringDirectory/Links", words[2]);
                            checked{
                            _string_memory = new StringMassive(file_path_values, file_path_links, long.Parse(words[2]));
                            }
                            // try
                            // {
                            //     _string_memory = new StringMassive(_file_path, long.Parse(words[2]));
                            // }
                            // catch (Exception ex)
                            // {
                            //     Console.WriteLine(ex.Message);
                            // }
                            break;
                        case "input":
                            _string_memory.Element_Write(int.Parse(words[1]), words[2]);
                            // try
                            // {
                            //     _string_memory.Element_Write(int.Parse(words[1]), words[2]);
                            // }
                            // catch (Exception ex)
                            // {
                            //     Console.WriteLine(ex.Message);
                            // }
                            break;
                        case "print":
                            Console.WriteLine(_string_memory.Element_Definition(int.Parse(words[1])));
                            // try
                            // {
                            //     Console.WriteLine(_string_memory.Element_Definition(int.Parse(words[1])));
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
