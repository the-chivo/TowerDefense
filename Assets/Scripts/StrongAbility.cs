using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class StrongAbility : Ability
{
    // Start is called before the first frame update

   public bool abilityIsOn;
   public float damage;
   [SerializeField] float abilityDuration = 5;
   [SerializeField] UnityEngine.UI.Image cooldownImage;
   public float cooldown;
   public bool cooldownIsOn = false;
   float time;
   float normalicedNumber;
   bool dead;

   public ParticleSystem strongParticles;
  
  
    void Start()
    {
        GameEvents.Dead.AddListener(Dead);
        GameEvents.Dead.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {
       
       
        
        if(abilityIsOn == true) //Sistema de particulas de la habilidad activacion de cooldown
        {
            strongParticles.gameObject.SetActive(true);
            time += Time.deltaTime;
            if(time >= abilityDuration)
            {
                strongParticles.gameObject.SetActive(false);
                time = 0;
                cooldownIsOn = true;
                abilityIsOn = false; 
            }      
        }
    
        cooldownUI(); //Funcion de cooldown                      
         
    }

    public override void trigger()
    {
        
        if(cooldownIsOn == false && dead == false)
        {
            abilityIsOn = true; 
        }
                   
    }

    void Dead()
    {
        dead = true;
        time = 0;
        abilityIsOn = false;
        cooldownIsOn = false;
    }

    void Reset()
    {
        dead = false;
        cooldownImage.fillAmount = 1;
    }

    void cooldownUI() //funcion que lleva el ui del cooldown
    {
        print("si");
        if(cooldownIsOn == true)
        {
            time += Time.deltaTime;
            normalicedNumber = cooldown - time; //normaliza el tiempo que le queda para usarlo con el fillamount
            normalicedNumber /= cooldown;
            normalicedNumber = 1 - normalicedNumber;
            cooldownImage.fillAmount = normalicedNumber;
            if(time >= cooldown)
            {
                cooldownImage.fillAmount = 1;
                cooldownIsOn = false;
                time = 0;
            }
        }
        
    }
}
