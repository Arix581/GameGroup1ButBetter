using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    public float speed = 7f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toMove = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        toMove *= (speed * Time.deltaTime);
        cc.Move(toMove);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
