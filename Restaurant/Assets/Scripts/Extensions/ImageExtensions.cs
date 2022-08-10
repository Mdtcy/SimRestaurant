using UnityEngine;
using UnityEngine.UI;

namespace TT.Extensions {
	public static class ImageExtensions
	{
        public static void SetSpriteAndFit(this Image image, Sprite sprite)
        {
            image.sprite = sprite;
            image.SetNativeSize();
        }

        public static void FitWithinSize(this Image image, Vector2 size)
        {
            image.SetNativeSize();
            var imgSize = image.rectTransform.GetSize();
            // 等比缩放，不能超过size
            float scale = Mathf.Min(size.x / imgSize.x, size.y / imgSize.y);
            var newScale = new Vector3(scale, scale, image.transform.localScale.z);
            image.transform.localScale = newScale;
        }
    }
}
