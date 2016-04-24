using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerBehaviour
{
    public float hunger = 300;
    private float hungerNutritionMult = 1;
    public float nutrition = 0;
    public float poison = 0;

    private float nutritionQueued;
    private float poisonQueued;

    public void Update()
    {
        hunger -= Time.deltaTime * hungerNutritionMult;

        nutrition += (nutritionQueued / 10) * Time.deltaTime;
        poison += (poisonQueued / 10) * Time.deltaTime;

        CalculateMultipliers();
    }

    public void EatFood(Food food)
    {
        hunger += food.food;
        nutritionQueued += food.nutrition;
        poisonQueued += food.poison;
    }

    private void CalculateMultipliers()
    {
        float nutritionScale = -nutrition / 200 + 0.5f;

        hungerNutritionMult = Mathf.Lerp(0.5f, 2, nutritionScale);
    }
}
