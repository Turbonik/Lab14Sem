namespace lab1vage{
    public interface IStringMemory{
        int Page_Number(int index);
        string Element_Definition(int index);
        bool Element_Write(int index, string variable);
        void Exit_Command();
    }

    public class StringMassive : IStringMemory
    {
        private const int ARRAY_LENGTH = 128;
        private const int MAX_PAGES = 5;
        private readonly IStringPage[] _pages;
        private readonly IStringFile handler;

        public StringMassive(string file_path_values, string file_path_links, long array_size)
        {
            long pages_count = (array_size + ARRAY_LENGTH - 1) / ARRAY_LENGTH;
            if (pages_count > MAX_PAGES)
            {
                throw new ArgumentException($"Количество элементов в массиве должно быть меньше чем {MAX_PAGES * ARRAY_LENGTH}");
            }
            _pages = new StringPage[pages_count];
            for (int i = 0; i < pages_count; i++)
            {
                _pages[i] = new StringPage();
            }
            handler = new StringFileHandler(file_path_values, file_path_links, ARRAY_LENGTH);
        }

        public int Page_Number(int index)
        {
            bool flag = false;
            int page_number = (index + ARRAY_LENGTH - 1) / ARRAY_LENGTH;
            int need_index = 0;
            for (int i = 0; i < _pages.Length; i++)
            {
                if (_pages[i].Number == page_number)
                {
                    need_index = i;
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Page was not found in physical memory...");
                for (int i = 0; i < _pages.Length; i++)
                {
                    if (_pages[i].Number == 0)
                    {
                        flag = true;
                        need_index = i;
                        break;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("Cleaning the memory and take a new page...");
                    DateTime oldest_date = DateTime.MaxValue;
                    for (int i = 0; i < _pages.Length; i++)
                    {
                        if (_pages[i].Last_Write < oldest_date)
                        {
                            oldest_date = _pages[i].Last_Write;
                            need_index = i;
                        }
                    }
                    if (_pages[need_index].Status == 1)
                    {
                        handler.PageWriter(_pages[need_index]);
                    }
                }
                _pages[need_index] = handler.PageReader(page_number);
            }
            return need_index;
        }

        public string Element_Definition(int index)
        {
            int page_number = Page_Number(index);
            index = index % ARRAY_LENGTH;
            if ((_pages[page_number].Bitmap[index / 8] & (1 << index % 8)) == 0)
            {
                throw new Exception("Указанная ячейка пуста.");
            }
            else
            {
                return handler.String_Selection(_pages[page_number].Links[index]);
            }
        }

        public bool Element_Write(int index, string value)
        {
            if (value.Length > 10){
                throw new Exception("Длина строки больше 10.");
            }
            int page_number = Page_Number(index);
            index = index % ARRAY_LENGTH;
            if ((_pages[page_number].Bitmap[index / 8] & (1 << index % 8)) == 0)
            {
                _pages[page_number].Bitmap[index / 8] |= (byte)(1 << index % 8);
                _pages[page_number].Links[index] = handler.String_Writer(value);
                _pages[page_number].Status = 1;
                _pages[page_number].Last_Write = DateTime.Now;
            }
            else
            {
                throw new Exception("Указанная ячейка занята.");
            }
            return true;
        }

        public void Exit_Command()
        {
            for (int i = 0; i < _pages.Length; i++)
            {
                if (_pages[i].Status == 1)
                {
                    handler.PageWriter(_pages[i]);
                    Console.WriteLine("Saving is successful");
                }
            }
        }
    }
}