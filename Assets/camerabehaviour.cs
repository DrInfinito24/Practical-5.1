using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerabehaviour : MonoBehaviour

{
    public GameObject target;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = target.transform.position + offset;
        transform.position = newPos;
    }
}
