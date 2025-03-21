using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class AbilityHolder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Ability[] abilities;
    [SerializeField] UnityEngine.UI.Image abilitySelector;
    [SerializeField] Transform abiliti;
    [SerializeField] Transform abiliti1;
    [SerializeField] Transform abiliti2;
    [SerializeField] Transform abiliti3;
    int listnum;
    bool dead;
    void Start()
    {
        GameEvents.Dead.AddListener(Dead);
        GameEvents.Reset.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == false)
        {

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                listnum = 0;
                abilitySelector.gameObject.transform.position = abiliti.position;
            }
        
            if(Input.GetKeyDown(KeyCode.Alpha2)) //curacion
            {
                listnum = 1;
                abilitySelector.gameObject.transform.position = abiliti1.position;
            }
            if(Input.GetKeyDown(KeyCode.Alpha3)) //Fuerza
            {
                listnum = 2;
                abilitySelector.gameObject.transform.position = abiliti2.position;
            }
            if(Input.GetKeyDown(KeyCode.Alpha4)) //MiniGun
            {
                listnum = 3;
                abilitySelector.gameObject.transform.position = abiliti3.position;
            }
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
         
                abilities[listnum].trigger();
                listnum = 0;
                abilitySelector.gameObject.transform.position = abiliti.position;
            }                          
        }
    }
    private void Dead()
    {
        dead = true;
    }
    private void Reset()
    {
        dead = false;
    }
}
