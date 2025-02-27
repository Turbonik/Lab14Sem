namespace lab1vage
{
    public interface IStringFile
    {
        IStringPage PageReader(int page_number);
        void PageWriter(IStringPage page);
        string String_Selection(long link);
        long String_Writer(string str);
    }
    public class StringFileHandler : IStringFile
    {
        private readonly int ARRAY_LENGTH = 128;
        private readonly int BITMAP_WEIGHT = 16;
        private const int PAGE_AMOUNT = 512;
        private readonly string _file_path_values;
        private readonly string _file_path_links;
        private long _pages_count;

        public StringFileHandler(string file_path_values, string file_path_links, int array_length)
        {
            if (!File.Exists(file_path_links))
            {
                using (FileStream file_stream = new FileStream(file_path_links, FileMode.Create, FileAccess.ReadWrite))
                {
                    file_stream.Write(new byte[] { 0x56, 0x4D }, 0, 2);
                }
                _pages_count = 0;
            }
            _file_path_links = file_path_links;
            if (!File.Exists(file_path_values)){
                using (FileStream file_stream = new FileStream(file_path_values, FileMode.Create, FileAccess.ReadWrite)){};
            }
            else
            {
                FileInfo file_info = new FileInfo(file_path_links);
                _pages_count = (file_info.Length - 2) / (PAGE_AMOUNT + array_length / 8);
            }
            _file_path_values = file_path_values;
        }
        public IStringPage PageReader(int page_number)
        {
            IStringPage page = new StringPage();
            page.Number = page_number;
            page.Status = 0;
            page.Last_Write = DateTime.Now;
            if (_pages_count < page_number)
            {
                long need_to_create_pages = page_number - _pages_count;
                while (need_to_create_pages > 0)
                {
                    IStringPage page_to_write = new StringPage();
                    page_to_write.Number = _pages_count + 1;
                    PageWriter(page_to_write);
                    _pages_count++;
                    need_to_create_pages--;
                }
            }
            using (FileStream file_stream = new FileStream(_file_path_links, FileMode.Open, FileAccess.ReadWrite))
            {
                file_stream.Seek((PAGE_AMOUNT + BITMAP_WEIGHT) * (page_number - 1) + 2, SeekOrigin.Begin);
                using (BinaryReader reader = new BinaryReader(file_stream))
                {
                    page.Bitmap = reader.ReadBytes(BITMAP_WEIGHT);
                    for (int j = 0; j < ARRAY_LENGTH; j++)
                    {
                        page.Links[j] = reader.ReadInt32();
                    }
                }
            }
            return page;
        }

        public void PageWriter(IStringPage page)
        {
            using (FileStream file_stream = new FileStream(_file_path_links, FileMode.Open, FileAccess.ReadWrite))
            {
                file_stream.Seek((PAGE_AMOUNT + BITMAP_WEIGHT) * (page.Number - 1) + 2, SeekOrigin.Begin);
                using (BinaryWriter writer = new BinaryWriter(file_stream))
                {
                    writer.Write(page.Bitmap);
                    for (int j = 0; j < ARRAY_LENGTH; j++)
                    {
                        writer.Write(page.Links[j]);
                    }
                    writer.Flush();
                }
            }
        }

        public string String_Selection(long link)
        {
            FileInfo info = new FileInfo(_file_path_values);
            using (FileStream file_stream = new FileStream(_file_path_values, FileMode.Open, FileAccess.ReadWrite)){
                file_stream.Seek(link - 1, SeekOrigin.Begin);
                using (BinaryReader reader = new BinaryReader(file_stream)){
                    int length = reader.ReadInt32();
                    char[] buffer = new char[length];
                    for (int i = 0; i < length; i++){
                        buffer[i] = reader.ReadChar();
                    }
                    return new string(buffer);
                }
            }
        }

        public long String_Writer(string str){
            FileInfo info = new FileInfo(_file_path_values);
            Console.WriteLine($"FILEINFO: {info.Length}");
            using (FileStream file_stream = new FileStream(_file_path_values, FileMode.Open, FileAccess.Write))
            {
                using (BinaryWriter writer = new BinaryWriter(file_stream))
                {
                    writer.Write(str.Length);
                    for (int i = 0; i < str.Length; i++)
                    {
                        writer.Write(str[i]);
                    }
                }
            }
            Console.WriteLine($"FILEINFO: {info.Length}");
            return info.Length;
        }
    }
}
