using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    float gameTime;
    [SerializeField] float Spawntime;
    [SerializeField] List<Transform> spawnerList;
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTimeDecrementPerTime;
    [SerializeField] float maxSecondBeforeMultipler;
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
        
        if(time > Spawntime && dead == false) //spawner de enemigos
        {
            GameObject.Instantiate(enemy, spawnerList[UnityEngine.Random.Range(0,spawnerList.Count)].position, quaternion.identity);
            time = 0;
        }
        
        DificultySistem();
    }
    void Reset() //Detecta si el jugador a muerto
    {
        reset = true;
        gameTime = 0;
        Spawntime = 1.25f;
        dead = false;
        reset = false;
    }
    void Dead()
    {
        dead = true;
    }
    void DificultySistem()
    {
        gameTime += Time.deltaTime;
        if (gameTime >= maxSecondBeforeMultipler)
        {
            Spawntime -= spawnTimeDecrementPerTime;
            gameTime = 0;

        }
        if(Spawntime <= 0.2)
        {
            Spawntime = 0.2f;
        }
        
    }
}