using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text recordText;
    
    int score;
    int record;
    int gameRecord;
    
    void Start()
    {
        GameEvents.Score.AddListener(EnemyDead);
        GameEvents.Dead.AddListener(Dead);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void EnemyDead()
    {
        score += 1;
        scoreText.text = score.ToString();
        if(score > record)
        {
            gameRecord = score;
        }
        if(score > gameRecord)
        {
            gameRecord = score;
        }
    }
    void Dead()
    {
        record = gameRecord;
        recordText.text = record.ToString();
        score = 0;
        scoreText.text = score.ToString();
    }

}
