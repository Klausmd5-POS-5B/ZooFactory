namespace FactoryLib.Animals;

[Serializable]
internal class Panda : Herbivore
{

    public Panda()
    {
        Spezies = "Panda";
        GreenFood = 10;
        MeatFood = 0;
        Price = 100;
    }

    public string Name { get; set; } = "Po";
    
    public string Serie { get; set; } = "Kung Fu Panda";

    public override string ToString() => $"{Spezies} {Name}";
}