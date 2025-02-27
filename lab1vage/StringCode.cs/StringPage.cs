namespace lab1vage
{

    public interface IStringPage
    {
        long Number { get; set; }
        byte Status { get; set; }
        public DateTime Last_Write { get; set; }
        byte[] Bitmap { get; set; }
        long[] Links { get; set; }
    }

    public class StringPage : IStringPage
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

        private long[] _links;
        public long[] Links{
            get { return _links; }
            set { _links = value; }
        }

        public StringPage()
        {
            _number = 0;
            _status = 0;
            _last_write = DateTime.Now;
            _bitmap = new byte[16];
            _links = new long[128];
        }
    }
}