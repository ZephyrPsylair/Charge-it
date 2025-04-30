using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLaunch : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] TouchInput touchInput;
    [SerializeField] float launchForce;
    [SerializeField] UnityEvent hitPort;
    [SerializeField] UnityEvent notHitPort;
    [SerializeField] bool hit;

    void Start()
    {
        
    }

    public void Update()
    {
        if (touchInput.Tapped())
        {
            Launch();
        }
    }

    // Update is called once per frame
    public void Launch()
    {
        characterController.Move(new Vector3(0, 0, launchForce * Time.deltaTime));
        StartCoroutine("EndGame");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IPhone"))
        {
            hit = true;
            hitPort.Invoke();
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(.5f);
        if (!hit) 
        {
            notHitPort.Invoke();
        }
    }
}
