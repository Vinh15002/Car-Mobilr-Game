
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

