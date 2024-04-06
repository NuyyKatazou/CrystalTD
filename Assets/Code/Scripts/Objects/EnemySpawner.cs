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
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;
    [SerializeField] private float enemiesPerSecondCap = 15f;
    [SerializeField] private int experienceWorth = 500;

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
            LevelSystem.mainLevelSystem.AddExperience(experienceWorth);
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
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[index];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

    private float EnemiesPerSecond()
    {
        return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(currentWave, difficultyScalingFactor), 0f, enemiesPerSecondCap);
    }
}
