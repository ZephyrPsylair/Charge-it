using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchInput : MonoBehaviour
{
    Touch touch;

    private void Update()
    {
        if (Input.touchCount < 1)
        {
            return;
        }

        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Ended) 
        {
            
        }
    }
}
