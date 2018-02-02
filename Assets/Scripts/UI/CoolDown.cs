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
    private bool selfCast;

    GameObject player;
    PlayerController pController;

    Animator anim;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pController = player.GetComponent<PlayerController>();
        anim = player.GetComponent<Animator>();
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
        selfCast = ability.selfCast;
        ability.Initialize(abilityHolder);
        AbilityReady();
    }

    void Update ()
    {
        bool cdComplete = (Time.time > nextReadyTime);
        if (cdComplete && Time.timeScale > 0)// && !pController.isCasting)
        {
            AbilityReady();
            if (GameInputManager.GetKeyDown(abilityButtonAxisName))
            {
                CastAbility(); // Visual indication of cast time
                if (castDuration > 0)
                {
                    pController.longCasting = true;
                    pController.isCasting = true;
                    pController.activeSlot = gameObject;
                    anim.SetBool("longCast", true);
                    anim.SetBool("selfCast", selfCast);
                }
                else
                {
                    pController.isCasting = true;
                    anim.SetBool("shortCast", true);
                    anim.SetBool("selfCast", selfCast);
                    pController.activeSlot = gameObject;
                }
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

    public void ButtonTriggered()
    {
        castRemaining = castDuration;
        nextReadyTime = cdDuration + Time.time;
        cdRemaining = cdDuration;
        darkMask.enabled = true;
        cdTextDisplay.enabled = true;
        abilitySource.clip = ability.aSound;
        abilitySource.Play();
        ability.TriggerAbility();
        pController.isCasting = false;
        pController.longCasting = false;
        anim.SetBool("shortCast", false);
        anim.SetBool("longCast", false);
        anim.SetBool("selfCast", false);
    }
}
