using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1vage
{
    public interface IFile
    {
        Page PageReader(int page_number);
        void PageWriter(Page page);
    }
    public class FileHandler : IFile
    {
        private readonly int _array_length;
        private readonly int _bitmap_weight;
        private const int PAGE_AMOUNT = 512;
        private readonly string _file_path;
        private long _pages_count;

        public FileHandler(string file_path, int array_length)
        {
            if (!File.Exists(file_path))
            {
                using (FileStream file_stream = new FileStream(file_path, FileMode.Create, FileAccess.ReadWrite))
                {
                    file_stream.Write(new byte[] { 0x56, 0x4D }, 0, 2);
                }
                _pages_count = 0;
            }
            else
            {
                FileInfo file_info = new FileInfo(file_path);
                _pages_count = (file_info.Length - 2) / (PAGE_AMOUNT + array_length / 8);
            }
            _file_path = file_path;
            _bitmap_weight = array_length / 8;
            _array_length = array_length;
        }
        public Page PageReader(int page_number)
        {
            Page page = new Page();
            page.Number = page_number;
            page.Status = 0;
            page.Last_Write = DateTime.Now;
            if (_pages_count < page_number)
            {
                long need_to_create_pages = page_number - _pages_count;
                while (need_to_create_pages > 0)
                {
                    Page page_to_write = new Page();
                    page_to_write.Number = _pages_count + 1;
                    PageWriter(page_to_write);
                    _pages_count++;
                    need_to_create_pages--;
                }
            }
            using (FileStream file_stream = new FileStream(_file_path, FileMode.Open, FileAccess.ReadWrite))
            {
                file_stream.Seek((PAGE_AMOUNT + _bitmap_weight) * (page_number - 1) + 2, SeekOrigin.Begin);
                using (BinaryReader reader = new BinaryReader(file_stream))
                {
                    page.Bitmap = reader.ReadBytes(_bitmap_weight);
                    for (int j = 0; j < _bitmap_weight; j++)
                    {
                        page.Values[j] = reader.ReadInt32();
                    }
                }
            }
            return page;
        }

        public void PageWriter(Page page)
        {
            using (FileStream file_stream = new FileStream(_file_path, FileMode.Open, FileAccess.ReadWrite))
            {
                file_stream.Seek((PAGE_AMOUNT + _bitmap_weight) * (page.Number - 1) + 2, SeekOrigin.Begin);
                using (BinaryWriter writer = new BinaryWriter(file_stream))
                {
                    writer.Write(page.Bitmap);
                    for (int j = 0; j < _array_length; j++)
                    {
                        writer.Write(page.Values[j]);
                    }
                    writer.Flush();
                }
            }
        }
    }
}
