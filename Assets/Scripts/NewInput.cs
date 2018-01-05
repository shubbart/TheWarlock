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
        for(int i = 0; i < assignedText.Length; ++i)
        {
            if (GameInputManager.defaults[i] == KeyCode.Mouse0)
                assignedText[i].text = "Left Mouse";
            if (GameInputManager.defaults[i] == KeyCode.Mouse1)
                assignedText[i].text = "Right Mouse";
            //assignedText[i].text = GameInputManager.defaults[i].ToString();
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
                            assignedText[keyIndex].text = kcode.ToString();
                            // If the new key is the same as another key, reassigns the old one to none
                            if (kcode == GameInputManager.defaults[i])
                            {
                                    GameInputManager.defaults[i] = KeyCode.None;
                                if (GameInputManager.defaults[i] == KeyCode.Mouse0)
                                    assignedText[i].text = "Left Mouse";
                                else if (GameInputManager.defaults[i] == KeyCode.Mouse1)
                                    assignedText[i].text = "Right Mouse";
                                else if (GameInputManager.defaults[i] == KeyCode.Alpha0 || GameInputManager.defaults[i] == KeyCode.Alpha1 || GameInputManager.defaults[i] == KeyCode.Alpha2 || GameInputManager.defaults[i] == KeyCode.Alpha3 || GameInputManager.defaults[i] == KeyCode.Alpha4 || GameInputManager.defaults[i] == KeyCode.Alpha5 || GameInputManager.defaults[i] == KeyCode.Alpha6 || GameInputManager.defaults[i] == KeyCode.Alpha7 || GameInputManager.defaults[i] == KeyCode.Alpha8 || GameInputManager.defaults[i] == KeyCode.Alpha9)
                                {
                                    String temp = GameInputManager.defaults[i].ToString();
                                    assignedText[i].text = temp.TrimStart(removeChar);
                                }
                                else
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
