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
    public int playerHealth;
    public int maxHealth = 10;
    public HealthBar healthBar;
    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider;
    public SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); //sets the max value of the players health bar
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Alien") 
        {
            StartCoroutine(FlashColor()); //calls invinvibility method, makes game more fair
            playerHealth -= 1; //aliens damage player
            healthBar.SetHealth(playerHealth); //updates the players health bar
            if(playerHealth < 1) //restarts the level when player loses all health
            {
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if(collision.gameObject.tag == "Medkit") //when player collides with medkit it sets health to 10 and updates health bar
        {
            playerHealth = 10;
            healthBar.SetHealth(playerHealth);
        }
    }
    private IEnumerator FlashColor() //makes the player invincible for a moment when called
    {
        int temp = 0;
        triggerCollider.enabled = false; //disables damage trigger with aliens
        while(temp < numberOfFlashes)
        {
            playerSprite.color = flashColor; //changes sprite color
            yield return new WaitForSeconds(flashDuration);
            playerSprite.color = regularColor; //returns the color to normal
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        triggerCollider.enabled = true;
    }
}
