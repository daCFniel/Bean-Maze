using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Text scoreText;

    private float tarePosition;

    private void Start()
    {
        tarePosition = player.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<GameController>().gameOver)
        scoreText.text = (player.position.z - tarePosition).ToString("0");
    }

    public void SetText(string newText)
    {
        scoreText.text = newText;
    }
}
