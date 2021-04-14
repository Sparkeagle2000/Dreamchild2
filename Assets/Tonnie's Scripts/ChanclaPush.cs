using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanclaPush : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Vector3 push=new Vector3(other.transform.position.x+6.0f,other.transform.position.y,other.transform.position.z);
            other.transform.position=push;
        }
    }
}
