using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollision2 : MonoBehaviour
{
    GameObject boxesEnemy;
    // Start is called before the first frame update
    void Start()
    {
        boxesEnemy = GameObject.Find("BoxLol"); //finds the box object
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision) //destroys the boxes when player enter a room
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(boxesEnemy);
            Destroy(gameObject);
        }
    }
}
