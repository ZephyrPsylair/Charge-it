using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTranform;
    [SerializeField] Vector3 followOffset;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, followOffset + playerTranform.position, Time.deltaTime);
    }
}
