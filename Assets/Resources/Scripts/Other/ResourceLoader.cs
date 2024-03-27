using System.Collections.Generic;
using System.Linq;
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
            return obj.GetComponent<T>();
        }

        public static T Load<T>(string path) where T : Object =>
            Resources.Load<T>(path);

        public static List<T> LoadAll<T>(string path) where T : Object =>
            Resources.LoadAll<T>(path).ToList();
    }
}