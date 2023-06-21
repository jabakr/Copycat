using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSource : MonoBehaviour
{
    public ParticleSystem firePower;
    public ParticleSystem icePower;
    public ParticleSystem shadowPower;
    public ParticleSystem absorbPower;
    public static string currentPower = "None";
    public GameObject fireDrop;
    public GameObject iceDrop;
    public GameObject shadowDrop;
    public Player player;

    private AudioSource audioSource;
    public AudioClip fire;
    public AudioClip ice;
    public AudioClip shadow;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Power"))
        {
            if (currentPower == "None")
            {
                Instantiate(absorbPower, transform.position, transform.rotation);
            }

            if (currentPower == "Fire")
            {
                Instantiate(firePower, transform.position, transform.rotation);
                
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(fire);
                }
            }
            if (currentPower == "Ice")
            {
                Instantiate(icePower, player.transform.position, transform.rotation);

                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(ice);
                }
            }
           
        }
        if (Input.GetButtonDown("Power"))
        {
            if (currentPower == "Shadow")
            {
                Instantiate(shadowPower, transform.position, transform.rotation);
                audioSource.PlayOneShot(shadow);

            }
        }
        if (Input.GetButtonDown("DePower") && PowerSource.currentPower != "None")
        {
            GameObject[] fireDrops = GameObject.FindGameObjectsWithTag("Fire Drop");
            foreach (GameObject fireDrop in fireDrops)
                GameObject.Destroy(fireDrop);

            GameObject[] iceDrops = GameObject.FindGameObjectsWithTag("Ice Drop");
            foreach (GameObject iceDrop in iceDrops)
                GameObject.Destroy(iceDrop);

            GameObject[] shadowDrops = GameObject.FindGameObjectsWithTag("Shadow Drop");
            foreach (GameObject shadowDrop in shadowDrops)
                GameObject.Destroy(shadowDrop);

            if (currentPower == "Fire")
            {
                Instantiate(fireDrop, transform.position + (transform.forward * 1.5f), transform.rotation);
                
            }
            if (currentPower == "Ice")
            {
                Instantiate(iceDrop, transform.position + (transform.forward * 1.5f), transform.rotation);
            }
            if (currentPower == "Shadow")
            {
                Instantiate(shadowDrop, transform.position + (transform.forward * 1.5f), transform.rotation);
            }
            currentPower = "None";

        }
    }
}
