using System.Collections;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 4.0f; // Set the delay time here
    void OnCollisionEnter(Collision collidedObject)
    {
        if(collidedObject.gameObject.CompareTag("Balls"))
        {
            Destroy(gameObject, delayInSeconds);
        }
    }
}
