using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    void Start()
    {
    }
    void Update()
    {
        UpdateMovement();
        CheckBoundaries();

    }

    void UpdateMovement()
    {
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        if (GameObject.Find("Player").GetComponent<DetectCollisions>().hasPowerUp)
        {
            playerSpeed = 15f;
        }
        else
        {
            playerSpeed = 7.5f;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 1, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -1, 0);
        }
    }

    private float limit = 20.0f;
    void CheckBoundaries()
    {
        if (transform.position.x > limit || transform.position.x < -limit || transform.position.z > limit || transform.position.z < -limit)
        {
            transform.Rotate(0.0f, transform.rotation.y + 90.0f, 0.0f);
            Debug.Log("Game Over");
        }
    }
}
