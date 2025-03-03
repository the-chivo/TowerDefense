using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text recordText;
    
    int score;
    int record;
    bool reset;
    void Start()
    {
        GameEvents.Score.AddListener(EnemyDead);
        GameEvents.Reset.AddListener(Reset);
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
            record = score;
        }
    }
    void Reset()
    {
        reset = true;
    }
    void Dead()
    {
        record = score;
        recordText.text = record.ToString();
        score = 0;
        scoreText.text = score.ToString();
    }

}
