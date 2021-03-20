using UnityEngine;

namespace Code.Managers
{
    public class TAAbstractManager<T> : MonoBehaviour
        where T : TAAbstractManager<T>
    {
        private static T _instance = null;

        public void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
            }
        }

        public static T Shared()
        {
            return _instance;
        }
    }
}