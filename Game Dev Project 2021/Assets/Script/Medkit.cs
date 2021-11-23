using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public int addHealth = 10;
    PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerScript.PlayerHealth = playerScript.PlayerHealth + addHealth;
            if (playerScript.PlayerHealth < 10) playerScript.PlayerHealth = 10;
            Destroy(gameObject);
        }
    }
}
