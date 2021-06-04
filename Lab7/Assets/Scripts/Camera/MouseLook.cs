using UnityEngine;
using Fayet.Tracking;

namespace Fayet.Camera.FPS
{
    public class MouseLook : MonoBehaviour, ICursorable
    {
        [SerializeField] private float mouseSensitivity = 100f;
        [SerializeField] private Transform playerBody;

        private float xRotation = 0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Move(float x, float y)
        {
            float mouseX = x * mouseSensitivity * Time.deltaTime;
            float mouseY = y * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

        public void TrackCursor(float horizontal, float vertical)
        {
            Move(horizontal, vertical);
        }
    }

}