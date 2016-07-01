using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovementPlayer : MonoBehaviour
{
    
    private float counter;

    public Text powerupText;

    private int randomNum;
    public string currPowerUp;

    private PlayerShooting ps;
    private PlayerHealth ph;

    private bool powerUp1;
    private bool powerUp2;
    private bool powerUp3;
    private bool powerUp4;
    private bool powerUp5;

    private float X = 0;
    private float Y = 0;
    private float Z = 0;

    public float speedF = 0;
    private float speedB = 0;
    private float rotationR = 0;
    private float rotationL = 0;

    private float speedFmax = 20f;
    private float speedBmax = 20f;
    private float rotateLmax = 50f;
    private float rotateRmax = 50f;

    private float rotateL = 50f;
    private float rotateR = 50f;
    private float moveF = 0.4f;
    private float moveB = 0.4f;

    private Rigidbody rb;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            randomNum = Random.Range(1, 5);
            Debug.Log(randomNum);
            powerUp();
        }
        if (other.CompareTag("Mine"))
        {
            ph.Health -= 500;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("EnemyBullet"))
        {
            ph.Health -= 80;
        }
    }

    void Start()
    {
       ph = GetComponent<PlayerHealth>();
       ps = GetComponent<PlayerShooting>();
        //Y = 3.5f;
        rb = GetComponent<Rigidbody>();
        this.transform.position = new Vector3(X, Y, Z);
        counter = 0;
    }

    void Update()
    {
        
        UpdatepowerupUI();

        //POWER-UP MANAGER

        //Swiftness
        if (powerUp2 == true)
        {
            speedFmax = 30f;
            speedBmax = 30f;
            rotateLmax = 70f;
            rotateRmax = 70f;
        }
        else
        {
            speedFmax = 20f;
            speedBmax = 20f;
            rotateRmax = 50f;
            rotateRmax = 50f;
        }



        //HEALTH REGEN
        if (ph.Health <= 750 && counter < Time.time)
        {
            counter = Time.time + 1f;
            regen();
        }


        //HEALTH MAX
        if (ph.Health >= 1000)
        {
            ph.Health = 1000;
        }
        if (ph.Health <= 0)
        {
            Destroy(this.gameObject);
        }

        //MOVE FORWARD
        if (Input.GetKey(KeyCode.W))
        {
            if (speedF < speedFmax)
            {
                speedF += moveF;
               
            }
        }
        else
        {
            if (speedF > 0.4f)
            {
                speedF -= moveF;
            }

        }
        //ROTATE TO LEFT
        if (Input.GetKey(KeyCode.A))
        {
            rotationL = rotateL;
        }
        else
        {
            rotationL = 0f;
        }

        //MOVE BACKWARDS
        if (Input.GetKey(KeyCode.S))
        {
            if (speedB < 20)
            {
                speedB += moveB;
            }
        }
        else
        {
            if (speedB > 0.4f)
            {
                speedB -= moveB;
            }
        }

        //ROTATE TO RIGHT
        if (Input.GetKey(KeyCode.D))
        {

            rotationR = rotateR;
        }
        else
        {
            rotationR = 0f;
        }

        if(ph.Health == 0)
        {
            Destroy(gameObject);
        }
    }


    void FixedUpdate()
    {

        float rotation = rotationR - rotationL;
        float speed = speedF - speedB;

        rb.MovePosition(rb.position + (transform.TransformDirection(Vector3.forward) * speed * Time.fixedDeltaTime));
        rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * rotation * Time.fixedDeltaTime));


    }
    void regen()
    {
        if (powerUp5 == true)
        {
            ph.Health += 25;
        }
        else
        {
            ph.Health += 12;
        }
    }

    void powerUp()
    {
        Debug.Log(randomNum);
        Debug.Log("StopDepressingMe");
        powerUp1 = false;
        powerUp2 = false;
        powerUp3 = false;
        powerUp4 = false;
        powerUp5 = false;
        ps.poweredUp = false;
        ps.fireRate = 0.3f;
        if (randomNum == 1)
        {
            currPowerUp = "BulletPower!";
            powerUp1 = true;
            ps.poweredUp = true;
            //done

        }
        if (randomNum == 2)
        {
            currPowerUp = "Swiftness!";
            powerUp2 = true;
            //done
        }
        if (randomNum == 3)
        {
            currPowerUp = "You Healed!";
            powerUp3 = true;
            ph.Health += 250;
            //done

        }
        if (randomNum == 4)
        {
            currPowerUp = "Rapid Fire!";
            powerUp4 = true;
            ps.fireRate = 0.2f;
            //done
        }
        if (randomNum == 5)
        {
            powerUp5 = true;
            currPowerUp = "Regen Up!";
            //done
        }

    }

    private void UpdatepowerupUI()
    {
        powerupText.text = "PowerUp=" + currPowerUp.ToString();
    }

}