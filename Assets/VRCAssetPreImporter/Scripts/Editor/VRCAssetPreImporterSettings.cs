using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class VRCAssetPreImporterSettings
{
    public static BlendShapeNormalsMode BlendShapeNormals
    {
        get
        {
            string normalMode = EditorPrefs.GetString("VRCAssetPreProcessor_BlendShapeNormalsMode", "legacy");
            switch (normalMode)
            {
                case "default":
                    return BlendShapeNormalsMode.Default;
                case "legacy":
                    return BlendShapeNormalsMode.Legacy;
                case "import":
                    return BlendShapeNormalsMode.Import;
                case "none":
                    return BlendShapeNormalsMode.None;
                default:
                    return BlendShapeNormalsMode.Legacy;
            }
        }
        set
        {
            switch (value)
            {
                case BlendShapeNormalsMode.Default:
                    EditorPrefs.SetString("VRCAssetPreProcessor_BlendShapeNormalsMode", "default");
                    break;
                case BlendShapeNormalsMode.Legacy:
                    EditorPrefs.SetString("VRCAssetPreProcessor_BlendShapeNormalsMode", "legacy");
                    break;
                case BlendShapeNormalsMode.Import:
                    EditorPrefs.SetString("VRCAssetPreProcessor_BlendShapeNormalsMode", "import");
                    break;
                case BlendShapeNormalsMode.None:
                    EditorPrefs.SetString("VRCAssetPreProcessor_BlendShapeNormalsMode", "none");
                    break;
                default:
                    throw new ArgumentException("Value must be one of default, legacy, import or none");
            }
        }
    }

    public static bool StreamingMipmaps
    {
        get
        {
            return EditorPrefs.GetBool("VRCAssetPreProcessor_StreamingMipmaps", true);
        }
        set
        {
            EditorPrefs.SetBool("VRCAssetPreProcessor_StreamingMipmaps", value);
        }
    }

    public static bool AlphaIsTransparency
    {
        get
        {
            return EditorPrefs.GetBool("VRCAssetPreProcessor_AlphaIsTransparency", true);
        }
        set
        {
            EditorPrefs.SetBool("VRCAssetPreProcessor_AlphaIsTransparency", value);
        }
    }

    public static int MaxTextureSize
    {
        get
        {
            return EditorPrefs.GetInt("VRCAssetPreProcessor_MaxTextureSize", 2048);
        }
        set
        {
            EditorPrefs.SetInt("VRCAssetPreProcessor_MaxTextureSize", value);
        }
    }

    public static TextureCompressionQuality TextureCompressionLevel
    {
        get
        {
            string textureCompression = EditorPrefs.GetString("VRCAssetPreProcessor_TextureCompressionLevel", "normal");
            switch (textureCompression)
            {
                case "low":
                    return TextureCompressionQuality.Low;
                case "normal":
                    return TextureCompressionQuality.Normal;
                case "high":
                    return TextureCompressionQuality.High;
                case "none":
                    return TextureCompressionQuality.None;
                default:
                    return TextureCompressionQuality.Normal;
            }
        }
        set
        {
            switch (value)
            {
                case TextureCompressionQuality.Low:
                    EditorPrefs.SetString("VRCAssetPreProcessor_TextureCompressionLevel", "low");
                    break;
                case TextureCompressionQuality.Normal:
                    EditorPrefs.SetString("VRCAssetPreProcessor_TextureCompressionLevel", "normal");
                    break;
                case TextureCompressionQuality.High:
                    EditorPrefs.SetString("VRCAssetPreProcessor_TextureCompressionLevel", "high");
                    break;
                case TextureCompressionQuality.None:
                    EditorPrefs.SetString("VRCAssetPreProcessor_TextureCompressionLevel", "none");
                    break;
                default:
                    throw new ArgumentException("Value must be one of low, normal, high or none");
            }
        }
    }

    public static bool LoggingEnabled
    {
        get
        {
            return EditorPrefs.GetBool("VRCAssetPreProcessor_EnableLogging", true);
        }
        set
        {
            EditorPrefs.SetBool("VRCAssetPreProcessor_EnableLogging", value);
        }
    }

    public enum BlendShapeNormalsMode
    {
        Default,
        Legacy,
        Import,
        None
    }

    // Hacky workaround to show friendlier names in the menu
    public enum TextureCompressionQuality
    {
        None = TextureImporterCompression.Uncompressed,
        Low = TextureImporterCompression.CompressedLQ,
        Normal = TextureImporterCompression.Compressed,
        High = TextureImporterCompression.CompressedHQ
    }
}
