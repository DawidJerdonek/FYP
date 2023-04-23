using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NodeMover : MonoBehaviour
{
    private Camera camera;
    private float cameraDistanceZ;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        cameraDistanceZ = camera.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void Update()
    {
        cameraDistanceZ = camera.WorldToScreenPoint(transform.position).z;
    }

    private void OnMouseDrag()
    {
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDistanceZ);
        Vector3 worldPos = camera.ScreenToWorldPoint(screenPos);
        transform.position = worldPos;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    //private void OnMouseOver()
    //{
    //    //if (Input.GetMouseButtonDown(1))
    //    //{
    //       // Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDistanceZ);
    //       // Vector3 worldPos = camera.ScreenToWorldPoint(screenPos);
    //        //transform.position = worldPos;
    //    //}
    //}

}
