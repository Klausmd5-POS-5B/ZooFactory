namespace FactoryLib.Animals;

[Serializable]
internal class Gorilla : Carnivore
{

    public Gorilla()
    {
        Spezies = "Gorilla";
        GreenFood = 2;
        MeatFood = 100;
        Price = 1500;
    }
    public string Name { get; set; } = "Simon";
    
    public override string ToString() => $"{Spezies} {Name}";
}