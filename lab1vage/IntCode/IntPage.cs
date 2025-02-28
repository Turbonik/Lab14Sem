namespace lab1vage
{
    public interface IIntPage
    {
        long Number { get; set; }
        byte Status { get; set; }
        public DateTime Last_Write { get; set; }
        byte[] Bitmap { get; set; }
        int[] Values { get; set; }
    }

    public class IntPage : IIntPage
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
        private int[] _values;
        public int[] Values
        {
            get { return _values; }
            set { _values = value; }
        }

        public IntPage()
        {
            _number = 0;
            _status = 0;
            _last_write = DateTime.Now;
            _bitmap = new byte[16];
            _values = new int[128];
        }
    }
}