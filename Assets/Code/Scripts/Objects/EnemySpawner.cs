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
    [SerializeField] private float enemiesPerSecond = 5.5f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private LevelManager levelManager;

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private float eps;//Enemies Per Second
    private bool isSpawning = false;
    private bool waveTimeModified = false;
    private float timeBetweenWaves = 15f;

    //0 = Ruby / 1 = Azurite / 2 = ??
    List<List<int>> waveList = new List<List<int>>(){
        new List<int>{0, 0, 0, 0, 0, 0, 0, 0}, //Wave 1 : 8 Enemies
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, //Wave 5 : 15 Enemies
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0}, //Wave 10 : 25 Enemies
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0}, //Wave 15 : 35 Enemies
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0}, //Wave 19 : 50 Enemies
        new List<int>{0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0}, //Wave 20 : 75 Enemies
    };

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
            enemiesLeftToSpawn = waveList[currentWave - 1].Count;
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
        LevelManager.main.IncreaseCurrency(currentWave);
    }

    private void SpawnEnemy()
    {

        List<int> selectedList = waveList[currentWave - 1];
        int index = waveList[currentWave - 1][0];
        waveList[currentWave - 1].RemoveAt(0);
        GameObject prefabToSpawn = enemyPrefabs[index];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
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
}