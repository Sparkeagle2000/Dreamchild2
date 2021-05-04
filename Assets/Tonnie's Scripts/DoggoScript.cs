using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoScript : MonoBehaviour
{
    public Rigidbody rb;
    public float speed =20;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z>-32)
        {
            rb.velocity=transform.forward*-speed;
            if(transform.localPosition.z>1450)
            {
                Destroy(this.gameObject);
            }
        }
    }


}
