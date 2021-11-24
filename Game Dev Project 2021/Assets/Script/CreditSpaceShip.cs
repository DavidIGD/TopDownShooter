using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSpaceShip : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Vector3 newPosition = transform.position; //gets the start position
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(100 * Time.deltaTime, 0, 0); //moves the spaceship
    }
}
