using System.Collections;

public class Modifier
{
    public enum ModType { None, Sliced, Blended, Pasted, Warmed, Cooled, Frozen, Grilled, Boiled, Fried, Cooked, Baked, Burnt };

    ModType type;

    public Modifier()
    {
        type = ModType.None;
    }
    public Modifier(ModType type)
    {
        this.type = type;
    }

    public ModType Type()
    {
        return type;
    }
}

[System.Serializable]
public class ModifierHandler
{
    Modifier cut = new Modifier();
    Modifier temp = new Modifier();
    Modifier cook = new Modifier();

    /// <summary>
    /// Attempts to add a modifier to the food item
    /// </summary>
    /// <param name="type">The modifier type to be added</param>
    public void AddModifier(Modifier.ModType type)
    {
        // We are making an assumption.
        // Only when you want to remove a temperature modifier would you pass a type of None
        if ((int)type == 0)
        {
            temp = new Modifier(type);
        }
        // This means the modifier is a cut type modifier
        else if ((int)type < 4)
        {
            if ((int)cut.Type() < (int)type)
            {
                cut = new Modifier(type);
            }
        }
        // This means the modifier is a temperature modifier
        else if ((int)type < 7)
        {
            temp = new Modifier(type);
        }
        // This means the modifier is cooked
        else
        {
            // If the food isn't cooked yet make it cooked
            if (cook.Type() == Modifier.ModType.None)
                cook = new Modifier(type);
            // Else burn the food
            else
                cook = new Modifier(Modifier.ModType.Burnt);
        }
    }

    /// <summary>
    /// Check to see if the food has a specific modifier
    /// </summary>
    /// <param name="type">The modifier to check for</param>
    /// <returns>True on having the modifier, false on not</returns>
    public bool HasModifier(Modifier.ModType type)
    {
        if ((int)type < 4)
        {
            return cut.Type() == type;
        }
        else if ((int)type < 7)
        {
            return temp.Type() == type;
        }
        else
        {
            return cook.Type() == type;
        }
    }
}
