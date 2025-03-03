using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    float gameTime;
    [SerializeField] float Spawntime;
    [SerializeField] List<Transform> spawnerList;
    [SerializeField] GameObject enemy;
    bool reset = false;
    bool dead = false;
    void Start()
    {
        GameEvents.Reset.AddListener(Reset);
        GameEvents.Dead.AddListener(Dead);
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        
        time += Time.deltaTime;
        if(reset == true) //boton de reinicio
        {
            gameTime = 0;
            Spawntime = 1.25f;
            dead = false;
            reset = false;
        }
        if(time > Spawntime && dead == false) //spawner de enemigos
        {
            GameObject.Instantiate(enemy, spawnerList[UnityEngine.Random.Range(0,spawnerList.Count)].position, quaternion.identity);
            time = 0;
        }
        
        if(gameTime >= 15)
        {
            Spawntime = 1;
        }
        if(gameTime >= 30)
        {
            Spawntime = 0.7f;
        }
        if(gameTime >= 45)
        {
            Spawntime = 0.6f;
        }
        if(gameTime >= 60)
        {
            Spawntime = 0.45f;
        }
        if(gameTime >= 80)
        {
            Spawntime = 0.30f;
        }
        if(gameTime >= 100)
        {
            Spawntime = 0.20f;
        }
    }
    void Reset() //Detecta si el jugador a muerto
    {
        reset = true;
    }
    void Dead()
    {
        dead = true;
    }
}