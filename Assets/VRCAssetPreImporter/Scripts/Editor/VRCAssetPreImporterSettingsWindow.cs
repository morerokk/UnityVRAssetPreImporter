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

    [MenuItem("Tools/VRChat Asset Preprocessor Settings")]
    static void Init()
    {
        VRCAssetPreImporterSettingsWindow window = (VRCAssetPreImporterSettingsWindow)EditorWindow.GetWindow(typeof(VRCAssetPreImporterSettingsWindow));
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("VRC Asset Preprocessor Settings", EditorStyles.boldLabel);

        GUILayout.Label("Model import settings", EditorStyles.boldLabel);

        // Blend shape normals mode setting
        EditorGUILayout.LabelField("Default Blend Shape Normals Mode");
        VRCAssetPreImporterSettings.BlendShapeNormals = (VRCAssetPreImporterSettings.BlendShapeNormalsMode)EditorGUILayout.EnumPopup(VRCAssetPreImporterSettings.BlendShapeNormals);

        GUILayout.Label("Texture import settings", EditorStyles.boldLabel);

        // Streaming mipmaps setting
        EditorGUILayout.LabelField("Default Streaming Mipmaps enabled");
        VRCAssetPreImporterSettings.StreamingMipmaps = EditorGUILayout.Toggle(VRCAssetPreImporterSettings.StreamingMipmaps);

        // Alpha is transparency setting
        EditorGUILayout.LabelField("Default Alpha is Transparency");
        VRCAssetPreImporterSettings.AlphaIsTransparency = EditorGUILayout.Toggle(VRCAssetPreImporterSettings.AlphaIsTransparency);

        // Max texture size setting
        EditorGUILayout.LabelField("Default maximum texture size");
        VRCAssetPreImporterSettings.MaxTextureSize = EditorGUILayout.IntPopup(VRCAssetPreImporterSettings.MaxTextureSize, MaxTextureSizeNames, MaxTextureSizes);

        // Texture compression setting
        EditorGUILayout.LabelField("Default texture compression quality");
        VRCAssetPreImporterSettings.TextureCompressionLevel = (VRCAssetPreImporterSettings.TextureCompressionQuality)EditorGUILayout.EnumPopup(VRCAssetPreImporterSettings.TextureCompressionLevel);

        GUILayout.Label("Misc settings", EditorStyles.boldLabel);

        // Logging setting
        EditorGUILayout.LabelField("Log all corrective import actions");
        VRCAssetPreImporterSettings.LoggingEnabled = EditorGUILayout.Toggle(VRCAssetPreImporterSettings.LoggingEnabled);
    }
}
