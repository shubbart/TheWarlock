using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject spellBook;
    [SerializeField] GameObject hotkeys;
    public Texture2D defaultCursor;
    bool menuOpen;
    bool otherMenusOpen;

    private void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        if (GameInputManager.GetKeyUp("Pause") && !otherMenusOpen)
            menuOpen = !menuOpen;

        if (menuOpen)
            PauseGame();
        else if (!menuOpen)
            ResumeGame();
    }

    // Pause game and open menu
    private void PauseGame()
    {
        Time.timeScale = 0;
        if(!otherMenusOpen)
            menu.SetActive(true);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        menuOpen = true;
    }

    // Closes menu and resume game
    void ResumeGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        menuOpen = false;
    }

    public void ResumeButton()
    {
        menuOpen = !menuOpen;
    }

    public void EnablePauseMenu()
    {
        if (menu.activeInHierarchy)
            menu.SetActive(false);
        else
            menu.SetActive(true);
    }

    public void OpenHotkeysMenu()
    {
        otherMenusOpen = true;
        hotkeys.SetActive(true);
        menu.SetActive(false);
    }

    public void CloseHotkeysMenu()
    {
        otherMenusOpen = false;
        hotkeys.SetActive(false);
        menu.SetActive(true);
    }

    public void OpenSpellbookMenu()
    {
        otherMenusOpen = true;
        spellBook.SetActive(true);
        menu.SetActive(false);
    }

    public void CloseSpellbookMenu()
    {
        otherMenusOpen = false;
        spellBook.SetActive(false);
        menu.SetActive(true);
    }

}
