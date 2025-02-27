using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1vage
{
    public interface ICharFile
    {
        ICharPage PageReader(int page_number);
        void PageWriter(ICharPage page);
    }
    public class CharFileHandler : ICharFile
    {
        private readonly int ARRAY_LENGTH = 512;
        private readonly int BITMAP_WEIGHT = 64;
        private const int PAGE_AMOUNT = 512;
        private readonly string _file_path;
        private long _pages_count;

        public CharFileHandler(string file_path)
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
                _pages_count = (file_info.Length - 2) / (PAGE_AMOUNT + BITMAP_WEIGHT);
            }
            _file_path = file_path;
        }
        public ICharPage PageReader(int page_number)
        {
            ICharPage page = new CharPage();
            page.Number = page_number;
            page.Status = 0;
            page.Last_Write = DateTime.Now;
            if (_pages_count < page_number)
            {
                long need_to_create_pages = page_number - _pages_count;
                while (need_to_create_pages > 0)
                {
                    ICharPage page_to_write = new CharPage();
                    page_to_write.Number = _pages_count + 1;
                    PageWriter(page_to_write);
                    _pages_count++;
                    need_to_create_pages--;
                }
            }
            using (FileStream file_stream = new FileStream(_file_path, FileMode.Open, FileAccess.ReadWrite))
            {
                file_stream.Seek((PAGE_AMOUNT + BITMAP_WEIGHT) * (page_number - 1) + 2, SeekOrigin.Begin);
                using (BinaryReader reader = new BinaryReader(file_stream))
                {
                    page.Bitmap = reader.ReadBytes(BITMAP_WEIGHT);
                    for (int i = 0; i < ARRAY_LENGTH; i++)
                    {
                        page.Values[i] = reader.ReadChar();
                    }
                }
            }
            return page;
        }

        public void PageWriter(ICharPage page)
        {
            using (FileStream file_stream = new FileStream(_file_path, FileMode.Open, FileAccess.ReadWrite))
            {
                file_stream.Seek((PAGE_AMOUNT + BITMAP_WEIGHT) * (page.Number - 1) + 2, SeekOrigin.Begin);
                using (BinaryWriter writer = new BinaryWriter(file_stream))
                {
                    writer.Write(page.Bitmap);
                    foreach (char c in page.Values)
                    {
                        writer.Write(c);
                    }
                    writer.Flush();
                }
            }
        }
    }
}