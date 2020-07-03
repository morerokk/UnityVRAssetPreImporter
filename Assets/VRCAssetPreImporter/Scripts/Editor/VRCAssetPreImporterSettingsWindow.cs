using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class VRCAssetPreImporterSettingsWindow : EditorWindow
{
    private static readonly int[] MaxTextureSizes =
    {
        32,
        64,
        128,
        256,
        512,
        1024,
        2048,
        4096,
        8192
    };

    private static readonly string[] MaxTextureSizeNames =
    {
        "32",
        "64",
        "128",
        "256",
        "512",
        "1024",
        "2048",
        "4096",
        "8192"
    };

    [MenuItem("Tools/Asset Preprocessor Settings")]
    static void Init()
    {
        VRCAssetPreImporterSettingsWindow window = (VRCAssetPreImporterSettingsWindow)EditorWindow.GetWindow(typeof(VRCAssetPreImporterSettingsWindow), true, "Asset Preprocessor Settings");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Model import settings", EditorStyles.boldLabel);

        VRCAssetPreImporterSettings.BlendShapeNormals = (VRCAssetPostProcessorEnums.BlendShapeNormalsMode) EditorGUILayout.EnumPopup("BlendShape Normals", VRCAssetPreImporterSettings.BlendShapeNormals);


        EditorGUILayout.Space();


        GUILayout.Label("Texture import settings", EditorStyles.boldLabel);

        VRCAssetPreImporterSettings.StreamingMipmaps = EditorGUILayout.Toggle("Streaming MIP-maps", VRCAssetPreImporterSettings.StreamingMipmaps);

        VRCAssetPreImporterSettings.AlphaIsTransparency = EditorGUILayout.Toggle("Alpha is Transparency", VRCAssetPreImporterSettings.AlphaIsTransparency);

        VRCAssetPreImporterSettings.MaxTextureSize = EditorGUILayout.IntPopup("Texture Size", VRCAssetPreImporterSettings.MaxTextureSize, MaxTextureSizeNames, MaxTextureSizes);

        VRCAssetPreImporterSettings.TextureCompressionLevel = (VRCAssetPostProcessorEnums.TextureCompressionQuality) EditorGUILayout.EnumPopup("Texture Compression", VRCAssetPreImporterSettings.TextureCompressionLevel);

        VRCAssetPreImporterSettings.UseCrunch = EditorGUILayout.Toggle("Crunch", VRCAssetPreImporterSettings.UseCrunch);

        VRCAssetPreImporterSettings.LinearizeMaps = EditorGUILayout.Toggle("Linearize maps", VRCAssetPreImporterSettings.LinearizeMaps);
        
        if (VRCAssetPreImporterSettings.LinearizeMaps) {
            EditorGUILayout.LabelField("Name suffixes (csv, no space)");
            VRCAssetPreImporterSettings.LinearizationTargetSuffixes = EditorGUILayout.TextField(VRCAssetPreImporterSettings.LinearizationTargetSuffixes, GUILayout.ExpandHeight(true));
        }

        VRCAssetPreImporterSettings.SingleColorizeMaps = EditorGUILayout.Toggle("Single Color Maps", VRCAssetPreImporterSettings.SingleColorizeMaps);

        if (VRCAssetPreImporterSettings.SingleColorizeMaps) {
            VRCAssetPreImporterSettings.SingleColorChannel = (VRCAssetPostProcessorEnums.SingleColorChannel) EditorGUILayout.EnumPopup("Target Channel", VRCAssetPreImporterSettings.SingleColorChannel);

            EditorGUILayout.LabelField("Name suffixes (csv, no space)");
            VRCAssetPreImporterSettings.SingleColorTargetSuffixes = EditorGUILayout.TextField(VRCAssetPreImporterSettings.SingleColorTargetSuffixes, GUILayout.ExpandHeight(true));
        }

        EditorGUILayout.Space();

        GUILayout.Label("Misc settings", EditorStyles.boldLabel);
        
        // Logging setting
        VRCAssetPreImporterSettings.LoggingEnabled = EditorGUILayout.Toggle("Log Actions", VRCAssetPreImporterSettings.LoggingEnabled);
    }
}
