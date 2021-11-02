using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GoalController : MonoBehaviour
{
    private float speed = 10;
    private Rigidbody goalRb;

    private Vector3 startMarker;
    private Vector3 endMarker;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float startTime;
    private float pathLength;
    private float limit = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        goalRb = GetComponent<Rigidbody>();
        goalRb.AddForce(Vector3.down, ForceMode.Force);
        
        startMarker = transform.position;
        startRotation = transform.rotation;
        endMarker = new Vector3(getRandomPos(), transform.position.y, getRandomPos());
        
        // TODO: Fix the startRotation to be in the direction of new endMarker
        
        endRotation = Quaternion.Euler(0f, 150f, 0f);
        startTime = Time.time;
    }
    

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        CheckBoundaries();
    }
    void UpdateMovement()
    {
        MoveToSpot();
    }

    void MoveToSpot()
    {
        if (endMarker == transform.position)
        {
           StartCoroutine(ChangeMarkers());
        }
        
        pathLength = Vector3.Distance(startMarker, endMarker);
        float distCovered = (Time.time - startTime) * speed;
        float pathProgress = distCovered / pathLength;

        transform.position = Vector3.Lerp(startMarker, endMarker, pathProgress);
        transform.rotation = Quaternion.Lerp(startRotation, endRotation, pathProgress);
    }

    IEnumerator ChangeMarkers()
    {
        // TODO: Add new rotation start and end points
        
        startMarker = endMarker;
        endMarker = new Vector3(getRandomPos(), transform.position.y, getRandomPos());
        startTime = Time.time;
        yield return null;
    }

    float getRandomPos()
    {
        return Random.Range(-20f, 20f);
    }

    void CheckBoundaries()
    {
        if (transform.position.x > limit || transform.position.x < -limit || transform.position.z > limit || transform.position.z < -limit)
        {
            transform.Rotate(0.0f, transform.rotation.y + 90.0f, 0.0f);
        }
    }
    
}
