using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MiniGunHablity : Ability
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
    void Start()
    {
        GameEvents.Dead.AddListener(Dead);
        GameEvents.Reset.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {
        MinigunShot();

        cooldownUI();      
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
        if(abilityIsOn == true)
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                time += Time.deltaTime;
                bulletTime += Time.deltaTime;
                if(bulletTime >= cadence) 
                {
                    GameObject.Instantiate(bullet, bulletSpawn1.position, quaternion.identity); //Dispara dos valas a la vez desde distintos spawns
                    GameObject.Instantiate(bullet, bulletSpawn2.position, quaternion.identity);           
                    abilityParticles.gameObject.SetActive(true);                                //Activa ambos sistemas de particulas
                    abilityParticles2.gameObject.SetActive(true);
                    bulletTime = 0;
                }   
                if(time >= maxAbilityTime) //Acytiva cooldown
                {
                    time = 0;
                    cooldownIsOn = true; 
                    abilityIsOn = false;
                }
            }
            if(Input.GetKeyUp(KeyCode.Mouse0)) //desactiva las particulas cuando se deja de disparar
            {
                abilityParticles.gameObject.SetActive(false);
                abilityParticles2.gameObject.SetActive(false);
            }
        }
        if(abilityIsOn == false) //Desactiva las particulas cuando se acaba la habilidad
        {
            abilityParticles.gameObject.SetActive(false); 
            abilityParticles2.gameObject.SetActive(false);
        }
    }

    void cooldownUI() //Cooldown y su ui
    {
        if(cooldownIsOn == true)
        {
            time += Time.deltaTime;
            normalicedNumber = cooldown - time; 
            normalicedNumber /= cooldown;
            normalicedNumber = 1 - normalicedNumber;
            print(normalicedNumber);
            cooldownImage.fillAmount = normalicedNumber;
            if(time >= cooldown)
            {
                cooldownImage.fillAmount = 1;
                cooldownIsOn = false;
                time = 0;
            }
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

}
