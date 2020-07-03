using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class VRCAssetPreImporterSettings
{
    public static VRCAssetPostProcessorEnums.BlendShapeNormalsMode BlendShapeNormals
    {
        get
        {
            string normalMode = EditorPrefs.GetString("VRCAssetPreProcessor_BlendShapeNormalsMode", "legacy");
            switch (normalMode)
            {
                case "default":
                    return VRCAssetPostProcessorEnums.BlendShapeNormalsMode.Default;
                case "legacy":
                    return VRCAssetPostProcessorEnums.BlendShapeNormalsMode.Legacy;
                case "import":
                    return VRCAssetPostProcessorEnums.BlendShapeNormalsMode.Import;
                case "none":
                    return VRCAssetPostProcessorEnums.BlendShapeNormalsMode.None;
                default:
                    return VRCAssetPostProcessorEnums.BlendShapeNormalsMode.Legacy;
            }
        }
        set
        {
            switch (value)
            {
                case VRCAssetPostProcessorEnums.BlendShapeNormalsMode.Default:
                    EditorPrefs.SetString("VRCAssetPreProcessor_BlendShapeNormalsMode", "default");
                    break;
                case VRCAssetPostProcessorEnums.BlendShapeNormalsMode.Legacy:
                    EditorPrefs.SetString("VRCAssetPreProcessor_BlendShapeNormalsMode", "legacy");
                    break;
                case VRCAssetPostProcessorEnums.BlendShapeNormalsMode.Import:
                    EditorPrefs.SetString("VRCAssetPreProcessor_BlendShapeNormalsMode", "import");
                    break;
                case VRCAssetPostProcessorEnums.BlendShapeNormalsMode.None:
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

    public static VRCAssetPostProcessorEnums.TextureCompressionQuality TextureCompressionLevel
    {
        get
        {
            string textureCompression = EditorPrefs.GetString("VRCAssetPreProcessor_TextureCompressionLevel", "normal");
            switch (textureCompression)
            {
                case "low":
                    return VRCAssetPostProcessorEnums.TextureCompressionQuality.Low;
                case "normal":
                    return VRCAssetPostProcessorEnums.TextureCompressionQuality.Normal;
                case "high":
                    return VRCAssetPostProcessorEnums.TextureCompressionQuality.High;
                case "none":
                    return VRCAssetPostProcessorEnums.TextureCompressionQuality.None;
                default:
                    return VRCAssetPostProcessorEnums.TextureCompressionQuality.Normal;
            }
        }
        set
        {
            switch (value)
            {
                case VRCAssetPostProcessorEnums.TextureCompressionQuality.Low:
                    EditorPrefs.SetString("VRCAssetPreProcessor_TextureCompressionLevel", "low");
                    break;
                case VRCAssetPostProcessorEnums.TextureCompressionQuality.Normal:
                    EditorPrefs.SetString("VRCAssetPreProcessor_TextureCompressionLevel", "normal");
                    break;
                case VRCAssetPostProcessorEnums.TextureCompressionQuality.High:
                    EditorPrefs.SetString("VRCAssetPreProcessor_TextureCompressionLevel", "high");
                    break;
                case VRCAssetPostProcessorEnums.TextureCompressionQuality.None:
                    EditorPrefs.SetString("VRCAssetPreProcessor_TextureCompressionLevel", "none");
                    break;
                default:
                    throw new ArgumentException("Value must be one of low, normal, high or none");
            }
        }
    }

    public static bool UseCrunch
    {
        get
        {
            return EditorPrefs.GetBool("VRCAssetPreProcessor_UseCrunch", false);
        }
        set
        {
            EditorPrefs.SetBool("VRCAssetPreProcessor_UseCrunch", value);
        }
    }

    public static bool LinearizeMaps
    {
        get
        {
            return EditorPrefs.GetBool("VRCAssetPreProcessor_LinearizeMaps", false);
        }
        set
        {
            EditorPrefs.SetBool("VRCAssetPreProcessor_LinearizeMaps", value);
        }
    }

    public static string LinearizationTargetSuffixes
    {
        get
        {
            return EditorPrefs.GetString("VRCAssetPreProcessor_LinearizationTargetSuffixes", "_rma,_ppc,_mro,_nma,_ao,_sss,_trans,_si,_emis");
        }
        set
        {
            EditorPrefs.SetString("VRCAssetPreProcessor_LinearizationTargetSuffixes", value);
        }
    }

    public static bool SingleColorizeMaps
    {
        get
        {
            return EditorPrefs.GetBool("VRCAssetPreProcessor_SingleColorizeMaps", false);
        }
        set
        {
            EditorPrefs.SetBool("VRCAssetPreProcessor_SingleColorizeMaps", value);
        }
    }

    public static VRCAssetPostProcessorEnums.SingleColorChannel SingleColorChannel
    {
        get
        {
            string singleColorChannel = EditorPrefs.GetString("VRCAssetPreProcessor_SingleColorChannel", "red");
            switch (singleColorChannel) {
                case "red":
                    return VRCAssetPostProcessorEnums.SingleColorChannel.Red;
                case "alpha":
                    return VRCAssetPostProcessorEnums.SingleColorChannel.Alpha;
                default:
                    return VRCAssetPostProcessorEnums.SingleColorChannel.Red;
            }
        }
        set
        {
            switch (value) {
                case VRCAssetPostProcessorEnums.SingleColorChannel.Red:
                    EditorPrefs.SetString("VRCAssetPreProcessor_SingleColorChannel", "red");
                break;
                case VRCAssetPostProcessorEnums.SingleColorChannel.Alpha:
                    EditorPrefs.SetString("VRCAssetPreProcessor_SingleColorChannel", "alpha");
                break;
                default:
                    throw new ArgumentException("Value must be one of: alpha or red");
            }
        }
    }

    public static string SingleColorTargetSuffixes
    {
        get
        {
            return EditorPrefs.GetString("VRCAssetPreProcessor_SingleColorTargetSuffixes", "_ao,_trans,_op,_metal,_rough");
        }
        set
        {
            EditorPrefs.SetString("VRCAssetPreProcessor_SingleColorTargetSuffixes", value);
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
}
