using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed = 4f;

    Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*scrollSpeed*Time.deltaTime);

        if (transform.position.x < StartPos.x -18f)
        {
            transform.position = StartPos;
        }
    }
}
