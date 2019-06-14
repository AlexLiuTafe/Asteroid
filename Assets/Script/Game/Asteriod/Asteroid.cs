using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //pieces of asteroids to spawn
    public GameObject[] asteroidPieces;
    public int spawnAmount = 4;
    public float maxVelocity = 3f;

    //Spawn a random asteroid in a random direction
    void Spawn()
    {
        // Generate random index into asteroid pieces of array
        int randomIndex = Random.Range(0, asteroidPieces.Length);

        //Select random asteroid piece
        GameObject asteroidPiece = asteroidPieces[randomIndex];

        //Ask the AsteroidManager to spawn a new asteroid piece at a position
        AsteroidManager.Spawn(asteroidPiece, transform.position);

    }

    //Spawns Asteroid pieces when asteroid get destroyed
    public void Destroy()
    {
        //Destroy self
        Destroy(gameObject);
    
        //if there are assigned asteroid pieces
        if (asteroidPieces.Length>0)
        {
            //Loop through the specified spawn amount
            for (int i=0; i<spawnAmount;i++)
            {
                //Spawn an asteroid
                Spawn();

            }
        }
    }
}
