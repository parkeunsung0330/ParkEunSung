using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    Transform _tr;
    // Start is called before the first frame update
    void Start()
    {
        _tr=GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _tr.Rotate(Vector3.up, 10.0f * Time.deltaTime);
    }
}