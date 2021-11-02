using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DetectCollisions : MonoBehaviour
{
    public GameObject goalPrefab;
    public GameObject obstaclePrefab;
    private Vector3 randomSpawn;
    public bool hasPowerUp = false;
    public GameObject powerUpIndicator;
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
        if (Input.GetKey(KeyCode.Space) && other.gameObject.CompareTag("Goal"))
        {
            Destroy(other.gameObject);
            RespawnGoal();
            StartCoroutine(SpawnObstacle(transform.position));
        }

        if (other.gameObject.CompareTag("Consumable"))
        {
            Debug.Log("Power Up!");
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            StartCoroutine(ActivatePowerUp());
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }

    void RespawnGoal()
    {
        randomSpawn = new Vector3(Random.Range(-20.0f, 20.0f), 0f, Random.Range(-20.0f, 20.0f));
        Instantiate(goalPrefab, randomSpawn, goalPrefab.transform.rotation);
    }

    IEnumerator SpawnObstacle(Vector3 pos)
    {
        yield return new WaitForSeconds(1);
        Instantiate(obstaclePrefab, pos+new Vector3(0, 1f, 0), obstaclePrefab.transform.rotation);
    }

    IEnumerator ActivatePowerUp()
    {
        yield return new WaitForSeconds(4);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }
    
}
