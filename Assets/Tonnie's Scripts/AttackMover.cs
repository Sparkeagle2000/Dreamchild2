using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMover : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.velocity=transform.forward*5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
