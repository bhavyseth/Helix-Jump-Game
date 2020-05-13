using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    bool ignorenextcollision=false;
    public Rigidbody rb;
    public float force=5f;
    private Vector3 startpos;
    void Awake()
    {
        startpos = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {if (ignorenextcollision)
            return;
        deathpart deathPart = collision.transform.GetComponent<deathpart>();
        if (deathPart)
            deathPart.HitDeathPart();
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up*force,ForceMode.Impulse);
        ignorenextcollision = true;
        Invoke("NextCollision", 0.2f);
    }
    void NextCollision() {
        ignorenextcollision = false;
    }

    // Update is called once per frame
    public void resetball() {
        transform.position = startpos;
    }
    
}
