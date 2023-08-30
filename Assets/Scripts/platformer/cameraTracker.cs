using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTracker : MonoBehaviour
{
    public Transform objectToTrack;

    public bool trackX;

    public bool trackY;

    public bool trackZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (trackX)
        {
            pos.x = objectToTrack.position.x;
        }

        if (trackY)
        {
            pos.y = objectToTrack.position.y;
        }

        if (trackZ)
        {
            pos.z = objectToTrack.position.z;
        }

        transform.position = pos;
    }
}
