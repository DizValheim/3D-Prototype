using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallCountUI : MonoBehaviour
{
    public BallBehaviour actualCount;      //Actual ball count from Ball Behaviour script
    [SerializeField] TextMeshProUGUI countToBeShown;    //Text mesh pro component

    void Update()
    {
        countToBeShown.SetText("Balls Left: {10}", actualCount.ballCount);
    }
}
