namespace FactoryLib.Animals;

[Serializable]
internal class Eisbär : Carnivore
{

    public Eisbär()
    {
        Spezies = "Eisbär";
        GreenFood = 2;
        MeatFood = 100;
        Price = 1500;
    }
    public string Name { get; set; } = "Knut";
    
    public string Lebensraum { get; set; } = "Ikea";
    
    public override string ToString() => $"{Spezies} {Name}";
}