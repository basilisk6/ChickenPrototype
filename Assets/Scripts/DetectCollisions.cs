using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DetectCollisions : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject obstaclePrefab;
    private Vector3 randomSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey(KeyCode.Space) && other.gameObject.CompareTag("Fish"))
        {
            Destroy(other.gameObject);
            RespawnFish();
            StartCoroutine(SpawnObstacle(transform.position));
        }

        if (other.gameObject.CompareTag("Consumable"))
        {
            Debug.Log("Power Up!");
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }

    void RespawnFish()
    {
        randomSpawn = new Vector3(Random.Range(-20.0f, 20.0f), -0.7f, Random.Range(-20.0f, 20.0f));
        Instantiate(fishPrefab, randomSpawn, fishPrefab.transform.rotation);
    }

    IEnumerator SpawnObstacle(Vector3 pos)
    {
        yield return new WaitForSeconds(1);
        Instantiate(obstaclePrefab, pos, obstaclePrefab.transform.rotation);
    }
}
