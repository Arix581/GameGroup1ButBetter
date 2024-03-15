using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashPoints : MonoBehaviour
{
    public int mashPointCounter;
    public GameObject[] mashPoints;
    // Start is called before the first frame update
    void Start()
    {
        Mash();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mash()
    {
        mashPoints = GameObject.FindGameObjectsWithTag("MashPoint");
        mashPointCounter = Random.Range(0, mashPoints.Length);
        gameObject.transform.SetParent(mashPoints[mashPointCounter].transform);
    }
}
