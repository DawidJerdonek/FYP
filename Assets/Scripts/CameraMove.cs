using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public int moveSpeed = 1000;
    public int zoomSpeed = 10000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            gameObject.transform.position += Vector3.forward * zoomSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            gameObject.transform.position += Vector3.back * zoomSpeed * Time.deltaTime;
        }

        //Limit X Axis
        if (gameObject.transform.position.x <= -4200)
        {
            gameObject.transform.position = new Vector3(-4197, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.x >= 4200)
        {
            gameObject.transform.position = new Vector3(4197, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        //Limit Y Axis
        if (gameObject.transform.position.y <= -3000)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -2997, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.y >= 3000)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 2997, gameObject.transform.position.z);
        }

        //Limit Z Axis
        if (gameObject.transform.position.z <= -3999)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -3997.0f);
        }
        if (gameObject.transform.position.z >= -500)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -497.0f);
        }
    }
}
