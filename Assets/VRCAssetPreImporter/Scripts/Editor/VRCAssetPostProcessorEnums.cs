using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class VRCAssetPostProcessorEnums
{
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

    public enum SingleColorChannel
    {
        Red = TextureImporterSingleChannelComponent.Red,
        Alpha = TextureImporterSingleChannelComponent.Alpha
    }
}