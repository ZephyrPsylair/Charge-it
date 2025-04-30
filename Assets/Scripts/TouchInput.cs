using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class TouchInput : MonoBehaviour
{
    [SerializeField] float drag = 5;
    [SerializeField] float minSwipeDistance = 0.3f;
    [SerializeField] float swipeTime = 0.3F;

    Touch touch;
    Vector2 touchStartPosition = Vector2.zero;
    Vector2 touchCurrentPosition = Vector2.zero;
    float xAxis;
    bool swipedUp;
    float touchStartTime;
    int screenHeight;
    int screenWidth;
    bool tapped;

    private void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    void Update()
    {
        if (Input.touchCount < 1)
        {
            xAxis = 0;
            swipedUp = false;
            return;
        }

        touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            touchStartPosition = touch.position;
            touchStartTime = Time.time;
        }
        touchCurrentPosition = touch.position;
        tapped = (touchStartTime + .3f >= Time.time && touch.phase == TouchPhase.Ended);
        swipedUp = ((touchCurrentPosition.y - touchStartPosition.y) / screenHeight >= minSwipeDistance && touchStartTime + swipeTime >= Time.time && touch.phase == TouchPhase.Ended);
        xAxis = ((touchCurrentPosition.x - touchStartPosition.x) / screenWidth * drag);
    }

    public float GetAxis()
    {
        return xAxis;
    }

    public bool SwipeUp()
    {
        return swipedUp;
    }

    public bool Tapped()
    {
        return tapped;
    }
}