using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private GameObject[] Models;
    
    int randomIndex;

    void Start()
    {
        randomIndex = Random.Range(0, Models.Length);
        Instantiate(Models[randomIndex], transform);
    }

    int GetModel()
    {
        return randomIndex;
    }
}
