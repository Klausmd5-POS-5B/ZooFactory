namespace FactoryLib.Animals;

[Serializable]
internal class Pinguin : Carnivore
{

    private static List<string> _names = new List<string>() { "Kowalski", "Skipper", "Rico", "Private" };
    public Pinguin()
    {
        Spezies = "Pinguin";
        GreenFood = 5;
        MeatFood = 10;
        Price = 50;
        Random rnd = new Random();
        Name = _names[rnd.Next(0, _names.Count)];
    }
    public string Name { get; set; } = "";
    public string Spruch { get; set; } = "Fröhlich lächeln und Winken!";
    
    public override string ToString() => $"{Spezies} {Name}";
}