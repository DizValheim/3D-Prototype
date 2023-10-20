using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    Vector3 ForceToAdd = new Vector3(); //You can use new() (but I think you already know ;))
    Camera MainCamera = new Camera();   //This is a major blunder!! Camera is an ingame object so it shouldn't be instantiated like this
                                        //but I leave the changes to you so that it'll be easier to remember!!
                                        //Because all ingame objects are instantiated using Instantiate() method!!
                                        //You can just declare a var of type camera like this: Camera mainCamera; (Remember this doesn't point 
                                        //anywhere(and it shouldn't) until you get the reference to camera in the start method)
                                        //Also rename the variables according to naming conventions :)


    // Start is called before the first frame update
    void Start()
    {
        ForceToAdd = new Vector3(0, 0, speed * Time.deltaTime);
        MainCamera = GetComponent<Camera>();      //This can be fixed also!! but I leave that to you for practice :)
    }

    // Update is called once per frame
    void Update()
    {
        MainCamera.transform.position+=ForceToAdd;  //here you are actually adding values to the camera's position 
                                                    //Which technically isn't "force" therefore the variable should be named something like posToAdd but it's totally upto you
    }
}

//BUT OVERALL THESE ARE PRETTY WELL WRITTEN CODE COMPARED TO MY FIRST UNITY SCRIPTS SO DON'T THINK THAT I'M PICKING OUT MISTAKES (I'M JUST SUGGESTING A BETTER WAY :))
