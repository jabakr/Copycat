using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWall : MonoBehaviour
{
    private float meltSpeed = 0.03f;

    // Update is called once per frame
    void Update()
    {
        


    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Fire Power")
        {
            transform.Translate(Vector3.down * meltSpeed * Time.deltaTime);
        }
    }
}
