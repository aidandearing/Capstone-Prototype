using UnityEngine;
using System.Collections;

[System.Serializable]
public class RecipeComponent
{
    public string name = "";
    public string[] category;
    public ModifierHandler modifier = new ModifierHandler();

    RecipeComponent()
    {

    }

    public bool Verify(Food food)
    {
        if (!(food.name == name || name == ""))
            return false;

        int categories = 0;
        for (int i = 0; i < category.Length; ++i)
        {
            for (int j = 0; j < food.categories.Length; ++j)
            {
                if (category[i] == food.categories[j])
                {
                    categories++;
                    break;
                }
            }
        }
        if (categories != category.Length)
            return false;

        if (!food.modifier.HasModifiers(modifier.GetModifiers()))
            return false;

        return true;
    }
}

[System.Serializable]
public class Recipe
{
    public string name;
    public static ArrayList names;
    public static ArrayList recipes;
    public RecipeComponent[] components;
    public GameObject[] results;

    Recipe()
    {
        if (recipes == null)
        {
            recipes = new ArrayList();
            names = new ArrayList();
        }

        if (!names.Contains(name))
        {
            recipes.Add(this);
            names.Add(name);
        }
    }

    public bool CanBeMade(Food[] foods)
    {
        // Check to see if any foods meet all RecipeComponent requirements
        int count = 0;
        foreach (RecipeComponent component in components)
        {
            foreach(Food food in foods)
            {
                if (component.Verify(food))
                    count++;
            }
        }

        return count == components.Length;
    }

    public GameObject[] Result()
    {
        return results;
    }
}

public class RecipeUnity : MonoBehaviour
{
    [SerializeField]
    public Recipe recipe;

    void Start()
    {
        Debug.Log(this.name + " : " + recipe);
    }

    void Update()
    {

    }
}
