using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildAssetBundle :Editor{

    /// <summary>
    /// 打包WindowsAB包
    /// </summary>
	[MenuItem("BuildAssetBundleTool/BuildWindowsAssetBundle")]
    public static void BuildWindowsAssetBundle()
    {
        string ABOutPathDir = Application.streamingAssetsPath+"/Windows";
        if (!Directory.Exists(ABOutPathDir))
        {
            Directory.CreateDirectory(ABOutPathDir);
        }
        BuildPipeline.BuildAssetBundles(ABOutPathDir,BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows64);
    }
    /// <summary>
    /// 打包AndroidAb包
    /// </summary>
    [MenuItem("BuildAssetBundleTool/BuildAndoridAssetBundle")]
    public static void BuildAndoridAssetBundle()
    {
        string ABOutPathDir = Application.streamingAssetsPath+"/Android";
        if (!Directory.Exists(ABOutPathDir))
        {
            Directory.CreateDirectory(ABOutPathDir);
        }
        BuildPipeline.BuildAssetBundles(ABOutPathDir, BuildAssetBundleOptions.None, BuildTarget.Android);
    }

}
