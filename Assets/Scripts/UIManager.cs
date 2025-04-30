using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    [Header("Sliders")]
    [SerializeField] private Slider wireSlider;
    [SerializeField] private Slider voltSlider;
    [Header("GameOver")]
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject leftRightGuideText;
    [SerializeField] private GameObject swipeUpGuideText;

    private const string crashed = "Crashed!";
    private const string overcharged = "Cable Over Charged!";
    private const string pinCut = "Cable Pin Was Cut!";

    public void UpdateWireSlider()
    {
        wireSlider.value = 1.0f * gameManager.GetWire() / gameManager.GetToGetWire();
    }

    public void UpdateVoltSlider()
    {
        voltSlider.value = 1.0f * gameManager.GetVolt() / gameManager.GetToGetVolt();
    }

    public void SetGameOverText()
    {
        if (gameManager.GetGameOverReason() == GameOverReason.crashed) gameOverText.text = crashed;
        else if (gameManager.GetGameOverReason() == GameOverReason.overCharged) gameOverText.text = overcharged;
        else if (gameManager.GetGameOverReason() == GameOverReason.pinCut) gameOverText.text = pinCut;
    }

    public void Start()
    {
        StartCoroutine(Guide());
    }

    public void Toggle(GameObject UI)
    {
        UI.SetActive(!UI.activeSelf);
    }

    IEnumerator Guide()
    {   
        swipeUpGuideText.SetActive(false);
        leftRightGuideText.SetActive(true);

        yield return new WaitForSeconds(2f);

        leftRightGuideText.SetActive(false);
        swipeUpGuideText.SetActive(true);

        yield return new WaitForSeconds(2f);

        swipeUpGuideText.SetActive(false);

        yield return null;

    }
}