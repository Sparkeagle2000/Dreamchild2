using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController001 : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public KeyCode fire;
    public KeyCode jump;
    public AudioSource walk;
    public float dashSpeed, dashTime, startDash;

    private float nextFire;
    public Rigidbody rb;
    public bool onGround=true;
    public bool growth=false;
    public bool time=false;
    public bool speedy=false;
    public bool growthAcquired=false;
    public bool speedAcquired=false;
    public bool timeAcquired=false;
    public bool nightmaretrigger=false;
    public bool dojotrigger=false;
    public bool chasetrigger=false;
    public bool hub=false;
    public float count=5.0f;
    public AudioClip footsteps;
    bool music=false;
    public int win;
    //public AudioSource suzie;

    private float growthScale=1.0f;
    private float growthcount=2;
    private float timer=0.0f;
    private Transform current,last,move;


    private TimeManager timemanager;
    // Start is called before the first frame update
    void Start()
    {
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        rb=GetComponent<Rigidbody>();
        win=PlayerPrefs.GetInt("win");
        if(PlayerPrefs.GetInt("time")==1)
        {
            timeAcquired=true;
        }
        if(PlayerPrefs.GetInt("growth")==1)
        {
            growthAcquired=true;
        }
        if(PlayerPrefs.GetInt("speed")==1)
        {
            speedAcquired=true;
        }
        //if(PlayerPrefs.GetInt("win")==3)
        //{
            //winscreen/scene
        //}
        dashTime=startDash;
        current.position=transform.position;
        last.position=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if(speedy)
        {
            transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime*5));
        }
        else
        {
            transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime));
        }
        if(Input.GetKeyDown(jump)&&onGround)
        {
            //Debug.Log("jumping");
            if(growthScale==3)
            rb.AddForce(new Vector3(0,7*2,0), ForceMode.Impulse);
            if(growthScale==1)
            rb.AddForce(new Vector3(0,7,0), ForceMode.Impulse);
            if(growthScale==0.3)
            rb.AddForce(new Vector3(0,2,0), ForceMode.Impulse);
            onGround=false;
        }

        if(current.position!=transform.position)
        {
            last.position=current.position;
            current.position=transform.position;
        }

        if(Input.GetKeyDown(KeyCode.F)&&nightmaretrigger)
        {
            SceneManager.LoadScene("Nightmare Stage");
        }
        if(Input.GetKeyDown(KeyCode.F)&&dojotrigger)
        {
            SceneManager.LoadScene("Dojo Stage");
        }
        if(Input.GetKeyDown(KeyCode.F)&&chasetrigger)
        {
            SceneManager.LoadScene("Chase Stage");
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(growthcount==3)
            {
                growthcount=1;
            }
            else
            {
                growthcount++;
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(growthcount==1)
            {
                growthcount=3;
            }
            else
            {
                growthcount--;
            }
        }

        if(growthcount==1)
        {
            growthScale=0.3f;
        }

        if(growthcount==2)
        {
            growthScale=1.0f;
        }

        if(growthcount==3)
        {
            growthScale=3.0f;
        }

            //Attack script for attack
        //if (Input.GetKeyDown(fire) && Time.time > nextFire)
        //{
        //    nextFire=Time.time+fireRate;
        //    Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
        //}

        if(!hub)
        {

            if(Input.GetKeyDown(KeyCode.Tab))
            {
                if(growth&&timeAcquired)
                {
                    time=true;
                    growth=false;
                }
                else if(growth&&speedAcquired)
                {
                    speedy=true;
                    growth=false;
                }
                else if(time&&speedAcquired)
                {
                    speedy=true;
                    time=false;
                }
                else if(time&&growthAcquired)
                {
                    growth=true;
                    time=false;
                }
                else if(speedy&&growthAcquired)
                {
                    growth=true;
                    speedy=false;
                }
                else if(speedy&&timeAcquired)
                {
                    time=true;
                    speedy=false;
                }
            }

            if(speedy)
            {
                if(Input.GetKeyUp(KeyCode.F)&&timer>2.0f)
                {
                    Dash();
                }
                else if(Input.GetKey(KeyCode.F))
                {
                    timer+=Time.deltaTime;
                }
                else if(Input.GetKeyUp(KeyCode.F))
                {
                    timer=0;
                }
            }
        
            if(growth)
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    transform.localScale=new Vector3(growthScale,growthScale,growthScale);
                }
            }
            if(time)
            {

                if(Input.GetKeyDown(KeyCode.F)&& !timemanager.TimeIsStopped) 
                {
                    timemanager.StopTime();

                }
                else if(Input.GetKeyDown(KeyCode.F) && timemanager.TimeIsStopped) 
                {
                    timemanager.ContinueTime();

                }   
                if(count<=0.0f)
                {
                    timemanager.ContinueTime();
                }
                if(!timemanager.TimeIsStopped && count<5.0f) 
                {
                    count+=Time.deltaTime;

                }
                if(timemanager.TimeIsStopped) 
                {
                    count-=Time.deltaTime;

                }   
            }
        }
        if((horizontal!=0.0f||vertical!=0.0f)&&!music)
        {
            walk.Play();
            music=true;
        }
        else if(horizontal==0.0f&&vertical==0.0f)
        {
            walk.Pause();
            music=false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Floor")
        {
            onGround=true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name=="TimeStop")
        {
            timeAcquired=true;
            PlayerPrefs.SetInt("time",1);
            Destroy(other.gameObject);
        }
        if(other.name=="Growth")
        {
            growthAcquired=true;
            PlayerPrefs.SetInt("growth",1);
            Destroy(other.gameObject);
        }
        if(other.name=="Speed")
        {
            speedAcquired=true;
            PlayerPrefs.SetInt("speed",1);
            Destroy(other.gameObject);
        }
        if(other.name=="Nightmare")
        {
            nightmaretrigger=true;
        }
        if(other.name=="Dojo")
        {
            dojotrigger=true;
        }
        if(other.name=="Chase")
        {
            chasetrigger=true;
        }
        if(other.name=="Doodoo")
        {
            StartCoroutine(Slip());
        }
        if(other.name=="Macguffin")
        {
            win++;
            PlayerPrefs.SetInt("win",win);
        }
        if(other.name=="Big Doggo")
        {
            Destroy(this.gameObject);
        }
        if(other.name=="Lemur")
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.name=="Nightmare")
        {
            nightmaretrigger=false;
        }
        if(other.name=="Dojo")
        {
            dojotrigger=false;
        }
        if(other.name=="Chase")
        {
            chasetrigger=false;
        }
    }

    IEnumerator Slip()
    {
        speed=speed/2;
        yield return new WaitForSeconds(2);
        speed=speed*2;
    }

    void Dash()
    {
        move.position=transform.position-last.position;
        while(dashTime>0)
        {
            dashTime-=Time.deltaTime;
            rb.velocity=new Vector3(move.position.x,0,move.position.z)*dashSpeed;
        }
                        
        dashTime=startDash;
        timer=0;
    }
}
