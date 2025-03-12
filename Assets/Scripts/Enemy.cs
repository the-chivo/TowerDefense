using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] float damage;
    GameObject playerTransform;
    
    
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").gameObject;
        GameEvents.Dead.AddListener(EnemyDead);
        
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento
        EnemyMovement();
                                        
    }
    private void EnemyMovement()//movimiento funcion
    {
        UnityEngine.Vector3 direccion = playerTransform.transform.position - gameObject.transform.position;
        gameObject.transform.position += direccion.normalized * speed * Time.deltaTime;
    }
    
    public void EnemyDead() //mata al enemigo
    {
        
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) //sistema de daño y muerte al colisionar con jugador
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(damage);
            EnemyDead();
        }
    }
}
