using UnityEngine;

namespace TT.Extensions
{
    public static class MonoBehaviourExtensions
    {
        static public T GetOrAddComponent<T>(this MonoBehaviour script) where T : Component
        {
            T result = script.gameObject.GetComponent<T>();
            if (result == null)
            {
                result = script.gameObject.AddComponent<T>();
            }
            return result;
        }

        public static RectTransform RTrans(this MonoBehaviour script)
        {
            return script.gameObject.GetComponent<RectTransform>();
        }
    }
}
