using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1vage
{
    public struct Page
    {
        private int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        private byte _status;
        public byte Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private DateTime _last_write;
        public DateTime Last_Write
        {
            get { return _last_write; }
            set { _last_write = value; }
        }
        private byte[] _bitmap;
        public byte[] Bitmap
        {
            get { return _bitmap; }
            set { _bitmap = value; }
        }
        private int[] _values;
        public int[] Values
        {
            get { return _values; }
            set { _values = value; }
        }

        public Page()
        {
            _status = 0;
            _last_write = DateTime.Now;
            _bitmap = [64];
            _values = [128];
        }
    }

    public interface IFile
    {
        Page PageReader(BinaryReader reader);
        void PageWriter(Page page, StreamWriter writer);
    }
    public class FileHandler : IFile
    {
        private readonly int ARRAY_LENGTH = 128;
        private const int BITMAP_WEIGHT = 64;
        public Page PageReader(BinaryReader reader)
        {
            Page page = new Page();
            page.Number = reader.ReadInt32();
            page.Status = reader.ReadByte();
            page.Last_Write = new DateTime(reader.ReadInt64());
            page.Bitmap = reader.ReadBytes(BITMAP_WEIGHT);
            for (int j = 0; j < ARRAY_LENGTH; j++)
            {
                page.Values[j] = reader.ReadInt32();
            }
            return page;
        }

        public void PageWriter(Page page, StreamWriter writer)
        {
            writer.WriteLine(page.Number);
            writer.WriteLine(page.Status);
            writer.WriteLine(page.Last_Write.Ticks);
            writer.WriteLine(page.Bitmap);
            writer.WriteLine(page.Values);
        }
    }

    public interface IMemory {
        int Page_Number(int index);
        int Element_Definition(int index, int variable);
        bool Element_Write(int index, int variable);
    }

    public class IntMassive : IMemory
    {
        private const int PAGE_AMOUNT = 512;
        private readonly int ARRAY_LENGTH = 128;
        private const int BITMAP_WEIGHT = 64;
        private const int MAX_PAGES = 5;
        private readonly FileStream _file_stream;
        private readonly Page[] _pages;

        private readonly IFile handler;

        public IntMassive(string file_path, long array_size)
        {
            _pages = [];
            long pages_count = (array_size + ARRAY_LENGTH - 1) / ARRAY_LENGTH;
            if (pages_count > MAX_PAGES){
                throw new ArgumentException($"Количество элементов в массиве должно быть меньше чем {MAX_PAGES * 128}");
            }
            _pages = new Page[pages_count];
            if (!File.Exists(file_path))
            {
                _file_stream = new FileStream(file_path, FileMode.Create, FileAccess.ReadWrite);
                _file_stream.Write(new byte[] { 0x56, 0x4D }, 0, 2);
            }
            else
            {
                _file_stream = new FileStream(file_path, FileMode.Open, FileAccess.ReadWrite);
            }
            handler = new FileHandler();
        }

        public int Page_Number(int index)
        {
            bool flag = false;
            BinaryReader reader = new BinaryReader(_file_stream);
            StreamWriter writer = new StreamWriter(_file_stream);
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
                        _file_stream.Seek(2, SeekOrigin.Begin);
                        _file_stream.Seek((PAGE_AMOUNT + BITMAP_WEIGHT) * _pages[need_index].Number, SeekOrigin.Current);
                        handler.PageWriter(_pages[need_index], writer);
                    }
                }
                _file_stream.Seek(2, SeekOrigin.Begin);
                _file_stream.Seek((PAGE_AMOUNT + BITMAP_WEIGHT) * _pages[page_number].Number, SeekOrigin.Current);
                _pages[need_index] = handler.PageReader(reader);
            }
            return need_index;
        }

        public int Element_Definition(int index, int variable)
        {
            int page_number = Page_Number(index);

            // if (Page_Number(index) != null)
            // {
            //     page_number = (int)Page_Number(index);
            //     _ = index % ARRAY_LENGTH;
            //     variable = _pages[page_number].Values[index];
            //     return variable;
            // }
            return 0;
        }

        public bool Element_Write(int index, int value)
        {
            if (Page_Number(index) != null)
            {
                int page_number = (int)Page_Number(index);
                _ = index % ARRAY_LENGTH;
                _pages[page_number].Values[index] = value;
                return true;
            }
            return false;
        }
    }
}