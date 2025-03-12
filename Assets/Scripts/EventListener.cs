using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static UnityEvent Reset = new UnityEvent(); 
    public static UnityEvent Dead = new UnityEvent();
    public static UnityEvent Score = new UnityEvent();
    
}
