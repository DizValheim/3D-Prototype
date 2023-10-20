//PLEASE USE THIS AS EXAMPLE TEMPLATE FOR OUR FUTURE SCRIPTS. 
//EVERYTHING SHOULD BE UNDER "Ariston" NAMESPACE. 
//LATER SUB-NAMESPACES WOULD BE ADDED LIKE "Ariston.InteractableObjects".
using UnityEngine;

namespace Ariston
{
    public class BallBehaviour : MonoBehaviour
    {
        #region Variables
        [SerializeField] private GameObject ball;
        [SerializeField] private float forceMagnitude = 10f;

        private float despawnTime = 4f; //I made this a variable for easier modification while testing (this can be serialized if required)
        private Rigidbody rb;
        
        private Camera mainCamera;

        #endregion 

        #region Unity Functions
        
        // Start is called before the first frame update
        void Start()
        {
            mainCamera = Camera.main;   //You can use Camera.main instead GetComponent (GetComponent allocates memory even if no element is found) 
                                        //to get the reference to main camera. It's preferable since it's predefined and has less chance of errors...
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                // RaycastHit hit;      // We can also inline this declaration inside the if condition like done below!!
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //Ray is basically what it sounds like.. and I hope you understand rest of this line 
                                                                            //since the name of the methods kind of justify it

                if (Physics.Raycast(ray, out RaycastHit hit))       //Here you can see I declared RaycastHit inside the if condition after out keyword 
                                                                    //(Which makes the variable accessible even outside the if statement. It'll be used 
                                                                    //often with raycasts since you need the hit point)  
                {

                    GameObject spawnedObject = Instantiate(ball, mainCamera.transform.position, Quaternion.identity);

                    // Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();      //Due to the memory allocation problem here I used TryGetComponent instead of GetComponent
                    if (spawnedObject.TryGetComponent<Rigidbody>(out rb))           //So here we can again see the use of out keyword to get the reference 
                                                                                    //out of the method (I'm assuming you understand what the out keyword 
                                                                                    //does by now.. still if there's any doubt ask in the appropriate channels or during meetings)
                    {
                        Vector3 forceDirection = (hit.point - mainCamera.transform.position).normalized;
                        rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
                    }
                    Destroy(spawnedObject,despawnTime);
                }
            }
        }

        #endregion
    }

}