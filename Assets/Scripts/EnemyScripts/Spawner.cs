using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public float spawnDistance = 15f;

    public SpawnSession[] sessions;

    [SerializeField] private FloatObject globalTimer;

    // Start is called before the first frame update
    void Start()
    {
        globalTimer.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        globalTimer.value += Time.deltaTime;

        // New Spawning System
        for (int i = 0; i < sessions.Length; i++)
        {
            if (sessions[i].startTime <= globalTimer.value)
            {
                sessions[i].timer += Time.deltaTime;
                if (sessions[i].AttemptSpawn())
                {
                    Spawn(sessions[i]);
                }
            }
        }
    }

    public void Spawn(SpawnSession session)
    {
        int angle = UnityEngine.Random.Range(0, 359);
        Vector3 position = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f) * spawnDistance;
        position += transform.position;

        GameObject enemy = Instantiate(session.prefab, position, transform.rotation);
        EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
        enemyAI.stats = session.stats;
        enemyAI.LoadStats();
    }
}

[Serializable]
public class SpawnSession
{
    public EnemyStats stats;
    public float startTime;
    public float ramp;
    public float timer;
    public GameObject prefab;
    public float interval;
    public float maxOffset;
    public float minOffset;

    public SpawnSession()
    {
        ramp = 1f;
        maxOffset = 5f;
        minOffset = 1f;
        interval = 5f;
        timer = 0f;
    }

    public bool AttemptSpawn()
    {
        if (timer >= interval)
        {
            timer = UnityEngine.Random.Range(minOffset, maxOffset);
            return true;
        } 
        else
        {
            return false;
        }
    }
}