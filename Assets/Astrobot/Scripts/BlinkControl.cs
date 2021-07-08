using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkControl : MonoBehaviour
{

    public float blinkEyeRate;
    Animator animator;

    private float previousBlinkEyeRate;
    private float blinkEyeTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time > blinkEyeTime)
        {
            previousBlinkEyeRate = blinkEyeRate;
            blinkEyeTime = Time.time + blinkEyeRate;
            //set a trigger named "blink" in ur animator window and then set that trigger the arrow connectiing eyeIdle to eyeBlink               
            animator.SetTrigger("blink");
            while (previousBlinkEyeRate == blinkEyeRate)
            {
                // Random Rate from 4 secs to 10secs
                blinkEyeRate = Random.Range(3f, 6f);
            }
        }//and there u get
    }
}