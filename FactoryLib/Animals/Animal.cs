using System.Runtime.Serialization.Formatters.Binary;

namespace FactoryLib.Animals;

[Serializable]
public abstract class Animal
{
    public string Spezies { get; set; }
    public double GreenFood { get; set; }
    public double MeatFood { get; set; }
    public int Price { get; set; }
    
    public Animal Clone()
    {
        var ms = new MemoryStream();
        var formatter = new BinaryFormatter();
        formatter.Serialize(ms, this);
        ms.Seek(0, SeekOrigin.Begin);
        var copy = (Animal)formatter.Deserialize(ms);
        ms.Close();
        return copy;
    }
}