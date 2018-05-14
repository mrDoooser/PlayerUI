using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;


[System.Serializable]
public class MatchInfo 
{
    public string LeagueName;
    public string TourName;
    public string StadiumName;
    public int Viewers;

    public static MatchInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<MatchInfo>(jsonString);
    }

}
