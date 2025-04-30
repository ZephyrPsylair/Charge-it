using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform[] lanes;
    [SerializeField] int toPool;
    [SerializeField] float spawnDistanceZ;
    [SerializeField] float distanceToNotSpawn;

    [SerializeField] private GameObject volt;
    [SerializeField] private GameObject negativeVolt;
    [SerializeField] private GameObject wire;
    [SerializeField] private GameObject bottle;
    [SerializeField] private GameObject scissor;

    private GameObject[] volts;
    private GameObject[] negativeVolts;
    private GameObject[] wires;
    private GameObject[] bottles;
    private GameObject[] scissors;

    float lastSpawnZ;

    void Start()
    {
        volts = new GameObject[toPool];
        negativeVolts = new GameObject[toPool];
        wires = new GameObject[toPool];
        bottles = new GameObject[toPool];
        scissors = new GameObject[toPool];

        for (int i = 0; i < volts.Length; i++)
        {
            volts[i] = Instantiate(volt, transform);
            volts[i].SetActive(false);
        }
        for (int i = 0; i < volts.Length; i++)
        {
            negativeVolts[i] = Instantiate(negativeVolt, transform);
            negativeVolts[i].SetActive(false);
        }
        for (int i = 0; i < volts.Length; i++)
        {
            wires[i] = Instantiate(wire, transform);
            wires[i].SetActive(false);
        }
        for (int i = 0; i < volts.Length; i++)
        {
            bottles[i] = Instantiate(bottle, transform);
            bottles[i].SetActive(false);
        }
        for (int i = 0; i < volts.Length; i++)
        {
            scissors[i] = Instantiate(scissor, transform);
            scissors[i].SetActive(false);
        }
    }

    void Update()
    {
        if (lastSpawnZ - playerTransform.position.z > distanceToNotSpawn) return;
        for (int i = 0; i < lanes.Length; i++)
        {
            Vector3 spawnPosition = new Vector3(lanes[i].position.x, transform.position.y, lastSpawnZ + spawnDistanceZ);
            int randomObjectIndex = Random.Range(0, 5);
            GameObject randomObject = GetPooledObject(randomObjectIndex);
            if (randomObject == null) continue;
            randomObject.transform.position = spawnPosition;
            randomObject.SetActive(true);
        }
        lastSpawnZ += spawnDistanceZ;
    }

    GameObject GetPooledObject(int index)
    {
        if (index == 0)
        {
            foreach (GameObject _volt in volts)
            {
                if (!_volt.activeSelf)
                    return _volt;
            }
        }
        else if (index == 1)
        {
            foreach (GameObject _negativeVolt in negativeVolts)
            {
                if (!_negativeVolt.activeSelf)
                    return _negativeVolt;
            }
        }
        else if (index == 2)
        {
            foreach (GameObject _wire in wires)
            {
                if (!_wire.activeSelf)
                    return _wire;
            }
        }
        else if (index == 3)
        {
            foreach (GameObject _bottle in bottles)
            {
                if (!_bottle.activeSelf)
                    return _bottle;
            }
        }
        else if (index == 4)
        {
            foreach (GameObject _scissor in scissors)
            {
                if (!_scissor.activeSelf)
                    return _scissor;
            }
        }
        return null;
    }

}
