using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    Vector3 posToAdd = new();
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        posToAdd = new Vector3(0, 0, speed * Time.deltaTime);
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position += posToAdd;
    }
}