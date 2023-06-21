using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public Player player;

    private AudioSource audioSource;
    public AudioClip falling;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(falling);
            player.lives--;
            other.gameObject.transform.position = player.startPos;
            player.health = 5;

        }

    }
}
