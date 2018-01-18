using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public string abilityButtonAxisName = "Weapon1";
    public Image darkMask;
    public Text cdTextDisplay;

    public Ability ability;
    public GameObject abilityHolder;

    private Image myButtonImage;
    private AudioSource abilitySource;
    private float cdDuration;
    private float nextReadyTime;
    private float cdRemaining;

    private float castDuration;
    private float castRemaining;

    GameObject player;

    // Temporary animator placement
    Animator anim;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>(); // To be removed later
        Initialize(ability, abilityHolder);
	}

    public void Initialize(Ability selectedAbility, GameObject abilityHolder)
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();
        myButtonImage.sprite = ability.aSprite;
        darkMask.sprite = ability.aSprite;
        cdDuration = ability.aBaseCooldown;
        castDuration = ability.aBaseCastTime;
        ability.Initialize(abilityHolder);
        AbilityReady();
    }

    void Update ()
    {
        bool cdComplete = (Time.time > nextReadyTime);
        if (cdComplete && Time.timeScale > 0)
        {
            AbilityReady();
            if (GameInputManager.GetKeyDown(abilityButtonAxisName))
            {
                CastAbility();
                if (castDuration > 0)
                    player.GetComponent<PlayerController>().isCasting = true;
                Invoke("ButtonTriggered", castDuration);
            }
        }
        else CDUpdate();
    }

    private void AbilityReady()
    {
        cdTextDisplay.enabled = false;
        darkMask.enabled = false;
    }

    private void CDUpdate()
    {
        anim.SetBool("shortCast", false); // To be removed later
        cdRemaining -= Time.deltaTime;
        float roundedCD = Mathf.Round(cdRemaining);
        cdTextDisplay.text = roundedCD.ToString();
        darkMask.fillAmount = (cdRemaining / cdDuration);
    }

    private void CastAbility()
    {       
        castRemaining -= Time.deltaTime;
        float roundedCast = Mathf.Round(castRemaining);
        // text update
        // mask update
    }

    private void ButtonTriggered()
    {
        anim.SetBool("shortCast", true); // To be removed later
        castRemaining = castDuration;
        nextReadyTime = cdDuration + Time.time;
        cdRemaining = cdDuration;
        darkMask.enabled = true;
        cdTextDisplay.enabled = true;
        abilitySource.clip = ability.aSound;
        abilitySource.Play();
        ability.TriggerAbility();
        player.GetComponent<PlayerController>().isCasting = false;
    }
}
