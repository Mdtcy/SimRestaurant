using UnityEngine;

namespace TT.Extensions
{
    public static class PlayerPrefsEx
    {
        public static string GetString(string key, string fallback = "")
        {
            if (PlayerPrefs.HasKey(key))
            {
                return PlayerPrefs.GetString(key);
            }
            return fallback;
        }

        public static float GetFloat(string key, float fallback = 0f)
        {
            if (PlayerPrefs.HasKey(key))
            {
                return PlayerPrefs.GetFloat(key);
            }
            return fallback;
        }

        public static int GetInt(string key, int fallback = 0)
        {
            if (PlayerPrefs.HasKey(key))
            {
                return PlayerPrefs.GetInt(key);
            }
            return fallback;
        }

        public static int AccumGetInt(string key, int start = 0, int step = 1)
        {
            var cur = GetInt(key, start);
            PlayerPrefs.SetInt(key, cur + step);
            return cur;
        }
    }
}
