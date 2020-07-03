using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.IO;
using System.Linq;

public class VRCAssetPostProcessor : AssetPostprocessor
{
    void OnPreprocessModel()
    {
        // Check if this is the first import. If not, skip.
        if(!assetImporter.importSettingsMissing)
        {
            return;
        }

        if (VRCAssetPreImporterSettings.BlendShapeNormals == VRCAssetPostProcessorEnums.BlendShapeNormalsMode.Default)
        {
            // Default settings selected, don't do anything
            return;
        }

        LogAction("First import of a model, changing import settings.");

        ModelImporter modelImporter = assetImporter as ModelImporter;

        if (VRCAssetPreImporterSettings.BlendShapeNormals == VRCAssetPostProcessorEnums.BlendShapeNormalsMode.Import)
        {
            // Enable import blendshape normals automatically
            modelImporter.importBlendShapeNormals = ModelImporterNormals.Import;
        }
        else if (VRCAssetPreImporterSettings.BlendShapeNormals == VRCAssetPostProcessorEnums.BlendShapeNormalsMode.None)
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

        LogAction("First import of a texture, changing import settings.");

        TextureImporter textureImporter = assetImporter as TextureImporter;

        // Enable streaming mipmaps automatically if chosen
        textureImporter.streamingMipmaps = VRCAssetPreImporterSettings.StreamingMipmaps;

        // Set max size
        textureImporter.maxTextureSize = VRCAssetPreImporterSettings.MaxTextureSize;

        // Set alpha is transparency setting
        textureImporter.alphaIsTransparency = VRCAssetPreImporterSettings.AlphaIsTransparency;

        // Set compression quality
        textureImporter.textureCompression = (TextureImporterCompression) VRCAssetPreImporterSettings.TextureCompressionLevel;

        textureImporter.crunchedCompression = VRCAssetPreImporterSettings.UseCrunch;

        if (VRCAssetPreImporterSettings.LinearizeMaps) {
            string[] tokens = VRCAssetPreImporterSettings.LinearizationTargetSuffixes.Split(',');
            if (tokens.Any(x => Path.GetFileNameWithoutExtension(textureImporter.assetPath).EndsWith(x))) {
                LogAction("Texture " + Path.GetFileName(textureImporter.assetPath) + " matches linearization filters, applying...");
                textureImporter.sRGBTexture = false;
            }
        }


        if (VRCAssetPreImporterSettings.SingleColorizeMaps) {
            string[] tokens = VRCAssetPreImporterSettings.LinearizationTargetSuffixes.Split(',');
            if (tokens.Any(x => Path.GetFileNameWithoutExtension(textureImporter.assetPath).EndsWith(x))) {
                LogAction("Texture " + Path.GetFileName(textureImporter.assetPath) + " matches color filters, applying...");

                textureImporter.textureType = TextureImporterType.SingleChannel;

                TextureImporterSettings tis = new TextureImporterSettings();
                textureImporter.ReadTextureSettings(tis); //because of course unity can't *return* a value like you'd expect it to
                tis.singleChannelComponent = (TextureImporterSingleChannelComponent) VRCAssetPreImporterSettings.SingleColorChannel;
                textureImporter.SetTextureSettings(tis);
            }
        }
    }

    private void LogAction(string msg)
    {
        if(VRCAssetPreImporterSettings.LoggingEnabled)
        {
            Debug.Log("[VRCAssetPreprocessor] " + msg, assetImporter);
        }
    }
}
