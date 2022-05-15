using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    void OnTriggerEnter ()
    {
        gameController.StartTimer();
    }

    private void OnTriggerExit(Collider other)
    {
        gameController.StopTimer();
    }
}
