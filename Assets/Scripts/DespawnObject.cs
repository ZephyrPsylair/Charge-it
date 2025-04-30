using UnityEngine;

public class DespawnObject : MonoBehaviour
{
    Transform playerTransform;
    float distanceToDespawn = 3.2f;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (playerTransform.position.z - transform.position.z >= distanceToDespawn)
            gameObject.SetActive(false);
    }
}
