using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float forwardForce = 20f;

    private Vector3 screenPosition;
    private Vector3 worldPosition;
    private Vector3 spawnPoint;
    private Rigidbody rb;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Code for mouse position
        screenPosition = Input.mousePosition;
        screenPosition.z = mainCamera.nearClipPlane + 1;
        worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
        spawnPoint = mainCamera.transform.position;
        spawnPoint.z += 1;

        // Code for ball initialization and destruction
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject spawnedBall = Instantiate(ball, spawnPoint, Quaternion.identity);
            rb = spawnedBall.GetComponent<Rigidbody>();

            // Calculate the direction vector from the ball's position to the world position of the mouse click
            Vector3 direction = (worldPosition - mainCamera.transform.position).normalized;

            // Apply the forward impulse in the direction of the mouse click
            rb.AddForce(direction * forwardForce, ForceMode.Impulse);

            // Destroy ball entity
            Destroy(spawnedBall, 4f);
        }
    }
}