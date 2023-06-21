using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isgrounded = true;
    private Vector3 jump;
    private float jumpForce;
    private Rigidbody rb;
    private float speed = 3.0f;
    private Vector3 startingPos;
    private Vector3 endingPos;
    private bool moveLeft = true;

    public Player player;
    public GameObject iceCube;
    private AudioSource audioSource;
    public AudioClip hit;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        startingPos = new Vector3(transform.position.x, transform.position.y, gameObject.transform.position.z);
        endingPos = new Vector3(transform.position.x, transform.position.y, gameObject.transform.position.z - 8.0f);
        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Fire Enemy")
        {
            jumpForce = 0.35f;
            Jump();
            
        }

        if (gameObject.tag == "Ice Enemy")
        {
            Patrol();        

        }
        
        if (gameObject.tag == "Shadow Enemy")
        {
            speed = 2.0f;
            jumpForce = 0.4f;
            Jump();
            Patrol();

        }



    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isgrounded = true;
        }

        if (collision.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(hit);
            player.health--;
            player.gameObject.transform.Translate(transform.forward * 200f * Time.deltaTime, Space.Self);
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isgrounded = false;
        }

    }

    void OnParticleCollision(GameObject other)
    {

        if (other.tag == "Absorb Power")
        {
            Destroy(gameObject);
            if (gameObject.tag == "Fire Enemy")
            {
                PowerSource.currentPower = "Fire";
            }
            if (gameObject.tag == "Ice Enemy")
            {
                PowerSource.currentPower = "Ice";
            }
            if (gameObject.tag == "Shadow Enemy")
            {
                PowerSource.currentPower = "Shadow";
            }
        }

        if (other.tag == "Fire Power")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Ice Power")
        {
            Instantiate(iceCube, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
        if (other.tag == "Shadow Power")
        {
            Destroy(gameObject);
            Destroy(other);
        }

    }

    void Jump()
    {
        if (isgrounded == true)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);

        }

    }

    void Patrol()
    {
        if (Vector3.Distance(transform.position, endingPos) < 0.001f)
        {
            moveLeft = false;
        }

        if (Vector3.Distance(transform.position, startingPos) < 0.001f)
        {
            moveLeft = true;
        }

        if (moveLeft == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPos, Time.deltaTime * speed);
        }

        if (moveLeft == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endingPos, Time.deltaTime * speed);
        }

    }
}
