using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBorder : MonoBehaviour
{
    //Out of bounds padding destroy object
    public float padding = 10f;
    //Border for destroy object padding gizmos
    public Color debugColor = Color.red;

    void OnDrawGizmos()
    {
        Bounds camBounds = Camera.main.GetBounds(padding);
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);

    }

    //Update is called once per frame
    void Update()
    {
        //get camera bounds with padding
        Bounds camBounds = Camera.main.GetBounds(padding);
        //If position is out of bounds
        if(!camBounds.Contains(transform.position))
        {
            //Destroy it
            Destroy(gameObject);


        }
    }
}
