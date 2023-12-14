using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ComplexAttackController : MonoBehaviour
{
    [System.Serializable]
    public class Segment
    {
        public float duration;
        public float timer;
        public UnityEvent contents;

        public Segment()
        {
            duration = 2f;
        }
    }

    [System.Serializable]
    public class InBetweens
    {
        public UnityEvent contents;
    }

    [System.Serializable]
    public class Attack
    {
        public float cooldown;
        public float timer;
        public int currentIndex;
        public Segment[] segments;
        public InBetweens[] inBetweens;

        public Attack()
        {
            currentIndex = -1;
        }
    }

    public Attack[] attacks;
    public int currentAttack;
    public bool needNewAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < attacks.Length; i++)
        {
            Debug.Log("Attack (i) variable is equal to " + i, this);
            switch (attacks[i].currentIndex)
            {
                // On cooldown
                case -1:
                    Debug.Log("Attack " + i + " is on cooldown.");
                    attacks[i].timer += Time.deltaTime;
                    break;

                // Anything but on cooldown
                default:
                    Debug.Log("Entered default");
                    needNewAttack = false;

                    // Decrement segment timer
                    Segment currentSegment = attacks[i].segments[attacks[i].currentIndex]; 
                    currentSegment.timer += Time.deltaTime;

                    // Cleared Timer Debug
                    Debug.Log("Attack " + i + " is entering block " + attacks[i].currentIndex);
                    
                    // Is the current segment done?
                    if (currentSegment.timer >= currentSegment.duration)
                    {
                        // Reset the time
                        currentSegment.timer = 0f;

                        // Timer finished
                        Debug.Log("Timer Finished at line 80 ish");

                        // Increment the index and call the inbetween
                        attacks[i].inBetweens[attacks[i].currentIndex].contents.Invoke();
                        Debug.Log("<color=blue>Called the " + attacks[i].currentIndex + "th inbetween</color>");
                        attacks[i].currentIndex++;
                        Debug.Log("<color=red>CurrentIndex value is equal to " + attacks[i].currentIndex + " after the increment</color>");

                        // Wrap around when attack is done
                        if (attacks[i].currentIndex >= attacks[i].segments.Length)
                        {
                            attacks[i].currentIndex = -1;
                            attacks[i].timer = -attacks[i].cooldown;
                            needNewAttack = true;
                            break;
                        }
                    }

                    // Call the segments event
                    attacks[i].segments[attacks[i].currentIndex].contents.Invoke();
                    break;
            }
        }

        if (needNewAttack)
        {
            int chosen = ChooseAttack();
            if (chosen != -1)
            {
                needNewAttack = false;
                attacks[chosen].currentIndex = 0;
            }
        }
    }

    public int ChooseAttack()
    {
        int chosen = -1;
        float longestTime = 0f;
        for (int i = 0; i < attacks.Length; i++)
        {
            if (attacks[i].cooldown >= longestTime)
            {
                chosen = i;
                longestTime = attacks[i].cooldown;
            }
        }
        return chosen;
    }
}
