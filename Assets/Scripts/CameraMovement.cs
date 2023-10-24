using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    Vector3 posToAdd = new();
    GameObject cameraParent;

    // Start is called before the first frame update
    void Start()
    {
        posToAdd = new Vector3(0, 0, speed * Time.deltaTime);
        cameraParent = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        cameraParent.transform.position += posToAdd;
    }
}