using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
  [SerializeField]  private Text Textscore;
   [SerializeField] private Text Textbest;
   
    private void Update()
    {
        Textbest.text = "Best:" + GameManager.singleton.best;
        Textscore.text = GameManager.singleton.score.ToString();
    }
}
