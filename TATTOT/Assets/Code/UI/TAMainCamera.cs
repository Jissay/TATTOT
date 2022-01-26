using UnityEngine;

namespace Code.UI
{
    public class TAMainCamera : MonoBehaviour
    {
        #region Movement parameters

        private const int Speed = 100;

        private static Vector3 UpDirection => new Vector3(0, Speed * Time.deltaTime, 0);
        private static Vector3 RightDirection => new Vector3(Speed * Time.deltaTime, 0);
        private static Vector3 DownDirection => new Vector3(0, -Speed * Time.deltaTime, 0);
        private static Vector3 LeftDirection => new Vector3(-Speed * Time.deltaTime, 0, 0);

        #endregion

        #region Zoom parameters

        private float _minZIndex;

        private const float Sensitivity = 100f;
        private const float MaxZIndex = -15f;

        #endregion

        private void Start()
        {
            _minZIndex = transform.position.z;
        }

        private void Update()
        {
            MoveCameraIfNeeded();
            ZoomCameraIfNeeded();
        }

        private void MoveCameraIfNeeded()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(RightDirection);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(LeftDirection);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(DownDirection);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(UpDirection);
            }
        }

        private void ZoomCameraIfNeeded()
        {
            var scroll = Input.GetAxis("Mouse ScrollWheel") * Sensitivity;
            if (scroll + transform.position.z >= _minZIndex && scroll + transform.position.z <= MaxZIndex)
            {
                transform.Translate(0, 0, scroll);
            }
        }
    }
}