using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passcheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.addScore(2);
    }
}
