using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]float speed=0f;
    Vector3 ForceToAdd=new Vector3();
    Camera MainCamera=new Camera();
    // Start is called before the first frame update
    void Start()
    {
        ForceToAdd=new Vector3(0,0,speed*Time.deltaTime);
        MainCamera=GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MainCamera.transform.position+=ForceToAdd;
    }
}
