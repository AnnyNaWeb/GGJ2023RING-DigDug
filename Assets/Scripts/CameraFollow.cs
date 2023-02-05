using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera cam;
    // public Transform target;
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    bool mudaCamera;
    
    public void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = true;
        mudaCamera = false;
    }

    private void FixedUpdate()
    {

        Vector3 targetPos = target.position;
        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }

    public void Update()
    {
        if (PlayerControllerBackUp.isBlocked)
        {
            cam.orthographicSize = 20;
        }
        else
        {
            cam.orthographicSize = 8;
        }
        // transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

    }
    public void ChangeCam()
    {
        cam.orthographicSize += 5 ;
        mudaCamera = false;
    }


}
