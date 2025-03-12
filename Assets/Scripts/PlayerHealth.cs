using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float maxHealth = 50;
    [SerializeField] float currentHealth;
    [SerializeField] Gradient playerGradientColor;
    [SerializeField] SpriteRenderer playerColor;
    [SerializeField] float pasiveHealingPerSecond;
    public bool endGame = false;
    bool dead;
    float normalizedHealth;

    void Start()
    {
        currentHealth = maxHealth;
        GameEvents.Dead.AddListener(Dead);
        GameEvents.Reset.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {
        PasiveHealing(); // Curacion pasiva        
        Healing();       // abilidad de curacion

        if(currentHealth > maxHealth) //Para la que nunca se supere la vida maxima
        {
            currentHealth = maxHealth;
        }
       
    }

    public void takeDamage(float amount)//Funcion de recibir daño
    {
        currentHealth -= amount;
        SetColor();
        if(currentHealth <= 0) //Muerte del pj
        {
            GameEvents.Dead.Invoke();
            endGame = true;
        }
        
    }
    void SetColor()//Normaliza la vida y seteaelcolor
    {
        normalizedHealth = currentHealth/maxHealth;
        playerColor.color = playerGradientColor.Evaluate(normalizedHealth);
    }

    public void Healing()//Habilidad de curacion 
    {
        if(gameObject.GetComponent<healthAbility1>().healAbilitiIsOn == true)
        {
            currentHealth += gameObject.GetComponent<healthAbility1>().healingForce;
            //el sistema de poarticulas de esta habilidad esta en healHability1
        }   
        
    }
    public void PasiveHealing() //curacion pasiva
    {
        if(dead == false)
        {
            currentHealth += pasiveHealingPerSecond;
            SetColor(); 
        }
    }
    void Dead()
    {
        dead = true;
    }
    void Reset()
    {
        currentHealth = maxHealth;
        SetColor();
        dead = false;
    }

}
