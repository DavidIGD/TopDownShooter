using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollision : MonoBehaviour
{
    GameObject boxesEnemy;
    // Start is called before the first frame update
    void Start()
    {
        boxesEnemy = GameObject.Find("BoxLmao");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(boxesEnemy);
            Destroy(gameObject);
        }
    }
}
