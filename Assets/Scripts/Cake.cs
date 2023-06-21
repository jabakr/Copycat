using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public Player player;
    private AudioSource audioSource;
    public AudioClip cake;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        

    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(cake, transform.position);
            player.health++;
            Destroy(gameObject);

        }

    }


}
