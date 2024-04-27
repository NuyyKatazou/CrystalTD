using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 5;
    [SerializeField] private int experienceWorth = 1;

    private LevelManager levelManager;
    private LevelSystem levelSystem;

    private bool isDestroyed = false;

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseCurrency(currencyWorth);
            LevelSystem.mainLevelSystem.AddExperience(experienceWorth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}