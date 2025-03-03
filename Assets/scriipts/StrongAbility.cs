using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class StrongAbility : ability
{
    // Start is called before the first frame update

   public bool strongAbility;
   public float strong;
   public float damage;
   [SerializeField] float abilityMaxTime = 5;
   [SerializeField] UnityEngine.UI.Image cooldownImage;
   public float cooldown;
   bool cooldownIsOn = false;
   float time;
   float normalicedNumber;
   bool dead;
   bool reset;

   public ParticleSystem strongParticles;
  
  
    void Start()
    {
        GameEvents.Dead.AddListener(Dead);
        GameEvents.Reset.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {
       if(strongAbility == true && cooldownIsOn == false) //*Este sistema de particulas esta en bullet script
       {
            time += Time.deltaTime;
            if(time >= abilityMaxTime)
            {
                time = 0;
                cooldownIsOn = true;
                strongAbility = false;
            }
       }
       if(cooldownIsOn == true)
        {
            time += Time.deltaTime;
            if(time >= cooldown)
            {
                time = 0;
                cooldownIsOn = false;
                    
            }
        }
       if(dead == true) //aki alomejor falta lo de reset y sobran cosas
        {
            time = 0;
            strongAbility = false;
            cooldownIsOn = false;
            if(reset == true)
            {
                dead = false;
                reset = false;
            }
        }
        
        if(strongAbility == true) //Sistema de particulas de la habilidad
        {
            strongParticles.gameObject.SetActive(true);
        } 

        if(strongAbility == false)
        {
            strongParticles.gameObject.SetActive(false);
        }           

        cooldownUI(); //Funcion de cooldown     
            
    }
    public override void trigger()
    {
        if(cooldownIsOn == false && dead == false) //Activa la habilidad si el coldown esta desactivado y el jugador no esta muerto
        {
            strongAbility = true;  
        }                
    }
    void Dead()
    {
        dead = true;
    }
    void Reset()
    {
        reset = true;
    }
    void cooldownUI() //funcion que lleva el ui del cooldown
    {
        if(cooldownIsOn == true)
        {
            normalicedNumber = cooldown - time; //normaliza el tiempo que le queda para usarlo con el fillamount
            normalicedNumber /= cooldown;
            normalicedNumber = 1 - normalicedNumber;
            cooldownImage.fillAmount = normalicedNumber;
        }
        if(cooldownIsOn == false)
        {
            cooldownImage.fillAmount = 1;
        }
    }
}
