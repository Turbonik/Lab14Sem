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
        private const int ARRAY_LENGTH = 128;
        private const int BITMAP_WEIGHT = 64;
        private const int PAGE_AMOUNT = 512;
        private readonly FileStream _file_stream;
        private readonly long _file_weight;

        public FileHandler(string file_path)
        {
            if (!File.Exists(file_path))
            {
                _file_stream = new FileStream(file_path, FileMode.Create, FileAccess.ReadWrite);
                _file_stream.Write(new byte[] { 0x56, 0x4D }, 0, 2);
            }
            else
            {
                _file_stream = new FileStream(file_path, FileMode.Open, FileAccess.ReadWrite);
            }
        }
        public Page PageReader(int page_number)
        {
            BinaryReader reader = new BinaryReader(_file_stream);
            if (_file_weight != (2 + page_number * (PAGE_AMOUNT + ARRAY_LENGTH)))
            {

            }
            _file_stream.Seek(2, SeekOrigin.Begin);
            _file_stream.Seek((PAGE_AMOUNT + BITMAP_WEIGHT) * page_number, SeekOrigin.Current);
            Page page = new Page();
            page.Number = page_number;
            page.Status = 0;
            page.Last_Write = DateTime.Now;
            page.Bitmap = reader.ReadBytes(BITMAP_WEIGHT);
            for (int j = 0; j < ARRAY_LENGTH; j++)
            {
                page.Values[j] = reader.ReadInt32();
            }
            return page;
        }

        public void PageWriter(Page page)
        {
            StreamWriter writer = new StreamWriter(_file_stream);
            _file_stream.Seek(2, SeekOrigin.Begin);
            _file_stream.Seek((PAGE_AMOUNT + BITMAP_WEIGHT) * page.Number, SeekOrigin.Current);
            writer.WriteLine(page.Bitmap);
            writer.WriteLine(page.Values);
        }
    }
}
