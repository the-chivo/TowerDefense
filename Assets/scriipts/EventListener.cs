using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static UnityEvent Reset = new UnityEvent(); //esta mezcla la funcion de morir con la de reset 
    public static UnityEvent Dead = new UnityEvent();
    public static UnityEvent Score = new UnityEvent();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
