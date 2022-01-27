using Code.ResourcesLoaders;
using UnityEngine;

namespace Code.UI
{
    public class TAMainCamera : MonoBehaviour
    {
        #region Movement parameters

        private const int CameraKeyboardMoveSpeed = 100;
        private const int CameraDragSpeed = 3;

        private static Vector3 UpDirection => new Vector3(0, CameraKeyboardMoveSpeed * Time.deltaTime, 0);
        private static Vector3 RightDirection => new Vector3(CameraKeyboardMoveSpeed * Time.deltaTime, 0);
        private static Vector3 DownDirection => new Vector3(0, -CameraKeyboardMoveSpeed * Time.deltaTime, 0);
        private static Vector3 LeftDirection => new Vector3(-CameraKeyboardMoveSpeed * Time.deltaTime, 0, 0);
        
        private Vector3 _mouseOrigin;

        #endregion

        #region Zoom parameters
        
        private const float CameraScrollSensitivity = 100f;
        private const float CameraScrollMaxZIndex = -15f;
        
        private float _minZIndex;

        #endregion

        #region MonoBehaviour lifecycle

        private void Start()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            _minZIndex = transform.position.z;
        }

        private void LateUpdate()
        {
            MoveCameraOnKeyboardPress();
            MoveCameraOnMouseDrag();
            ZoomCameraIfNeeded();
        }

        #endregion

        #region Camera movement

        /// <summary>
        /// Move the camera if the current key press is one that should be moving the camera.
        /// Multiple if are used as we want the camera to being able to be translated in
        /// multiple directions. That could happen if the user presses two directions at a time.
        /// </summary>
        private void MoveCameraOnKeyboardPress()
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

        private void MoveCameraOnMouseDrag()
        {
            // Store dragging position 
            if (Input.GetMouseButtonDown(1))
            {
                _mouseOrigin = Input.mousePosition;
                return;
            }
            
            // Move camera on X & Y while button isn't released
            if (Camera.main is null || !Input.GetMouseButton(1))
            {
                // Reset the cursor to it's initial value
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                return;
            }

            // Set cursor to camera move cursor
            Cursor.SetCursor(TATextureLoader.CameraMoveCursor, Vector2.zero, CursorMode.Auto);
            
            // Update x and y axis position, relatively to where the mouse point in the world
            var pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - _mouseOrigin);
            var move = new Vector3 (pos.x * CameraDragSpeed, pos.y * CameraDragSpeed, 0);
            Camera.main.transform.Translate (move, Space.World);
        }

        #endregion

        #region Camera zoom

        /// <summary>
        /// Zoom the camera if the user is scrolling in or out with his mouse wheel.
        /// </summary>
        private void ZoomCameraIfNeeded()
        {
            var scroll = Input.GetAxis("Mouse ScrollWheel") * CameraScrollSensitivity;
            if (scroll + transform.position.z >= _minZIndex &&
                scroll + transform.position.z <= CameraScrollMaxZIndex)
            {
                transform.Translate(0, 0, scroll);
            }
        }

        #endregion
    }
}