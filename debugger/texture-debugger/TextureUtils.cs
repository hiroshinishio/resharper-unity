using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using Graphics = UnityEngine.Graphics;
using Object = UnityEngine.Object;

namespace JetBrains.Debugger.Worker.Plugins.Unity.Presentation.Texture
{
    [SuppressMessage("ReSharper", "NotAccessedField.Global")] //used by frontend
    public class TexturePixelsInfo
    {
        public int Width;
        public int Height;
        public int[] Pixels;
        public int OriginalWidth;
        public int OriginalHeight;
        public string GraphicsTextureFormat;
        public string TextureName;
        public bool HasAlphaChannel;

        public TexturePixelsInfo(Size size, Color32[] pixels, UnityEngine.Texture texture)
        {
            Pixels = pixels.Select(c => c.ToHex()).ToArray();
            Width = size.Width;
            Height = size.Height;
            TextureName = texture.name;
            GraphicsTextureFormat = texture.graphicsFormat.ToString();
            OriginalWidth = texture.width;
            OriginalHeight = texture.height;
            HasAlphaChannel = GraphicsFormatUtility.HasAlphaChannel(texture.graphicsFormat);
        }
    }

    public static class UnityTextureAdapter
    {
        public static int ToHex(this Color32 c)
        {
            return (c.a << 24) | (c.r << 16) | (c.g << 8) | c.b;
        }

        // ReSharper disable once UnusedMember.Global
        public static string GetPixelsInString(Texture2D texture2D) //Called by debugger evaluator
        {
            return GetPixelsInString(texture2D, new Size(texture2D.width, texture2D.height));
        }

        public static string GetPixelsInString(Texture2D texture2D, Size size)
        {
            size = GetTextureConvertedSize(texture2D, size);
            var color32 = GetPixels(texture2D, size);
            return JsonUtility.ToJson(color32, true);
        }

        private static TexturePixelsInfo GetPixels(UnityEngine.Texture texture2d, Size size)
        {
            var targetTexture = CreateTargetTexture(size);

            try
            {
                CopyTexture(texture2d, targetTexture);
                var pixels = targetTexture.GetPixels32();
                var texturePixelsInfo = new TexturePixelsInfo(new Size(targetTexture.width, targetTexture.height)
                    , pixels
                    , texture2d);
                return texturePixelsInfo;
            }
            finally
            {
                Object.DestroyImmediate(targetTexture);
            }
        }

        private static byte[] GetRawBytes(UnityEngine.Texture texture2d, Size size)
        {
            var targetTexture = CreateTargetTexture(size);
            CopyTexture(texture2d, targetTexture);
            var rawTextureData = targetTexture.GetRawTextureData();
            Object.DestroyImmediate(targetTexture);
            return rawTextureData;
        }

        private static void CopyTexture(UnityEngine.Texture texture, Texture2D targetTexture)
        {
            var renderTexture = RenderTexture.GetTemporary(
                targetTexture.width,
                targetTexture.height,
                0,
                RenderTextureFormat.ARGB32
            );

            try
            {
                // Blit the pixels on texture to the RenderTexture
                Graphics.Blit(texture, renderTexture);

                // Copy the pixels from the RenderTexture to the new Texture
                targetTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
                targetTexture.Apply();
            }
            finally
            {
                // Release the temporary RenderTexture
                RenderTexture.ReleaseTemporary(renderTexture);
            }
        }

        private static Texture2D CreateTargetTexture(Size size)
        {
            var texture2D = new Texture2D(size.Width, size.Height, TextureFormat.RGBA32, false);
            return texture2D;
        }

        private static Size GetTextureConvertedSize(UnityEngine.Texture texture2d, Size size)
        {
            var texture2dWidth = texture2d.width;
            var texture2dHeight = texture2d.height;

            var divider = 1;
            while (texture2dWidth / divider > size.Width && texture2dHeight / divider > size.Height)
                divider *= 2;

            var targetTextureWidth = texture2dWidth / divider;
            var targetTextureHeight = texture2dHeight / divider;
            return new Size(targetTextureWidth, targetTextureHeight);
        }
    }
}