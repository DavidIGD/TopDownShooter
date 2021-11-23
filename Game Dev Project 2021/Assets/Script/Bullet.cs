using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)//bullets will play an exploision animation when they collide with something
    {
        GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}
