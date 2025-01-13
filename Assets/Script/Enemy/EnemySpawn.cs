using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private GameObject player;
    [SerializeField] private float _miniumSpawnTime;
    [SerializeField] private float _maxiumSpawnTime;
    private float _timeUtilSpawn,posPlayer;
    private Vector3 enemyPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        posPlayer = player.transform.position.x;
        enemyPos = new Vector3(Random.Range(posPlayer+30,posPlayer+100), -22, 0);
        

        _timeUtilSpawn -= Time.deltaTime;
        if(_timeUtilSpawn < 0)
        {
            Instantiate(_enemyPrefab,enemyPos , Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUtilSpawn = Random.Range(_miniumSpawnTime, _maxiumSpawnTime);

    }   
}
