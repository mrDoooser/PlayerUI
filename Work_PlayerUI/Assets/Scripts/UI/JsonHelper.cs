using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonHelper
{ 

    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }

    public static string[] SeparateJson(string jsonString, string spliterString = "\n")
    {
        string[] resultString;

        spliterString = "/n";

        if (!jsonString.Contains(spliterString))
        {
            Debug.Log("ERROR! Incorrect splitter.");
            return new string[] { };
        }

        char[] spliter = spliterString.ToCharArray();
        resultString = jsonString.Split(spliter);

        return resultString;
    }

    public static ArrayList DevideString(string jsonString, char startSymbol = '{', char stopSymbol = '}')
    {
        ArrayList resultString = new ArrayList() ;

        int startPos = 0;
        int stopPos = 0;
        bool inExtraction = false;

        //jsonString.Substring(i, length);

        for (int i = 0; i < jsonString.Length; i++)
        {
            if (jsonString[i] == startSymbol && !inExtraction)
            {
                startPos = i;
                inExtraction = true;
            }
            if (jsonString[i] == stopSymbol && inExtraction)
            {
                stopPos = i;
                inExtraction = false;

                string newline = jsonString.Substring(startPos, stopPos-startPos+1);
                //Debug.Log(newline);
                resultString.Add(newline);
            }


        }



        return resultString;
    }

}
