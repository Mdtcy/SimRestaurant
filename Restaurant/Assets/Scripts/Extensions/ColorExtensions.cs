using UnityEngine;
using UnityEngine.UI;

namespace TT.Extensions
{
    public static class ColorExtensions
    {
        public static void SetAlpha(this SpriteRenderer sp, int alpha)
        {
            var c = sp.color;
            c.a = alpha;
            sp.color = c;
        }

        public static void SetAlpha(this Image sp, int alpha)
        {
            var c = sp.color;
            c.a = alpha / 255f;
            sp.color = c;
        }

        public static float GetAlpha(this Image img)
        {
            return img != null ? img.color.a : 0;
        }

        public static void SetAlpha(this Image sp, float alpha)
        {
            var c = sp.color;
            c.a = alpha;
            sp.color = c;
        }

        public static void SetAlpha(this Graphic txt, int alpha)
        {
            var c = txt.color;
            c.a = alpha;
            txt.color = c;
        }

        public static Color GetRandomColor(bool fullAlpha = false)
        {
            return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f),
                             UnityEngine.Random.Range(0f, 1f), fullAlpha ? 1f : UnityEngine.Random.Range(0f, 1f));
        }
    }
}