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
    private int winScore = 11;
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
            UpdateScoreColor(leftScore, leftScoreText);
            Debug.Log($"Left player scored! Score is now: Left {leftScore} - Right {rightScore}");
            CheckWinCondition("Left");
        }
        else
        {
            rightScore++;
            rightScoreText.text = rightScore.ToString();
            UpdateScoreColor(rightScore, rightScoreText);
            Debug.Log($"Right player scored! Score is now: Left {leftScore} - Right {rightScore}");
            CheckWinCondition("Right");
        }
    }

    private void UpdateScoreColor(int score, TMP_Text scoreText)
    {
        if (score >= 0 && score <= 4)
        {
            scoreText.color = Color.white;
        }
        else if (score >= 5 && score <= 8)
        {
            scoreText.color = Color.green;
        }
        else if (score >= 9 && score <= 11)
        {
            scoreText.color = Color.red;
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