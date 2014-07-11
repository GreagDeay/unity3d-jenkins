using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.Collections.Generic;

public class BuildScript
{
    private static string[] SCENES = FindEnabledEditorScenes();

    private static string APP_NAME = "testApp";
    private static string TARGET_DIR = "testBuild";

    [MenuItem("Custom/CI/Build Windows")]
    private static void PerformWindowsBuild()
    {
        string target_dir = APP_NAME + ".app";
        GenericBuild(SCENES, TARGET_DIR + "/" + target_dir, BuildTarget.StandaloneWindows64, BuildOptions.None);
    }

    [MenuItem("Custom/CI/Build Mac OS X")]
    private static void PerformMacOSXBuild()
    {
        string target_dir = APP_NAME + ".app";
        GenericBuild(SCENES, TARGET_DIR + "/" + target_dir, BuildTarget.StandaloneOSXIntel, BuildOptions.None);
    }

    [MenuItem("Custom/CI/Build Web")]
    private static void PerformWebBuild()
    {
        string target_dir = APP_NAME + ".unity3d";
        GenericBuild(SCENES, TARGET_DIR + "/web/" + target_dir, BuildTarget.WebPlayer, BuildOptions.None);
    }

    private static string[] FindEnabledEditorScenes()
    {
        List <string> EditorScenes = new List <string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (!scene.enabled) continue;
            EditorScenes.Add(scene.path);
        }
        return EditorScenes.ToArray();
    }

    private static void GenericBuild(string[] scenes, string target_dir, BuildTarget build_target,
        BuildOptions build_options)
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
        string res = BuildPipeline.BuildPlayer(scenes, target_dir, build_target, build_options);
        if (res.Length < 0)
        {
            throw new Exception("BuildPlayer failure: " + res);
        }
    }
}