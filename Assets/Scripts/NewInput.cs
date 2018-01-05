using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class NewInput : MonoBehaviour
{
    public GameObject newInputText;
    public Text[] assignedText;
    bool gettingInput;
    int keyIndex;

    char[] removeChar = {'A','l','p','h','a' };

    private void Start()
    {
        // Sets the text to display the key code
        for(int i = 0; i < assignedText.Length; ++i)
        {
            if (GameInputManager.defaults[i] == KeyCode.Mouse0)
                assignedText[i].text = "Left Mouse";
            else if (GameInputManager.defaults[i] == KeyCode.Mouse1)
                assignedText[i].text = "Right Mouse";
            else if (GameInputManager.defaults[i] == KeyCode.Alpha0 || GameInputManager.defaults[i] == KeyCode.Alpha1 || GameInputManager.defaults[i] == KeyCode.Alpha2 || GameInputManager.defaults[i] == KeyCode.Alpha3 || GameInputManager.defaults[i] == KeyCode.Alpha4 || GameInputManager.defaults[i] == KeyCode.Alpha5 || GameInputManager.defaults[i] == KeyCode.Alpha6 || GameInputManager.defaults[i] == KeyCode.Alpha7 || GameInputManager.defaults[i] == KeyCode.Alpha8 || GameInputManager.defaults[i] == KeyCode.Alpha9)
            {
                TrimString(GameInputManager.defaults[i].ToString(), i);
            }
            else if (GameInputManager.defaults[i] != KeyCode.None)
                assignedText[i].text = GameInputManager.defaults[i].ToString();
            else
                assignedText[i].text = KeyCode.None.ToString();
        }
    }

    private void Update()
    {
        // While gettingInput is true
        if(gettingInput)
        {
            // Gets each possible key code
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                // Only proceeds if a key is pressed
                if (Input.GetKeyDown(kcode))
                {
                    for(int i = 0; i < GameInputManager.defaults.Length; ++i)
                    {
                        // Sets the new key
                        GameInputManager.defaults[keyIndex] = kcode;
                        // Sets the text to display the new key
                        for (int j = 0; j < assignedText.Length; ++j)
                        {
                            if (GameInputManager.defaults[j] == KeyCode.Mouse0)
                                assignedText[j].text = "Left Mouse";
                            else if (GameInputManager.defaults[j] == KeyCode.Mouse1)
                                assignedText[j].text = "Right Mouse";
                            else if (GameInputManager.defaults[j] == KeyCode.Alpha0 || GameInputManager.defaults[j] == KeyCode.Alpha1 || GameInputManager.defaults[j] == KeyCode.Alpha2 || GameInputManager.defaults[j] == KeyCode.Alpha3 || GameInputManager.defaults[j] == KeyCode.Alpha4 || GameInputManager.defaults[j] == KeyCode.Alpha5 || GameInputManager.defaults[j] == KeyCode.Alpha6 || GameInputManager.defaults[j] == KeyCode.Alpha7 || GameInputManager.defaults[j] == KeyCode.Alpha8 || GameInputManager.defaults[j] == KeyCode.Alpha9)
                            {
                                TrimString(GameInputManager.defaults[j].ToString(), j);
                            }
                            else if (GameInputManager.defaults[j] != KeyCode.None)
                                assignedText[j].text = GameInputManager.defaults[j].ToString();
                        }
                            // If the new key is the same as another key, reassigns the old one to none
                            if (kcode == GameInputManager.defaults[i])
                        {
                            GameInputManager.defaults[i] = KeyCode.None;                        
                            assignedText[i].text = KeyCode.None.ToString();
                        }
                    }
                    // Resets the definitions
                    GameInputManager.InitializeDictionary();
                    // deactivates the display text
                    newInputText.SetActive(false);
                    // Ends the loop
                    gettingInput = false;
                }             
            }
        }
    }

    void TrimString(string str, int index)
    {
        String temp = str;
        temp = temp.TrimStart(removeChar);
        assignedText[index].text = temp;
    }
    // Sets the keyIndex to the proper index, activates the display text, sets gettingInput to true
    public void NewWeapon1()
    {
        keyIndex = 0;
        newInputText.SetActive(true);
        gettingInput = true;
    }

    public void NewWeapon2()
    {
        keyIndex = 1;
        newInputText.SetActive(true);
        gettingInput = true;
    }

    public void NewSpell1()
    {
        keyIndex = 2;
        newInputText.SetActive(true);
        gettingInput = true;
    }

    public void NewSpell2()
    {
        keyIndex = 3;
        newInputText.SetActive(true);
        gettingInput = true;
    }

    public void NewSpell3()
    {
        keyIndex = 4;
        newInputText.SetActive(true);
        gettingInput = true;
    }

    public void NewSpell4()
    {
        keyIndex = 5;
        newInputText.SetActive(true);
        gettingInput = true;
    }

    public void NewItem1()
    {
        keyIndex = 6;
        newInputText.SetActive(true);
        gettingInput = true;
    }

    public void NewItem2()
    {
        keyIndex = 7;
        newInputText.SetActive(true);
        gettingInput = true;
    }
}
