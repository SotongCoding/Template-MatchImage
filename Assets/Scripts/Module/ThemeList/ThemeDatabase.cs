using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ThemeDatabase : ScriptableObject
{
    [SerializeField] private List<ThemeData> themeData;
    public ThemeData[] GetAllThemes()
    {
        return themeData.ToArray();
    }

    [System.Serializable]
    public struct ThemeData
    {
        public string themeName;
        public string filename;
        public int themeId;
        public int price;
    }
}
