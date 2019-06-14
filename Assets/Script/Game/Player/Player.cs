using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Prefab to spawn bullet when shooting
    public GameObject projectilePrefab;
    //Movement in units (Force to apply)
    public float movementSpeed = 10f;
    //Rotation in Degrees (Per Second)
    public float rotationSpeed = 360f;
    //Reference for rigid body
    private Rigidbody2D rigid;

    void Shoot()
    {
        //Spawn a projectile at position and rotation of the player
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        //Get Rigidbody2D from projectile
        Projectile bullet = projectile.GetComponent<Projectile>();
        bullet.Fire(transform.up);


    }

    // Use this for initialization
    void Start()
    {
        //Get reference from rigidbody
        rigid = GetComponent<Rigidbody2D>();


    }
    //Control is a custom made function to handle movement + rotation
    void Control()
    {
        //if player hits spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Shoot a projectile
            Shoot();

        }
        //if the up key is pressed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //add a force up
            rigid.AddForce(transform.up * movementSpeed);

        }
        //if the down is pressed
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //add a force down
            rigid.AddForce(-transform.up * movementSpeed);

        }
        //if the left key is pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rotate counter-clockwise per second
            rigid.rotation += rotationSpeed * Time.deltaTime;
        }

        //if rotate the right key is pressed
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rotate clockwise per second
            rigid.rotation -= rotationSpeed * Time.deltaTime;

        }

    }


    // Update is called once per frame
    void Update()
    {
        Control();

    }
}
