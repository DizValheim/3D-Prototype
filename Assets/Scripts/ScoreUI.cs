using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Transform cameraPosition;  //Player Camera
    [SerializeField] TextMeshProUGUI scoreToBeShown;

    // Update is called once per frame
    void Update()
    {
        scoreToBeShown.text = cameraPosition.position.z.ToString("0");
    }
}
