using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailUpdater : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TrailRenderer trailRenderer;

    public void UpdateTrail()
    {
        if (trailRenderer == null) return;
        trailRenderer.time = 1.0f * gameManager.GetWire() / (gameManager.GetToGetWire() * 2.0f);
        if (trailRenderer.time == 0.0f)
        {
            trailRenderer.enabled = false;
        }
        else
        {
            trailRenderer.enabled = true;
        }
    }
}
