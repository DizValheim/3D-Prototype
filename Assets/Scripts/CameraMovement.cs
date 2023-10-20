using UnityEngine;

namespace Ariston
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]float moveSpeed = 0f;
        private Vector3 moveDirection = Vector3.forward;

        void Update()
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}

