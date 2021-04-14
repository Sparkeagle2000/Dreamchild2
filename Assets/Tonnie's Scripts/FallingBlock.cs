using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    Vector3 p;
    Quaternion q,stopQ;
    public Rigidbody rb;
    public bool stop;
    public bool first=true;
    // Start is called before the first frame update
    void Start()
    {
        q=transform.rotation;
        p=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-5)
        {
            transform.rotation=q;
            transform.position=p;
        }
        if(stop&&first)
        {
            stopQ=transform.rotation;
            Vector3 forceToAdd =new Vector3(0,0,0);
 
            rb.velocity = forceToAdd;
            rb.useGravity=false;
            first=false;
        }
        if(stop)
        {
            transform.rotation=stopQ;
        }
        else
        {
            first=true;
            rb.useGravity=true;
        }
        
    }
}
