using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public string abilityButtonAxisName = "Weapon1";
    public Image darkMask;
    public Text cdTextDisplay;

    [SerializeField] private Ability ability;
    [SerializeField] private GameObject abilityHolder;

    private Image myButtonImage;
    private AudioSource abilitySource;
    private float cdDuration;
    private float nextReadyTime;
    private float cdRemaining;

    private float castDuration;
    private float castRemaining;


    void Start ()
    {
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
        if (cdComplete)
        {
            AbilityReady();
            if (GameInputManager.GetKeyDown(abilityButtonAxisName))
            {
                CastAbility();
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
        castRemaining = castDuration;
        nextReadyTime = cdDuration + Time.time;
        cdRemaining = cdDuration;
        darkMask.enabled = true;
        cdTextDisplay.enabled = true;
        abilitySource.clip = ability.aSound;
        abilitySource.Play();
        ability.TriggerAbility();
    }
}
