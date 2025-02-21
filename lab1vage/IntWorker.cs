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
        public int Number{
            get { return _number; }
            set { _number = value; }
        } 
        private byte _status;
        public byte Status{
            get {return _status; }
            set { _status = value; }
        }
        private DateTime _last_write;
        public DateTime Last_Write{
            get {return _last_write; }
            set { _last_write = value; }
        }
        private byte[] _bitmap;
        public byte[] Bitmap{
            get { return _bitmap; }
            set { _bitmap = value; }
        }
        private int[] _values;
        public int[] Values {
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
    public class IntMassive
    {
        private const int PAGE_AMOUNT = 512;
        private readonly int ARRAY_LENGTH = 128;
        private const int MAX_PAGES = 100;
        private const int BITMAP_WEIGHT = 64;
        private readonly long _file_size;
        private readonly FileStream _file_stream;
        private readonly Page[] _pages;
        
        public IntMassive(string file_path, long array_size)
        {
            _file_size = 0;
            _pages = [];
            int pages_count = (int)array_size + ARRAY_LENGTH - 1;
            if (!File.Exists(file_path))
            {
                _file_stream = new FileStream(file_path, FileMode.Create, FileAccess.ReadWrite);
                _file_stream.Write(new byte[] { 0x56, 0x4D }, 0, 2);
            }
            else
            {
                _file_stream = new FileStream(file_path, FileMode.Open, FileAccess.ReadWrite);
            }
            BinaryReader reader = new BinaryReader(_file_stream);
            reader.BaseStream.Seek(2, SeekOrigin.Begin);
            while (pages_count > 0){
                Page page = new Page();
                page.Status = reader.ReadByte();
                page.Last_Write = new DateTime(reader.ReadInt64());
                for (int i = 0; i < BITMAP_WEIGHT; i++){
                    page.Bitmap[i] = reader.ReadByte();
                }
                for (int i = 0; i < ARRAY_LENGTH; i++){
                    page.Values[i] = reader.ReadInt32();
                }
                _pages.Append(page);
            }
        }

        public int? Page_Number(int index)
        {
            int pages_count = (int)(_file_size / PAGE_AMOUNT);
            int page_number = (index + ARRAY_LENGTH - 1) / ARRAY_LENGTH % pages_count;
            if (page_number > pages_count)
            {
                if (pages_count == MAX_PAGES) {
                    page_number = _pages.OrderBy(p => p.Last_Write).First().Number;
                }
                else {
                    Page page = new Page();
                    StreamWriter writer = new StreamWriter(_file_stream);
                    writer.WriteLine(page.Status);
                    writer.WriteLine(page.Last_Write.Ticks);
                    writer.WriteLine(page.Bitmap);
                    writer.WriteLine(page.Values);
                }
            }
            return page_number;
        }

        public int Element_Definition(int index, int variable)
        {
            if (Page_Number(index) != null){
                int page_number = (int)Page_Number(index);
                _ = index % ARRAY_LENGTH;
                variable = _pages[page_number].Values[index];
                return variable;
            }
            return 0;
        }

        public bool Element_Write(int index, int value)
        {
            if (Page_Number(index) != null){
                int page_number = (int)Page_Number(index);
                _ = index % ARRAY_LENGTH;
                _pages[page_number].Values[index] = value;
                return true;
            }
            return false;
        }
    }
}