using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isRightGoal;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DemoBall>() != null)
        {
            gameManager.ScorePoint(isRightGoal);
            other.GetComponent<DemoBall>().ResetBall();
        }
    }
}