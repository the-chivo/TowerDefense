using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float currentHealth = 100;
    [SerializeField] Gradient enemyGradientColor;
    [SerializeField] SpriteRenderer enemyColor;
    float maxHealth = 100;
    public float  normalizedHealth;
   
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeBulletDamage(float amount) //Funcion de recibir daño de proyectil
    {
        if (currentHealth <= 0)  
        {    
            GetComponent<EnemyScript>().EnemyDead(); //ESTAFUNCION elimina al enemigo
            GameEvents.Score.Invoke();               // Esta invoka que el enemigo ha muerto a manos del juagdor
        }

        currentHealth -= amount;
        normalizedHealth = currentHealth/maxHealth;
        enemyColor.color = enemyGradientColor.Evaluate(normalizedHealth); 
    }

    
   
}
