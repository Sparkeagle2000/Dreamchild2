using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanclaScript : MonoBehaviour
{
    public TimeManager timemanager;
    public float rotate=33;
    Quaternion downAngle,upAngle;
    float speed=0.0f;
    bool forward=true,back=false;
    //Transform up, down;
    // Start is called before the first frame update
    void Start()
    {
        upAngle=transform.rotation;
        upAngle *=  Quaternion.AngleAxis(rotate, Vector3.left);
        downAngle=transform.rotation;
        //down=this.transform;
        //down.position=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(timemanager.TimeIsStopped)
        {

        }
        else
        {
            if(speed<0.8f)
            {
                speed+=Time.deltaTime/2;
            }
            if(forward)
            {
                transform.rotation= Quaternion.Lerp (transform.rotation, upAngle , 30 * speed * Time.deltaTime); 
                if (Quaternion.Angle (transform.rotation,upAngle) < 1 )
                {
                    //Debug.Log("made it inside first check");
                    forward = false;
                    back=true;
                    speed=0.0f;
                    //if(up.position==null)
                    //{
                    //    up=this.transform;
                    //    up.position=transform.position;
                    //}
                }
            }
            if(back)
            {
                transform.rotation = Quaternion.Lerp (transform.rotation,downAngle, 30 * speed * Time.deltaTime);
                if (Quaternion.Angle (downAngle,transform.rotation) < 1 )
                {
                    forward = true;
                    back=false;
                    speed=0.0f;
                }
            }
        }
    }
}
