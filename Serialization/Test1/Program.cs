using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.Json;
[Serializable]class S
{
    public string str { get; set; }

    public S(string str)
    {
        this.str = str;
    }
}
class MainClass
{
    public static void Main()
    {
        Console.WriteLine("enter string");
        S s = new S(Console.ReadLine());
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream stream = new MemoryStream();
        formatter.Serialize(stream,s);//obsolete
        stream.Position = 0;
        Console.WriteLine("deserialization\n"+((S)formatter.Deserialize(stream)).str+"\nnew methods");//obsolete
        string jsonStr = JsonSerializer.Serialize(s);
        Console.WriteLine("json:\n"+jsonStr+"\ndeserialization\n"+JsonSerializer.Deserialize<S>(jsonStr).str);
    }
}
