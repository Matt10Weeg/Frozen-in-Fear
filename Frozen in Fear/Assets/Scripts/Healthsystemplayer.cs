using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    public void TakeDamege(int amount)
    {
        health -= amount;
        slider.value = health;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

