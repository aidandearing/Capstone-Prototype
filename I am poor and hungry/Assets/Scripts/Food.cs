using System.Collections;

[System.Serializable]
public class Food //: Item
{
    // Item components
    //public string Name { get; private set; }
    //public string Description { get; private set; }
    //public float Value { get; private set; }
    //public float Size { get; private set; }
    //public float Weight { get; private set; }
    //public int Stack { get; private set; }
    //public int Rarity { get; private set; }
    // End of Item components

    public string name;
    public string description;
    public float value;
    public float size;
    public float weight;
    public int stack;
    public int rarity;
    public string[] categories;
    public int food;
    public float nutrition;
    public float poison;
    public ModifierHandler modifier;
}
