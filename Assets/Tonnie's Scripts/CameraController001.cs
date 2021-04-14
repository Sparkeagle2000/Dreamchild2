using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController001 : MonoBehaviour
{
    public float RotationSpeed=1;
    public Transform target, player;
    float x,y;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        x+=Input.GetAxis("Mouse X")*RotationSpeed;
        y-=Input.GetAxis("Mouse Y")*RotationSpeed;
        y=Mathf.Clamp(y,-35,60);

        transform.LookAt(target);
        target.rotation=Quaternion.Euler(y,x,0);
        player.rotation=Quaternion.Euler(0,x,0);
    }
}
