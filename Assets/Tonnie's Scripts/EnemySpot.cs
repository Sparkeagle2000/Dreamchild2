using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpot : MonoBehaviour
{
    TimeManager timemanager;
    public Transform player;
    float speed = 6.0f;
    bool playerSighted;
    // Start is called before the first frame update
    void Start()
    {
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        playerSighted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSighted)
            PlayerFound();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerSighted = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            playerSighted = false;
    }

    void PlayerFound()
    {
        if (!timemanager.TimeIsStopped)
        {
            Vector3 lookAtPos = new Vector3(player.position.x, player.position.y, player.position.z);
            lookAtPos.y = transform.position.y;
            transform.LookAt(lookAtPos);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
