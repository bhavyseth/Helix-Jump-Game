using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public ballcontroller target;
    float offset;
    private void Awake() 
    {
        offset = transform.position.y - target.transform.position.y;

    }
    private void FixedUpdate()
    {
        Vector3 currpos = transform.position;
        currpos.y = target.transform.position.y+offset;
        transform.position = currpos;
    }
}
