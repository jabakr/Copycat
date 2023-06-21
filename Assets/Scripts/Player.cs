using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;

    public int health;
    public int lives;
    public Vector3 startPos;
    private AudioSource audioSource;
    public AudioClip jump;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        health = 5;
        lives = 3;
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(0, 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        
        if (Input.GetButton("Jump") && groundedPlayer)
        {
            audioSource.Play();
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (Input.GetButton("Power"))
        {
            playerSpeed = 0.0f;
            
        }
        
        if (Input.GetButtonUp("Power"))
        {
            StartCoroutine(cooldown());
        }
        
        IEnumerator cooldown()
        {
            if (PowerSource.currentPower == "None")
            {
                yield return new WaitForSeconds(1.0f);

            }
            if (PowerSource.currentPower == "Fire")
            {
                yield return new WaitForSeconds(1.5f);

            }
            if (PowerSource.currentPower == "Ice")
            {
                yield return new WaitForSeconds(2.0f);

            }
            if (PowerSource.currentPower == "Shadow")
            {
                yield return new WaitForSeconds(0.5f);

            }

            playerSpeed = 5.0f;

        }

        if(health == 0)
        {
            lives--;
            transform.position = startPos;
            health = 5;
        }
        if (lives <= 0)
        {
            PowerSource.currentPower = "None";
            SceneManager.LoadScene(sceneName: "Game Over");

        }
    }

}

