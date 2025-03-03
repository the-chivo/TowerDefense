using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class healthAbility1 : ability
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
    bool reset;
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
        if(healAbilitiIsOn == true && coolwdownIsOn == false)
        {
            healAbilityParticles.gameObject.SetActive(true);
            time += Time.deltaTime;
            print(time);
            if(time >= abilityDuration)
            {
                healAbilityParticles.gameObject.SetActive(false);
                time = 0;
                coolwdownIsOn = true;
                healAbilitiIsOn = false;     
            }
        }
        if(coolwdownIsOn == true) //sistema de coldown
        {
            time += Time.deltaTime;
            //print("coldown: " + time);
            if(time >= cooldown)
            {
                time = 0;
                coolwdownIsOn = false;
            }
        }

        if(dead == true) //Funcion de reset;
        {
            time = 0;
            healAbilitiIsOn = false;
            coolwdownIsOn = false;
            healAbilityParticles.gameObject.SetActive(false);
            if(reset == true)
            {
                dead = false;
                reset = false;
            }
        }

        

        cooldownUI(); //Funcion de imagen de cooldown
    }
    public override void trigger()
    {
        if(coolwdownIsOn == false)
        {
            gameObject.GetComponent<PlayerHealth>().Healing(); //Habilidad de curacion
            healAbilitiIsOn = true;
        }
    }
    void Reset() 
    {
        reset = true;
    }
    void Dead()
    {
        dead = true;
    }
     void cooldownUI() //funcion que lleva el ui del cooldown
    {
        if(coolwdownIsOn == true)
        {
            normalizedNumber = cooldown - time; //normaliza el tiempo que le queda para usarlo con el fillamount
            normalizedNumber /= cooldown;
            normalizedNumber = 1 - normalizedNumber;
            cooldownImage.fillAmount = normalizedNumber;
        }
        if(coolwdownIsOn == false)
        {
            cooldownImage.fillAmount = 1;
        }
    }
}
