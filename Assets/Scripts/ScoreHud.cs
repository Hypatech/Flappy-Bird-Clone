using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHud : MonoBehaviour
{
    public Text t;
    public float scoreInterval = 1;
    public int score {
        get{
            return _score;
        }
        set{
            _score = value;
            t.text = "SCORE: " + _score.ToString();
        }
    }
    int _score;
    float _timer;
    float _scoreMod;

    void OnEnable(){
        GameStateManager.Instance.PlayerDeath += DisableMe;
    }

    void OnDisable(){
        GameStateManager.Instance.PlayerDeath -= DisableMe;
    }

    void DisableMe(){
        this.enabled = false;
    }


    void Update(){
        _timer += Time.deltaTime;
        if(_timer > scoreInterval){
            _timer = 0;
            score++;
        }
    }
}
