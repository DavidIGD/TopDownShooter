using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    Vector2 movement;
    Vector2 mousePos;
    public Rigidbody2D playerRigidbody;
    public BoxCollider2D playerCollider;
    public Camera cam1;
    public int PlayerHealth = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //gets the imputs required to move the player
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam1.ScreenToWorldPoint(Input.mousePosition); //gets the position of the mouse in the game world
    }

    private void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + movement * speed * Time.fixedDeltaTime); //moves the player

        Vector2 lookDir = mousePos - playerRigidbody.position; //uses both the player and mouse position to 
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; //calculates the angle between the mouse and player using the Mathf.Atan2 function which uses vectors to find the angle from the origin also converts the answer from radians to degrees and takes away 90 degrees otherwise the charatcer would be facing the wrong direction
        playerRigidbody.rotation = angle; //rotates the player to face the mouse
    }
    private void OnCollisionEnter2D(Collision2D collision)//aliens damage player and if health drops below 1 the scene is reset
    {
        if(collision.gameObject.tag == "Alien")
        {
            PlayerHealth -= 1;
            if(PlayerHealth < 1)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
