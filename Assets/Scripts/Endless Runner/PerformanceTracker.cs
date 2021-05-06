using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PerformanceTracker
{
    private static int id;

    public static void CreateDirectory()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/PerformanceTracking/");
    }

    public static void WritePerformance(int score, string gamemode)
    {
        string txtDocumentName = Application.streamingAssetsPath + "/PerformanceTracking/" + "Performance" + ".txt";

        if (!File.Exists(txtDocumentName))
        {
            File.WriteAllText(txtDocumentName, "Performance Tracking \n\n");
        }

        File.AppendAllText(txtDocumentName, gamemode + " Performance " + id + ": " + score + " (" + System.DateTime.Now + ")\n");
        id++;
    }
}
