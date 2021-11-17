using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        playerRigidbody.velocity = new Vector2(dirX * 5f, playerRigidbody.velocity.y);
        float dirY = Input.GetAxisRaw("Vertical");
        playerRigidbody.velocity = new Vector2(dirY * 5f, playerRigidbody.velocity.y);
    }
}
