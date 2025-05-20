class Program
{
    static void Main(string[] args)
    {
        string[] text = File.ReadAllLines($"C:\\Users\\ktv11\\Desktop\\file.txt");
        List<string> list = new List<string>();
        foreach( string line in text )
        {
            if(line.Any(s => char.IsDigit(s) && (s - '0') % 2 != 0))
            {
                list.Add(line);
            }
        }
        File.WriteAllLines($"C:\\Users\\ktv11\\Desktop\\output.txt", list);
    }
}
