using FactoryLib.Animals;

namespace FactoryLib;

public class Creator
{
    public enum Animals
    {
        Pinguin,
        Panda,
        Eisbär,
        Gorilla
    }
    
    private static Dictionary<Animals, List<Animal>> _animals = new Dictionary<Animals, List<Animal>>();

    private static Creator _instance = null!;
    public static Creator Instance => _instance ??= new Creator();

    private Creator()
    {
        foreach (var c in Enum.GetValues(typeof(Animals)).Cast<Animals>())
        {
            _animals.Add(c, new List<Animal>());
        }
    }
    
    public List<string> GetAnimals() => _animals.Where(x => x.Value.Count > 0).Select(x => $"{x.Key} - {x.Value.Count}").ToList();
    
    public List<Animal> GetAnimals(Animals animal) => _animals[animal];
    
    public List<Animal> CreateAnimal(Animals animalType, int amount = 1)
    {
        amount = amount == 0? 1 : amount;
        var lst = new List<Animal>();
        var inst = CreateAnimalInstance(animalType);
        lst.Add(inst);
        
        for(int i = amount-1; i > 0; i--)
        {
            lst.Add(inst.Clone());
        }

        _animals[animalType].AddRange(lst);
        return _animals[animalType];
    }
    
    private Animal CreateAnimalInstance(Animals animalType) =>
        animalType switch
        {
            Animals.Pinguin => new Pinguin(),
            Animals.Panda => new Panda(),
            Animals.Eisbär => new Eisbär(),
            Animals.Gorilla => new Gorilla(),
            _ => throw new ArgumentException("Unknown animal type")
        };
}