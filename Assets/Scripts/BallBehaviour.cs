using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]GameObject ball;
    [SerializeField]float upwardForce=-15; //Always write f after float variables
    [SerializeField]float forwardForce=20;  
    
    private Vector3 screenPosition;
    private Vector3 worldPosition;
    private Vector3 spawnPoint;
    private Rigidbody rb;
    
    private Camera mainCamera;  //I Changed it to mainCamera from MainCamera


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;   //You can use Camera.main instead GetComponent (GetComponent allocates memory even if no element is found) 
                                    //to get the reference to main camera. It's preferable since it's predefined and has less chance of errors...
    }

    // Update is called once per frame
    void Update()
    {
        //Code for mouse position
        screenPosition=Input.mousePosition;
        screenPosition.z=Camera.main.nearClipPlane +1;
        worldPosition=Camera.main.ScreenToWorldPoint(screenPosition);
        spawnPoint=mainCamera.transform.position;
        spawnPoint.z+=2;


        //Code for ball initialization and destruction
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject SpawnedBall = Instantiate(ball,spawnPoint,Quaternion.identity);  //The ball should be named spawnedBall (Naming rule violation)
            rb=SpawnedBall.GetComponent<Rigidbody>();
            rb.AddForce(transform.up*upwardForce,ForceMode.Impulse);    //Upward Impulse
            rb.AddForce(worldPosition*forwardForce,ForceMode.Impulse);  //Forward Impulse
            Destroy(SpawnedBall,4f);        //Destroy ball entity
        }

        //Also a suggestion: Try to give space in between variables and operators (It'll be a lot more readable for someone else reading your code)

    }    
}
