using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampAI : MonoBehaviour
{
    [Header("This contains all attacks of the Clamper boss")]
    public GameObject clampHolder;
    public float clampScale = 1f;

    //public float clampAttackCooldown = 10f;
    //public float lockOnTime = 1f;
    //public bool isClamping;

    private GameObject player;
    private EnemyAI eai;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        eai = gameObject.GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClampsSetActive(bool state)
    {
        clampHolder.SetActive(state);
    }

    public void ClampAttack()
    {
        Vector3 target = eai.target;

        clampHolder.transform.position = target;
        clampHolder.transform.localScale = new Vector3(
            clampHolder.transform.localScale.x - Time.deltaTime, 
            clampHolder.transform.localScale.y - Time.deltaTime,
            clampHolder.transform.localScale.z);
    }

    public void SetClamps(float size)
    {
        clampHolder.transform.localScale = new Vector3(size, size, size);
    }
}
