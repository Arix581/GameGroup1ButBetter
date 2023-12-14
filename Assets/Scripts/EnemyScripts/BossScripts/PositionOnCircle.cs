using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOnCircle : MonoBehaviour
{
    public float degree;
    public bool alwaysThere = true;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(Mathf.Sin(degree), Mathf.Cos(degree), 0);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (alwaysThere)
        {
            transform.localPosition = pos;
        }
    }
}
