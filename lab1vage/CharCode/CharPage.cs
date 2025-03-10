namespace lab1vage
{
    public interface ICharPage
    {
        long Number { get; set; }
        byte Status { get; set; }
        public DateTime Last_Write { get; set; }
        byte[] Bitmap { get; set; }
        char[] Values { get; set; }
    }

    public class CharPage : ICharPage
    {
        private long _number;
        public long Number
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
        private char[] _values;
        public char[] Values
        {
            get { return _values; }
            set { _values = value; }
        }

        public CharPage()
        {
            _number = 0;
            _status = 0;
            _last_write = DateTime.Now;
            _bitmap = new byte[64];
            _values = new char[512];
        }
    }
}