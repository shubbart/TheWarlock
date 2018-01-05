using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotkeys : MonoBehaviour
{
    public GameObject menu;
    public Texture2D defaultCursor;

    private void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        Weapon1();
        Weapon2();
        Spell1();
        Spell2();
        Spell3();
        Spell4();
        Item1();
        Item2();
        PauseGame();
    }


    void Weapon1()
    {
        if(GameInputManager.GetKeyUp("Weapon1"))
        {
            Debug.Log("Weapon1");
            // Do weapon attack 1
        }      
    }

    void Weapon2()
    {
        if (GameInputManager.GetKeyUp("Weapon2"))
        {
            Debug.Log("Weapon2");
            // Do weapon attack 2
        }
    }

    void Spell1()
    {
        if (GameInputManager.GetKeyUp("Spell1"))
        {
            Debug.Log("Spell1");
            // Do spell attack 1
        }
    }

    void Spell2()
    {
        if (GameInputManager.GetKeyUp("Spell2"))
        {
            Debug.Log("Spell2");
            // Do spell attack 2
        }
    }

    void Spell3()
    {
        if (GameInputManager.GetKeyUp("Spell3"))
        {
            Debug.Log("Spell3");
            // Do spell attack 3
        }
    }

    void Spell4()
    {
        if (GameInputManager.GetKeyUp("Spell4"))
        {
            Debug.Log("Spell4");
            // Do spell attack 4
        }
    }

    void Item1()
    {
        if (GameInputManager.GetKeyUp("Item1"))
        {
            Debug.Log("Item1");
            // Do item effect 1
        }
    }

    void Item2()
    {
        if (GameInputManager.GetKeyUp("Item2"))
        {
            Debug.Log("Item2");
            // Do item effect 2
        }
    }

    private void PauseGame()
    {
        if(GameInputManager.GetKeyUp("Pause"))
        {
            // Pause game and open menu
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
                menu.gameObject.SetActive(true);
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
            // Closes menu and resume game
            else
            {
                Time.timeScale = 1;
                menu.gameObject.SetActive(false);
                Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
            }
        }
    }

}
