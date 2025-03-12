using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class healthAbility1 : Ability
{
    // Start is called before the first frame update
    GameObject player;
    public float healingForce;
    public float abilityDuration;
    public bool healAbilitiIsOn = false;
    public ParticleSystem healAbilityParticles;
    public float cooldown;
    [SerializeField] UnityEngine.UI.Image cooldownImage;
    bool coolwdownIsOn = false;
    bool dead;
    float time;
    float normalizedNumber;
    void Start()
    {
       GameEvents.Reset.AddListener(Reset);
       GameEvents.Dead.AddListener(Dead);
    }

    // Update is called once per frame
    void Update()
    {
        if(healAbilitiIsOn == true)
        {
            healAbilityParticles.gameObject.SetActive(true);
            time += Time.deltaTime;
            if(time >= abilityDuration)
            {
                healAbilityParticles.gameObject.SetActive(false);
                time = 0;
                coolwdownIsOn = true;
                healAbilitiIsOn = false;     
            }
        } 

        cooldownUI(); //Funcion de imagen de cooldown

    }
    public override void trigger()
    {
        if(coolwdownIsOn == false && dead == false)
        {
            gameObject.GetComponent<PlayerHealth>().Healing(); //Habilidad de curacion
            healAbilitiIsOn = true;
        }
    }
    void Reset() 
    {
        dead = false;
        cooldownImage.fillAmount = 1;
    }
    void Dead()
    {
        time = 0;
        healAbilitiIsOn = false;
        coolwdownIsOn = false;
        healAbilityParticles.gameObject.SetActive(false);
    }
     void cooldownUI() // Lleva el cooldown y su ui
    {
        if(coolwdownIsOn == true)
        {
            time += Time.deltaTime;
            normalizedNumber = cooldown - time; 
            normalizedNumber /= cooldown;
            normalizedNumber = 1 - normalizedNumber;
            cooldownImage.fillAmount = normalizedNumber;
            if(time >= cooldown)
            {
                cooldownImage.fillAmount = 1;
                coolwdownIsOn = false;
                time = 0;
            }
        }
        
    }
}
