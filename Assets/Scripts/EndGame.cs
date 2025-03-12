using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] Canvas endGameText;
    bool playerDead = false;

    void Start()
    {
        GameEvents.Dead.AddListener(PlayerDead);
      
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDead == true)
        { 
            endGameText.gameObject.SetActive(true); //texto de fin de partida
            if(Input.GetKeyDown(KeyCode.R))
            { 
                GameEvents.Reset.Invoke();   
                endGameText.gameObject.SetActive(false);
                playerDead = false;
                        
            }
        }
    }
    void PlayerDead()
    {
        playerDead = true;
    }

}
