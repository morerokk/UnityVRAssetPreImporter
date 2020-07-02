using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.IO;

public class VRCAssetPostProcessor : AssetPostprocessor
{
    void OnPreprocessModel()
    {
        // Check if this is the first import. If not, skip.
        if(!assetImporter.importSettingsMissing)
        {
            return;
        }

        if (VRCAssetPreImporterSettings.BlendShapeNormals == VRCAssetPreImporterSettings.BlendShapeNormalsMode.Default)
        {
            // Default settings selected, don't do anything
            return;
        }

        LogAction("[VRCAssetPreprocessor] First import of a model, changing import settings.");

        ModelImporter modelImporter = assetImporter as ModelImporter;

        if (VRCAssetPreImporterSettings.BlendShapeNormals == VRCAssetPreImporterSettings.BlendShapeNormalsMode.Import)
        {
            // Enable import blendshape normals automatically
            modelImporter.importBlendShapeNormals = ModelImporterNormals.Import;
        }
        else if (VRCAssetPreImporterSettings.BlendShapeNormals == VRCAssetPreImporterSettings.BlendShapeNormalsMode.None)
        {
            // Disable blendshape normals automatically
            modelImporter.importBlendShapeNormals = ModelImporterNormals.None;
        }
        else
        {
            // Set "legacy blend shapes" enabled automatically
            PropertyInfo legacyBlendShapeNormalsEnabled = modelImporter.GetType().GetProperty("legacyComputeAllNormalsFromSmoothingGroupsWhenMeshHasBlendShapes", BindingFlags.NonPublic | BindingFlags.Instance);
            legacyBlendShapeNormalsEnabled.SetValue(modelImporter, true);
        }
    }

    void OnPreprocessTexture()
    {
        // Check if this is the first import. If not, skip.
        if(!assetImporter.importSettingsMissing)
        {
            return;
        }

        LogAction("[VRCAssetPreprocessor] First import of a texture, changing import settings.");

        TextureImporter textureImporter = assetImporter as TextureImporter;

        // Enable streaming mipmaps automatically if chosen
        textureImporter.streamingMipmaps = VRCAssetPreImporterSettings.StreamingMipmaps;

        // Set max size
        textureImporter.maxTextureSize = VRCAssetPreImporterSettings.MaxTextureSize;

        // Set alpha is transparency setting
        textureImporter.alphaIsTransparency = VRCAssetPreImporterSettings.AlphaIsTransparency;

        // Set compression quality
        textureImporter.textureCompression = (TextureImporterCompression)VRCAssetPreImporterSettings.TextureCompressionLevel;
    }

    private void LogAction(string msg)
    {
        if(VRCAssetPreImporterSettings.LoggingEnabled)
        {
            Debug.Log(msg, assetImporter);
        }
    }
}
