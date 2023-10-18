using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]GameObject ball;
    [SerializeField]float upwardForce=-15;
    [SerializeField]float forwardForce=20;
    private Vector3 screenPosition;
    private Vector3 worldPosition;
    private Vector3 spawnPoint;
    private Rigidbody rb;
    
    private Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera=GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Code for mouse position
        screenPosition=Input.mousePosition;
        screenPosition.z=Camera.main.nearClipPlane +1;
        worldPosition=Camera.main.ScreenToWorldPoint(screenPosition);
        spawnPoint=MainCamera.transform.position;
        spawnPoint.z+=2;


        //Code for ball initialization and destruction
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject SpawnedBall=Instantiate(ball,spawnPoint,Quaternion.identity);
            rb=SpawnedBall.GetComponent<Rigidbody>();
            rb.AddForce(transform.up*upwardForce,ForceMode.Impulse);    //Upward Impulse
            rb.AddForce(worldPosition*forwardForce,ForceMode.Impulse);  //Forward Impulse
            Destroy(SpawnedBall,4f);        //Destroy ball entity
        }
    }
}
