using System.Collections;

[System.Serializable]
public abstract class Item
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float Value { get; private set; }
    public float Size { get; private set; }
    public float Weight { get; private set; }
    public int Stack { get; private set; }
    public int Rarity { get; private set; }
}
