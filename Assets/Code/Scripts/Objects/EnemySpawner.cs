using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;
    public VictoryMenu victoryMenu;
    public ShopMenu shopMenu;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 5.5f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private float eps;//Enemies Per Second
    private bool isSpawning = false;
    private bool waveTimeModified = false;
    private float timeBetweenWaves = 15f;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning) return;
        if (LevelManager.main.gameLose != false) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }

        if (currentWave == 1 && waveTimeModified == false)
        {
            Debug.Log("TimeModified");
            timeBetweenWaves = 5f;
            waveTimeModified = true;
        }

        if (currentWave == 21)
        {
            LevelManager.main.tutorialEnd = true;
            victoryMenu.OpenVictoryCanvas();
            shopMenu.CloseShopCanvas();
            MenuUIHandler.mouse_over = true;
            LevelManager.main.gameWin = true;
            LevelSystem.mainLevelSystem.AddExperience(currentWave * 10);
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);

        if (currentWave != 21)
        {
            isSpawning = true;
            enemiesLeftToSpawn = EnemiesPerWave();
            eps = EnemiesPerSecond();
        }
    }

    private void EndWave()
    {
        if (LevelManager.main.gameLose != false) return;

        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
        LevelSystem.mainLevelSystem.AddExperience(currentWave);
    }

    private void SpawnEnemy()
    {
        if (currentWave == 1)
        {
            RubySpawn();
            return;

        }

        if (currentWave == 2)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 3)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 4)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 5)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 6)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 7)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 8)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 9)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 10)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 11)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 12)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 13)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 14)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 15)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 16)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 17)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 18)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 19)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 20)
        {
            if (enemiesLeftToSpawn >= 3)
            {
                RubySpawn();
                return;
            }
            if (enemiesLeftToSpawn <= 2)
            {
                AzuriteSpawn();
                return;
            }
        }

        if (currentWave == 21)
        {
            return;
        }
    }

    private int EnemiesPerWave()
    {
        if (currentWave == 1) { return Mathf.RoundToInt(baseEnemies); } //baseEnemies = 8

        if (currentWave == 2) { return Mathf.RoundToInt(baseEnemies + 2); }

        if (currentWave == 3) { return Mathf.RoundToInt(baseEnemies + 3); }

        if (currentWave == 4) { return Mathf.RoundToInt(baseEnemies + 4); }

        if (currentWave == 5) { return Mathf.RoundToInt(baseEnemies + 7); } //baseEnemies + 7 = 15

        if (currentWave == 6) { return Mathf.RoundToInt(baseEnemies + 8); }

        if (currentWave == 7) { return Mathf.RoundToInt(baseEnemies + 9); }

        if (currentWave == 8) { return Mathf.RoundToInt(baseEnemies + 10); }

        if (currentWave == 9) { return Mathf.RoundToInt(baseEnemies + 12); }

        if (currentWave == 10) { return Mathf.RoundToInt(baseEnemies + 17); } //baseEnemies + 17 = 25

        if (currentWave == 11) { return Mathf.RoundToInt(baseEnemies + 18); }

        if (currentWave == 12) { return Mathf.RoundToInt(baseEnemies + 19); }

        if (currentWave == 13) { return Mathf.RoundToInt(baseEnemies + 20); }

        if (currentWave == 14) { return Mathf.RoundToInt(baseEnemies + 22); }

        if (currentWave == 15) { return Mathf.RoundToInt(baseEnemies + 27); } //baseEnemies + 27 = 35

        if (currentWave == 16) { return Mathf.RoundToInt(baseEnemies + 29); }

        if (currentWave == 17) { return Mathf.RoundToInt(baseEnemies + 32); }

        if (currentWave == 18) { return Mathf.RoundToInt(baseEnemies + 37); }

        if (currentWave == 19) { return Mathf.RoundToInt(baseEnemies + 42); } //baseEnemies + 42 = 50

        if (currentWave == 20) { return Mathf.RoundToInt(baseEnemies + 67); } //baseEnemies + 67 = 75

        return Mathf.RoundToInt(baseEnemies + 6);
    }

    private float EnemiesPerSecond()
    {
        if (currentWave == 1) { return enemiesPerSecond; }

        if (currentWave <= 4) { return enemiesPerSecond = enemiesPerSecond + 0.1f; }

        if (currentWave <= 9) { return enemiesPerSecond = enemiesPerSecond + 0.25f; }

        if (currentWave == 10) { return enemiesPerSecond = enemiesPerSecond + 0.5f; }

        if (currentWave == 11) { return enemiesPerSecond = enemiesPerSecond + 0.6f; }

        if (currentWave == 12) { return enemiesPerSecond = enemiesPerSecond + 0.7f; }

        if (currentWave == 13) { return enemiesPerSecond = enemiesPerSecond + 0.8f; }

        if (currentWave == 14) { return enemiesPerSecond = enemiesPerSecond + 0.9f; }

        if (currentWave == 15) { return enemiesPerSecond = enemiesPerSecond + 1f; }

        if (currentWave == 16) { return enemiesPerSecond = enemiesPerSecond + 1.1f; }

        if (currentWave == 16) { return enemiesPerSecond = enemiesPerSecond + 1.2f; }

        if (currentWave == 17) { return enemiesPerSecond = enemiesPerSecond + 1.3f; }

        if (currentWave == 18) { return enemiesPerSecond = enemiesPerSecond + 1.4f; }

        if (currentWave == 19) { return enemiesPerSecond = enemiesPerSecond + 1.5f; }

        if (currentWave == 20) { return enemiesPerSecond = enemiesPerSecond + 2f; }

        if (currentWave == 21) { return enemiesPerSecond = enemiesPerSecond + 2.2f; }

        return enemiesPerSecond = enemiesPerSecond + 0.5f;
    }

    private void RubySpawn()
    {
        int index = 0;
        GameObject prefabToSpawn = enemyPrefabs[index];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    private void AzuriteSpawn()
    {
        int index = 1;
        GameObject prefabToSpawn = enemyPrefabs[index];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }
}