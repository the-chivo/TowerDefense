using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MiniGunHablity : ability
{
    // Start is called before the first frame update
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawn1;
    [SerializeField] Transform bulletSpawn2;
    [SerializeField] float maxAbilityTime;
    [SerializeField] float cooldown;
    [SerializeField] float cadence;
    [SerializeField] Image cooldownImage;
    [SerializeField] ParticleSystem abilityParticles;
    [SerializeField] ParticleSystem abilityParticles2;
    bool abilityIsOn;
    bool cooldownIsOn;
    float bulletTime;
    float time;
    float normalicedNumber;
    bool dead;
    bool reset;
    void Start()
    {
        GameEvents.Dead.AddListener(Dead);
        GameEvents.Reset.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {
        if(abilityIsOn == true)
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                if(abilityIsOn == true && cooldownIsOn == false)
                {
                    abilityParticles.gameObject.SetActive(true);
                    abilityParticles2.gameObject.SetActive(true);
                    MinigunShot(); //Dispara la bala
                    time += Time.deltaTime; //cuenta el timepo que dura la habilidad
                    if(time >= maxAbilityTime) // se acaba el tiempo
                    {
                        time = 0;
                        cooldownIsOn = true; //activa coldow descativa habilidad y setea time a 0
                        abilityIsOn = false;
                    }
                }
            }
            if(Input.GetKeyUp(KeyCode.Mouse0) && abilityIsOn == true) //desactiva las particulas cuando se deja de disparar
            {
                abilityParticles.gameObject.SetActive(false);
                 abilityParticles2.gameObject.SetActive(false);
            }
        }
        if(abilityIsOn == false)
        {
            abilityParticles.gameObject.SetActive(false); //desactiva las aprticulas cuando se acaba la habilidad
            abilityParticles2.gameObject.SetActive(false);
        }
        if(cooldownIsOn == true) // sistema de cooldown
        {
            time += Time.deltaTime;
            print(time);
            if(time >= cooldown)
            {
                abilityIsOn = false;
                time = 0;
                cooldownIsOn = false;
            }
        }

        cooldownUI();
        if(dead == true) //aki alomejor falta lo de reset y sobran cosas
        {
            time = 0;
            abilityIsOn = false;
            cooldownIsOn = false;
            if(reset == true)
            {
                dead = false;
                reset = false;
            }
        }
        
    }
    
    public override void trigger()
    {
        if(cooldownIsOn == false)
        {
            abilityIsOn = true;
        }
    }
    
    void MinigunShot()
    {
        bulletTime += Time.deltaTime;
        if(bulletTime >= cadence)
            {
                GameObject.Instantiate(bullet, bulletSpawn1.position, quaternion.identity); //Dispara dos valas a la vez desde distintos spawns
                GameObject.Instantiate(bullet, bulletSpawn2.position, quaternion.identity);           
                bulletTime = 0;
            }   
    }
    void cooldownUI() //funcion que lleva el ui del cooldown
    {
        if(cooldownIsOn == true)
        {
            normalicedNumber = cooldown - time; //normaliza el tiempo que le queda para usarlo con el fillamount
            normalicedNumber /= cooldown;
            normalicedNumber = 1 - normalicedNumber;
            print(normalicedNumber);
            cooldownImage.fillAmount = normalicedNumber;
        }
        if(cooldownIsOn == false)
        {
            cooldownImage.fillAmount = 1;
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

}
