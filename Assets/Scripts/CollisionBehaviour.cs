using UnityEngine;
using System.Collections;

public class CollisionBehaviour : MonoBehaviour
{
    public CameraMovement camMovement;
    public BallBehaviour ballBehaviour;
    [SerializeField] float delayInSeconds = 3.0f; // Set the delay time here

    void OnTriggerEnter(Collider collidedObject)
    {
        if(collidedObject.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(DisableScriptsAfterDelay());
        }
    }

    IEnumerator DisableScriptsAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        camMovement.enabled = false;
        ballBehaviour.enabled = false;
    }
}