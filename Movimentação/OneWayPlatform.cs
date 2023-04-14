using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public PlatformEffector2D effector;
    public float waitTime = 0.1f;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            effector.rotationalOffset = 180f;
            StartCoroutine(ResetPlatform());
        }
    }

    IEnumerator ResetPlatform()
    {
        yield return new WaitForSeconds(waitTime);
        effector.rotationalOffset = 0f;
    }
}