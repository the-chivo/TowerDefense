using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovimientoRaton : MonoBehaviour
{
    // Start is called before the first frame update
    public float angle;
    bool dead;
    void Start()
    {
        GameEvents.Reset.AddListener(Reset);
        GameEvents.Dead.AddListener(Dead);
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == false) //movimiento de jugador
        {
            Vector3 mouseScreenCoords = Input.mousePosition;
            Vector3 mouseInWorldCoords = Camera.main.ScreenToWorldPoint(mouseScreenCoords);
            mouseInWorldCoords.z = 0;
            Vector3 directionToMouse = mouseInWorldCoords - transform.position;
            Vector3 referenceDirection = new Vector3(0,1,0);
            angle = Vector3.SignedAngle(referenceDirection, directionToMouse, Vector3.forward);
            gameObject.transform.rotation = Quaternion.Euler(0,0,angle);
        }

    }
    void Reset() //funcion de muerte del player
    {
        dead = false;
    }
    void Dead()
    {
        dead = true;
    }
}
