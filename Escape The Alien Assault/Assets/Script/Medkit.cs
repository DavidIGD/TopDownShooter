using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) //destroys medkit and plays sound when player collides
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("medkit");
            Destroy(gameObject);
        }
    }
}
