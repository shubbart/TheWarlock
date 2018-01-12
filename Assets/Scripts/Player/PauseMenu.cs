using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject spellbook;
    [SerializeField] GameObject earthbook;
    [SerializeField] GameObject firebook;
    [SerializeField] GameObject frostbook;
    [SerializeField] GameObject healingbook;
    [SerializeField] GameObject lightningbook;
    [SerializeField] GameObject necromancybook;
    [SerializeField] GameObject shadowbook;
    [SerializeField] GameObject summoningbook;
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
        spellbook.SetActive(true);
        menu.SetActive(false);
    }

    public void CloseSpellbookMenu()
    {
        otherMenusOpen = false;
        spellbook.SetActive(false);
        menu.SetActive(true);
    }

    public void OpenEarthbook()
    {
        earthbook.SetActive(true);
        spellbook.SetActive(false);
    }

    public void CloseEarthbook()
    {
        earthbook.SetActive(false);
        spellbook.SetActive(true);
    }

    public void OpenFirebook()
    {
        firebook.SetActive(true);
        spellbook.SetActive(false);
    }

    public void CloseFirebook()
    {
        firebook.SetActive(false);
        spellbook.SetActive(true);
    }

    public void OpenFrostbook()
    {
        frostbook.SetActive(true);
        spellbook.SetActive(false);
    }

    public void CloseFrostbook()
    {
        frostbook.SetActive(false);
        spellbook.SetActive(true);
    }

    public void OpenHealingbook()
    {
        healingbook.SetActive(true);
        spellbook.SetActive(false);
    }

    public void CloseHealingbook()
    {
        healingbook.SetActive(false);
        spellbook.SetActive(true);
    }

    public void OpenLightningbook()
    {
        lightningbook.SetActive(true);
        spellbook.SetActive(false);
    }

    public void CloseLightningbook()
    {
        lightningbook.SetActive(false);
        spellbook.SetActive(true);
    }

    public void OpenNecromancybook()
    {
        necromancybook.SetActive(true);
        spellbook.SetActive(false);
    }

    public void CloseNecromancybook()
    {
        necromancybook.SetActive(false);
        spellbook.SetActive(true);
    }

    public void OpenShadowbook()
    {
        shadowbook.SetActive(true);
        spellbook.SetActive(false);
    }

    public void CloseShadowbook()
    {
        shadowbook.SetActive(false);
        spellbook.SetActive(true);
    }

    public void OpenSummoningbook()
    {
        summoningbook.SetActive(true);
        spellbook.SetActive(false);
    }

    public void CloseSummoningbook()
    {
        summoningbook.SetActive(false);
        spellbook.SetActive(true);
    }

}
