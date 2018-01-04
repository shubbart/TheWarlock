using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameInputManager : MonoBehaviour
{

    static Dictionary<string, KeyCode> keyMapping;
    static string[] keyMaps = new string[9]
    {
        "Weapon1",
        "Weapon2",
        "Spell1",
        "Spell2",
        "Spell3",
        "Spell4",
        "Item1",
        "Item2",
        "Pause"
    };
    public static KeyCode[] defaults = new KeyCode[9]
    {
        KeyCode.Mouse0,
        KeyCode.Mouse1,
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Q,
        KeyCode.E,
        KeyCode.Escape
    };

    static GameInputManager()
    {
        InitializeDictionary();
    }

    public static void InitializeDictionary()
    {
        keyMapping = new Dictionary<string, KeyCode>();
        for (int i = 0; i < keyMaps.Length; ++i)
        {
            keyMapping.Add(keyMaps[i], defaults[i]);
        }
    }

    public static void SetKeyMap(string keyMap, KeyCode key)
    {
        if (!keyMapping.ContainsKey(keyMap))
            throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
        keyMapping[keyMap] = key;
    }

    public static bool GetKeyDown(string keyMap)
    {
        return Input.GetKeyDown(keyMapping[keyMap]);
    }

    public static bool GetKeyUp(string keyMap)
    {
        return Input.GetKeyUp(keyMapping[keyMap]);
    }
}
