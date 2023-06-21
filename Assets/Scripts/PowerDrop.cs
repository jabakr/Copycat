using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDrop : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {

        if (other.tag == "Absorb Power")
        {
            Destroy(gameObject);
            if (gameObject.tag == "Fire Drop")
            {
                PowerSource.currentPower = "Fire";
                
            }
            if (gameObject.tag == "Ice Drop")
            {
                PowerSource.currentPower = "Ice";

            }
            if (gameObject.tag == "Shadow Drop")
            {
                PowerSource.currentPower = "Shadow";

            }
        }
    }
}
