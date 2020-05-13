using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Level {
    [Range(1, 11)]
    public int partCount = 11;
    [Range(0, 11)]
    public int deathpartCount = 0;
}
[CreateAssetMenu(fileName ="New Stage")]
public class stage : ScriptableObject
{
    public Color stagebackgroundcolor = Color.white;
    public Color stagelevelpartcolor = Color.white;
    public Color stageballcolor = Color.white;
    public List<Level> levels = new List<Level>();

}
