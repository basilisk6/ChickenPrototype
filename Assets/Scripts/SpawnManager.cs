using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private enum SpawnType
    {
        Consumable,
        Obstacle
    }
    
    public GameObject obstaclePrefab;
    public GameObject consumablePrefab;
    // Start is called before the first frame update
    void Start()
    {
        var startingNumberOfObstacles = Random.Range(0, 10);
        for (var i = 0; i < startingNumberOfObstacles; i++)
        {
            SpawnObstacle();
        }
        InvokeRepeating("SpawnConsumable", 5.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, RandomSpawn(SpawnType.Obstacle), obstaclePrefab.transform.rotation);
    }

    void SpawnConsumable()
    {
        Instantiate(consumablePrefab, RandomSpawn(SpawnType.Consumable), consumablePrefab.transform.rotation);
    }
    
    Vector3 RandomSpawn(SpawnType type)
    {
        return new Vector3(Random.Range(-20.0f, 20.0f), GetYPositionForSpawnType(type), Random.Range(-20.0f, 20.0f));
    }
    private float GetYPositionForSpawnType(SpawnType type)
    {
        if (type == SpawnType.Consumable)
        {
            return 0.5f;
        }
        else if (type == SpawnType.Obstacle)
        {
            return 1f;
        }

        throw new Exception($"Not supported enum value {type}");
    }
}
