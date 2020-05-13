using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public  int score;
    public  int best;
    public int currstage = 0;
    public static GameManager singleton;
    private void Awake()
    {
        
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);
        best = PlayerPrefs.GetInt("highscore");
    }
    public void NextLevel() {
        Debug.Log("bhavy seth ");
        currstage++;
        Debug.Log("curr stage is" + currstage);
        FindObjectOfType<ballcontroller>().resetball();
        FindObjectOfType<helixcontroller>().LoadStage(currstage);
        Debug.Log("next level called");
    }
    public void RestartLevel() {
        // we can show ads
        singleton.score = 0;
        FindObjectOfType<ballcontroller>().resetball();
        //reload stage
        FindObjectOfType<helixcontroller>().LoadStage(currstage);
    }
    public void addScore(int scoretoadd) {
        score += scoretoadd;
        if (score > best) {
            best = score;
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
