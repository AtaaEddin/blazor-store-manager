namespace OnlineStoresManager.Abstractions
{
    public class FileBytes
    {
        public byte[] Bytes { get; }
        public string Name { get; }

        public FileBytes(string name, byte[] bytes)
        {
            Bytes = bytes;
            Name = name;
        }
    }
}
