using System.Collections.Generic;
using System;
using UnityEngine;

namespace TT.DataStructures
{
    /// <summary>
    /// Serializable Dictionary
    /// http://answers.unity3d.com/questions/460727/how-to-serialize-dictionary-with-unity-serializati.html
    /// </summary>
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        /// <summary>
        /// keys
        /// </summary>
        [SerializeField] private List<TKey> keys = new List<TKey>();

        /// <summary>
        /// values
        /// </summary>
        [SerializeField] private List<TValue> values = new List<TValue>();

        /// <summary>
        /// save the dictionary to lists
        /// </summary>
        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();
            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }

        /// <summary>
        /// load dictionary from lists
        /// </summary>
        public void OnAfterDeserialize()
        {
            this.Clear();

            if (keys.Count != values.Count)
            {
                throw new System.Exception(string.Format(
                    "there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));
            }

            for (int i = 0; i < keys.Count; i++)
            {
                this.Add(keys[i], values[i]);
            }
        }
    }
}