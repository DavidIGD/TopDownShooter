using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform player;
    [SerializeField] float threshold;


    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition); //gets the position of the mouse in relation to the game world
        Vector3 targetPos = (player.position + mousePos) / 2f; //gets the combined positions of the player and mouse to use in the math function
        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.position.x, threshold + player.position.x); 
        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.position.y, threshold + player.position.y); //calculates the position we want the camera to be at using Mathf.Clamp which calculates the position between the player and mouse where the threshold is the max distance the camera can move from the player
        this.transform.position = targetPos; //focuses the position
    }
}
