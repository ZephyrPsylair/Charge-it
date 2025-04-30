using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum GameOverReason { crashed, overCharged, pinCut };

public class GameManager : MonoBehaviour
{
    [Header("Volt and Wire")]

    [SerializeField] private int minWire;
    [SerializeField] private int maxWire;
    [SerializeField] private int minVolt;
    [SerializeField] private int maxVolt;
    private int toGetWire;
    private int toGetVolt;
    private int wire = 0;
    private int volt = 0;

    [Header("Game Over")]

    [SerializeField] private UnityEvent gameOver;
    [SerializeField] private UnityEvent win;
    private GameOverReason gameOverReason;

    void Awake()
    {
        toGetWire = Random.Range(minWire, maxWire);
        toGetVolt = Random.Range(minVolt, maxVolt);
    }

    public void AddWire()
    {
        if (wire == toGetWire) return;
        wire++;
        checkWin();
    }
    public void RemoveWire()
    {
        if (wire == 0)
        {
            gameOverReason = GameOverReason.pinCut;
            gameOver.Invoke();
            return;
        }
        wire--;
    }

    public void AddVolt()
    {
        if (volt == toGetVolt)
        {
            gameOverReason = GameOverReason.overCharged;
            gameOver.Invoke();
            return;
        }
        volt++;
        checkWin();
    }

    public void RemoveVolt()
    {
        if (volt == 0) return;
        volt--;
    }

    bool checkWin()
    {
        if(volt == toGetVolt && wire == toGetWire)
        {
            win.Invoke();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Crashed()
    {
        gameOverReason = GameOverReason.crashed;
        gameOver.Invoke();
    }

    public int GetVolt()
    {
        return volt;
    }

    public int GetToGetVolt()
    {
        return toGetVolt;
    }

    public int GetWire()
    {
        return wire;
    }

    public int GetToGetWire()
    {
        return toGetWire;
    }

    public GameOverReason GetGameOverReason()
    {
        return gameOverReason;
    }

    public void Win()
    {
        win.Invoke();
    }
}
