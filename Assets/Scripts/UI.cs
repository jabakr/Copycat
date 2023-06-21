using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text power;
    public Text health;
    public Text lives;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        power.text = PowerSource.currentPower;
        health.text = player.health.ToString();
        lives.text = player.lives.ToString();

    }
}
