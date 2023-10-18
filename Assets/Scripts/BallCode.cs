using UnityEngine;

public class BallCode : MonoBehaviour
{
    [SerializeField]GameObject ball;
    [SerializeField]float UpwardForce;
    [SerializeField]float ForwardForce;
    public Vector3 ScreenPosition, WorldPosition, SpawnPoint;
    public Rigidbody rb;
    
    public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera=GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Code for mouse position
        ScreenPosition=Input.mousePosition;
        ScreenPosition.z=Camera.main.nearClipPlane +1;
        WorldPosition=Camera.main.ScreenToWorldPoint(ScreenPosition);
        SpawnPoint=MainCamera.transform.position;
        SpawnPoint.z+=2;


        //Code for ball initialization and destruction
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject SpawnedBall=Instantiate(ball,SpawnPoint,Quaternion.identity);
            rb=SpawnedBall.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.up*UpwardForce,ForceMode.Impulse);    //Upward Impulse
            rb.AddForce(WorldPosition*ForwardForce,ForceMode.Impulse);  //Forward Impulse
            Destroy(SpawnedBall,4f);        //Destroy ball entity
        }
    }
}
