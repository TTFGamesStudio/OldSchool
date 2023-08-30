using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Vector2 xLock;

    public Vector2 yLock;

    public float xRot;

    public float yRot;

    public float lookSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        xRot += (-input.y) * lookSpeed * Time.deltaTime;
        yRot += input.x * lookSpeed * Time.deltaTime;
        xRot = Mathf.Clamp(xRot, xLock.x, xLock.y);
        yRot = Mathf.Clamp(yRot, yLock.x, yLock.y);
        
        transform.rotation = Quaternion.Euler(xRot,yRot,0);
    }
}
