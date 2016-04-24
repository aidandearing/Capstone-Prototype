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
        bool named = food.name == name || name == "";
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
        bool modified = food.modifier.HasModifiers(modifier.GetModifiers());

        return named && categories == category.Length && modified;
    }
}

[System.Serializable]
public class Recipe
{
    public static ArrayList recipes;
    public RecipeComponent[] components;
    public GameObject[] results;

    Recipe()
    {
        if (recipes == null)
            recipes = new ArrayList();

        recipes.Add(this);
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

    }

    void Update()
    {

    }
}
