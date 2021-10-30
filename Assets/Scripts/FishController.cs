using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class FishController : MonoBehaviour
{
    private float speed = 10;
    private Rigidbody fishRb;

    private Vector3 startMarker;
    private Vector3 endMarker;
    private float startTime;
    private float pathLength;
    private float limit = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        fishRb = GetComponent<Rigidbody>();
        fishRb.AddForce(Vector3.down, ForceMode.Force);
        
        startMarker = transform.position;
        endMarker = new Vector3(getRandomPos(), transform.position.y, getRandomPos());
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
        pathLength = Vector3.Distance(startMarker, endMarker);
        float distCovered = (Time.time - startTime) * speed;
        float pathProgress = distCovered / pathLength;

        if (endMarker == transform.position)
        {
           StartCoroutine(ChangeMarkers());
        }
        transform.position = Vector3.Lerp(startMarker, endMarker, pathProgress);
    }

    IEnumerator ChangeMarkers()
    {
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
            //transform.position = new Vector3(0.0f, -0.7f, 0.0f);
            transform.Rotate(0.0f, transform.rotation.y + 90.0f, 0.0f);
        }
    }
    
}
