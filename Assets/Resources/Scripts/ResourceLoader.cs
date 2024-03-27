using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Amaya
{
    public class ResourceLoader : MonoBehaviour
    {
        public static GameObject Instantiate(string prefabPath, Transform parent)
        {
            var obj = Resources.Load<GameObject>(prefabPath);
            return Object.Instantiate(obj, parent);

        }

        public static T Instantiate<T>(string prefabPath, Transform parent) where T : MonoBehaviour
        {
            var obj = Instantiate(prefabPath, parent);
            return obj.AddComponent<T>();
        }
    }
}