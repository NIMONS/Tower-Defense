using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnemySpawner : TDMonoBehaviour
{
    [Header("Referenes")]
    [SerializeField] protected List<Transform> enemyPrefabs;
    [SerializeField] protected Transform holder;
    [SerializeField] protected UICtrl uiCtrl;

    [Header("Attributes")]
    [SerializeField] protected int baseEnemies = 8;//số lượng quái sinh ra
    [SerializeField] protected float enemiesPerSecond = 0.5f;
    [SerializeField] protected float timeBetweenWaves = 5f;//thời gian giữa các đợt là 5s
    [SerializeField] protected float difficultyScalingFactor = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy=new UnityEvent();

    public int currentWave = 1;//đợt
    private float timeSinceLastSpawn;
    private int enemiesAlive;//quái còn sống
    public int EnemiesAlive=> enemiesAlive;
    private int enemiesLeftToSpawn;//số lượng quái đang chờ sinh
    private bool isSpawning = false;

    protected override void Awake()
    {
        base.Awake();
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyPrefabs();
        this.LoadHolder();
        this.LoadUICtrl();
    }

    protected void LoadUICtrl()
    {
        if (this.uiCtrl != null) return;
        this.uiCtrl=GameObject.FindObjectOfType<UICtrl>();
        Debug.LogWarning(transform.name + ": LoadUICtrl", gameObject);
    }

    protected void LoadEnemyPrefabs()
    {
        if (this.enemyPrefabs.Count > 0) return;
        Transform prefab = transform.Find("Prefabs");
        foreach(Transform i in prefab)
        {
            this.enemyPrefabs.Add(i);
        }
        this.HidePrefabs();
        Debug.LogWarning(transform.name + ": LoadEnemyPrefabs", gameObject);
    }

    protected void HidePrefabs()
    {
        foreach(Transform i in this.enemyPrefabs)
        {
            i.gameObject.SetActive(false);
        }
    }

    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder=transform.Find("Holder").GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": LoadHolder", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(this.StartWave());
    }

    protected override void Update()
    {
        base.Update();
        this.TimeToSpawnEnemies();
        this.PlayerWinner();
    }

    protected void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    protected IEnumerator StartWave()
    {
        yield return new WaitForSeconds(this.timeBetweenWaves);

        this.isSpawning = true;
        this.enemiesLeftToSpawn = EnemiesPerWave();
    }

    protected int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

    protected void TimeToSpawnEnemies()
    {
        if (!isSpawning) return;

        this.timeSinceLastSpawn += Time.deltaTime;

        if (this.timeSinceLastSpawn >= (1f/enemiesPerSecond)&&enemiesLeftToSpawn>0)
        {
            this.SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            this.timeSinceLastSpawn = 0;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            this.EndWave();
        }

    }

    protected void SpawnEnemy()
    {
        if (this.currentWave >= 4)
        {
            //thực hiện spawn random
            System.Random random = new System.Random();

            int randomPrefabIndex = random.Next(enemyPrefabs.Count);

            //truyền con số ngẫu nhiên vào danh sách chứa enemy để spawn
            Transform prefabToSpawn = enemyPrefabs[randomPrefabIndex];
            this.PrefabToSpawn(prefabToSpawn);

        }
        else
        {
            int prefabIndex = Mathf.Min(currentWave - 1, enemyPrefabs.Count - 1);
            Transform prefabToSpawn = enemyPrefabs[prefabIndex];
            this.PrefabToSpawn(prefabToSpawn);
        }
        
    }

    protected void PrefabToSpawn(Transform prefabToSpawn)
    {
        Transform startPoint = LevelManager.Instance.StartPoint;
        Transform prefab = Instantiate(prefabToSpawn, startPoint.position, Quaternion.identity);
        prefab.gameObject.SetActive(true);
        prefab.SetParent(this.holder);
    }

    protected void EndWave()
    {
        this.isSpawning = false;
        timeSinceLastSpawn = 0f;
        this.currentWave++;
        StartCoroutine(this.StartWave());
    }

    protected void PlayerWinner()
    {
        if (this.currentWave >= 5)
        {
            Transform playerWinnerUI = this.uiCtrl.transform.Find("PlayerWinner");
            playerWinnerUI.gameObject.SetActive(true);
            Application.Quit();
        }
    }
}
