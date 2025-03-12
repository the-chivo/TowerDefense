using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class shoot : Ability
{
    // Start is called before the first frame update
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject player;
    [SerializeField] MovimientoRaton angle;
    [SerializeField] Transform spawnPoint;
    bool dead = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        GameEvents.Dead.AddListener(Dead);
        GameEvents.Reset.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void trigger()
    {
        if(dead == false) //Solo instyancia la bala si no esta muerto
        {
            GameObject.Instantiate(bullet, spawnPoint.position, quaternion.Euler(0,0,angle.angle));
        }
        
    }
    void Dead()
    {
        dead = true;
    }
    void Reset()
    {  
        dead = false;  
    }
}
