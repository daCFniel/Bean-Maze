using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public bool gameOver = false;
    private float restartDelay = 2f;
    [SerializeField]
    private GameObject finishLevelUI;
    public void EndGame ()
    {    
        if (!gameOver)
        {
            gameOver = true;
            Invoke("Restart", restartDelay);
        }

    }

    public void StartTimer()
    {
        finishLevelUI.SetActive(true);
        FindObjectOfType<FinishTimer>().timerWorking = true;
    }

    public void StopTimer()
    {
        finishLevelUI.SetActive(false);
        FindObjectOfType<FinishTimer>().timerWorking = false;
        FindObjectOfType<FinishTimer>().ResetTimer();

    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
