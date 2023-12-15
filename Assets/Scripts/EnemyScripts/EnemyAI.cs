using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 4.5f;
    public bool ableToMove = true;
    public float damage = 1f;
    public bool canDash;

    [Space]
    public EnemyStats stats;

    [Space]
    public float dashWindup = 2.5f;
    public float dashSpeed = 9f;
    public float dashDuration = 2f;
    public float dashWinddown = 2f;
    public Vector3 target;
    public float dashTimer;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);
        if (player != null && canDash)
        {
            dashTimer += Time.deltaTime;
            target = DashControl(target);
        }
        else if (player != null)
        {
            Vector3 target = player.transform.position;
            transform.LookAt(target);
            Vector3 movement = Vector3.MoveTowards(transform.position, target, (ableToMove ? speed : 0) * Time.deltaTime);
            transform.position = movement;
        }
    }

    public void DamagePlayer()
    {
        player.GetComponent<PlayerHealthScript>().TakeDamage(damage);
    }

    public void LoadStats()
    {
        speed = stats.speed;
        damage = stats.damage;
        canDash = stats.canDash;
    }

    public Vector3 DashControl(Vector3 target)
    {
        if (Timer.TimerBetween(dashTimer, 0f, dashWindup)) 
        {
            Target();
        }
        else if (Timer.TimerBetween(dashTimer, dashWindup, dashWindup + dashDuration))
        {
            Dash(dashSpeed);
        }
        else if (dashTimer >= dashWindup + dashDuration + dashWinddown)
        {
            dashTimer = 0;
        }
        return target;
    }

    public void Target()
    {
        target = player.transform.position;
    }

    public void Dash(float speed)
    {
        transform.LookAt(target);
        Vector3 movement = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.position = movement;
    }

    public void MovementOn(bool status)
    {
        ableToMove = status;
    }
}

static class Timer
{
    static public bool TimerBetween(float timer, float start, float end)
    {
        return timer >= start && timer <= end;
    }
}