using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleAttacks : MonoBehaviour
{
    public GameObject fire;
    public float rotationSpeed = 36;
    public float slamHeight = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Turtle Pope attack (do nothing) (morallity attack?) (dies) Dialog?
        // Then ressurect
        // Demon mode
        // Sqirtle spin - done
        // Slams
    }

    public void SpawnPrefab(GameObject prefab)
    {
        Instantiate(prefab);
    }

    public void FireSpin()
    {
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y + Time.deltaTime * rotationSpeed, transform.rotation.z);
        fire.SetActive(true);
    }

    public void SlamPrep()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        transform.SetPositionAndRotation(new Vector3(player.transform.position.x, slamHeight, player.transform.position.z), transform.rotation);
    }
}
