
using UnityEngine;
using System.Collections.Generic;

public class RandomName
{
    public static List<string> nameList = new List<string>() { "Alice", "Bob", "Charlie", "David", "Eve", "Frank" };


    public static string GetRandomName()
    {
        int index = Random.Range(0, nameList.Count);
        return nameList[index];
    }
}

public class Utils
{
    public static Color GetColor(string nameColor)
    {
        switch (nameColor)
        {
            case "Red": return Color.red;
            case "White": return Color.white;
            case "Orange": return new Color(1f, 0.65f, 0f);
            case "Organe": return new Color(1f, 0.65f, 0f);
            case "Green": return Color.green;
            case "Yellow": return Color.yellow;
            case "Purple": return Color.magenta;
            case "Blue": return Color.blue;
        }
        return Color.white;
    }

}



