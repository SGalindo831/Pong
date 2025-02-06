using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text leftScoreText;
    public TMP_Text rightScoreText;
    public TMP_Text gameOverText;

    private int leftScore = 0;
    private int rightScore = 0;
    private int winScore = 2;
    private bool gameOver = false;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    public void ScorePoint(bool isRightGoal)
    {
        if (gameOver) return;

        if (isRightGoal)
        {
            leftScore++;
            leftScoreText.text = leftScore.ToString();
            Debug.Log($"Left player scored! Score is now: Left {leftScore} - Right {rightScore}");
            CheckWinCondition("Left");
        }
        else
        {
            rightScore++;
            rightScoreText.text = rightScore.ToString();
            Debug.Log($"Right player scored! Score is now: Left {leftScore} - Right {rightScore}");
            CheckWinCondition("Right");
        }
    }

    private void CheckWinCondition(string side)
    {
        if ((side == "Left" && leftScore >= winScore) || (side == "Right" && rightScore >= winScore))
        {
            gameOver = true;
            gameOverText.text = $"Game Over, {side} Paddle Wins!";
            gameOverText.gameObject.SetActive(true);
            Debug.Log($"Game Over! {side} Paddle Wins with a final score of: Left {leftScore} - Right {rightScore}");
        }
    }

    public int[] GetScores()
    {
        return new int[] { leftScore, rightScore };
    }
}