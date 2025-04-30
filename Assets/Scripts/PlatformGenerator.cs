using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private Transform playerTranform;
    [SerializeField] private int generatePlatforms;
    [SerializeField] private Vector3 spawnOffset;

    private GameObject[] platforms;
    Vector3 lastSpawnedPosition;

    int firstPlatformIndex = 0;

    void Start()
    {
        platforms = new GameObject[generatePlatforms];

        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i] = Instantiate(platform, transform);
        }

        lastSpawnedPosition = transform.position - spawnOffset;
        for (int i = 0; i < platforms.Length; i++)
        {
            SpawnPlatform(i, lastSpawnedPosition + spawnOffset);
            platforms[i].SetActive(true);
        }
    }

    void Update()
    {
        if (firstPlatformIndex >= platforms.Length) firstPlatformIndex = 0;

        if (platforms[firstPlatformIndex].transform.position.z <= playerTranform.position.z + -spawnOffset.z * 2)
        {
            SpawnPlatform(firstPlatformIndex, lastSpawnedPosition + spawnOffset);
            firstPlatformIndex++;
        }
    }

    void SpawnPlatform(int index, Vector3 position)
    {
        platforms[index].transform.position = position;
        lastSpawnedPosition = position;
    }
}