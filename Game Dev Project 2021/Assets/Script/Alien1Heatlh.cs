using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien1Heatlh : MonoBehaviour
{
    public int Health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Health -= 1;
            if (Health < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
