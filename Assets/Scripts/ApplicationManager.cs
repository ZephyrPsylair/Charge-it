using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void LoadScene(int sceneId)
    {
        Resume();
        SceneManager.LoadScene(sceneId);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
