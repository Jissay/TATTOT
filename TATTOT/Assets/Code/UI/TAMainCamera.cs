using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.UI
{
    public class TAMainCamera : MonoBehaviour
    {
        private const int Speed = 100;
        
        private static Vector3 UpDirection => new Vector3(0, Speed * Time.deltaTime, 0);
        private static Vector3 RightDirection => new Vector3(Speed * Time.deltaTime, 0);
        private static Vector3 DownDirection => new Vector3(0, -Speed * Time.deltaTime, 0);
        private static Vector3 LeftDirection => new Vector3(-Speed * Time.deltaTime, 0, 0);

        private void Update()
        {
            if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(RightDirection);
            }
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(LeftDirection);
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(DownDirection);
            }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(UpDirection);
            }
        }
    }
}