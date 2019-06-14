using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    //Singleton
    public static AsteroidManager Instance;
    void Awake()
    {
        Instance = this;
        
    }
    //array of prefab to spawn
    public GameObject[] asteroidPrefabs;
    //Max velocity an astroid can move
    public float maxVelocity = 3f;
    //rate of spawn
    public float spawnRate = 1f;
    //padding to spawn
    public float spawnPadding = 2f;

    

    
    //Spawn an asteroid at a specified position
    public static void Spawn(GameObject prefab, Vector3 position)
    {
        //randomize a rotation for asteroid
        Quaternion randomRot = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        //spawn a random asteroid at random position and default quaternion rotation
        GameObject asteroid = Instantiate(prefab, position, randomRot,Instance. transform);

        //get rigidbody for asteroid
        Rigidbody2D rigid = asteroid.GetComponent<Rigidbody2D>();

        //apply random force to rigidbody
        Vector2 randomForce = Random.insideUnitCircle * Instance.maxVelocity;
        rigid.AddForce(randomForce, ForceMode2D.Impulse);
    
    }
    
    //Spawns a random asteroid in the array at a random position
    void SpawnLoop()
    {
        //Get camera's bounds using Extension Method
        Bounds camBounds = Camera.main.GetBounds(spawnPadding);

        // Randomize a position within a circle
        Vector2 randomPos = camBounds.GetRandomPosOnBounds();

    
        //Generate random position inside sphere with spawn padding (radius)
        //Vector3 randomPos = Random.insideUnitSphere * spawnPadding;

        //Generate random index into asteroid prefabs array
        int randomIndex = Random.Range(0, asteroidPrefabs.Length);

        //Get random asteroid prefab from array using index
        GameObject randomAsteroid = asteroidPrefabs[randomIndex];

        //Spawn using random pos
        Spawn(randomAsteroid, randomPos);

        

    }
    // Use this for initialization
	void Start ()
    {
        // Invoke a function repeatedly with given rate
        InvokeRepeating("SpawnLoop", 0, spawnRate);

	}

    public Color debugColor = Color.cyan;
    void OnDrawGizmos()
    {
        Bounds camBounds = Camera.main.GetBounds(spawnPadding);
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);


    }
    
}
