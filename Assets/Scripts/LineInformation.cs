using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineInformation : MonoBehaviour
{
    public GameObject startObject;
    public GameObject endObject;


    private void Update()
    {
        if (startObject == null || endObject == null)
        {
            Destroy(gameObject);
        }
        else
        {
            //Update line positions when nodes are dragged
        GetComponentInParent<LineRenderer>().SetPosition(0, startObject.transform.position);
        GetComponentInParent<LineRenderer>().SetPosition(1, endObject.transform.position);
        }
    }
}
