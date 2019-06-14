using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Travel speed of the projectile
    public float speed = 10f;
    //Reference to rigidbody
    private Rigidbody2D rigid;

    private void Awake()
    {
        //Get reference to Rigidbody
        rigid = GetComponent<Rigidbody2D>();

    }
    //Fire this bullet in a given direction (using defined speed)
    public void Fire(Vector3 direction)
    {
        //Add force in the given direction by speed
        rigid.AddForce(direction * speed, ForceMode2D.Impulse);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Try getting ASteroid script from collision
        Asteroid asteroid = collision.GetComponent<Asteroid>();
        //If it is an Asteroid
        if (asteroid)
        {
            //Destroy the Asteroid
            asteroid.Destroy();
            //Destroy the projectile
            Destroy(gameObject);

        }
    }
            
        
    

}
