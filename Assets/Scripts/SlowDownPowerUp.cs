using UnityEngine;

public class SlowDownPowerUp : MonoBehaviour
{
    public float slowDownDuration = 1f;
    public float slowDownFactor = 0.5f;
    public float despawnTime = 5f;

    private void Start()
    {
        // Start the despawn timer
        Invoke("Despawn", despawnTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            DemoBall ball = other.GetComponent<DemoBall>();
            if (ball != null)
            {
                Paddle lastPaddleHit = ball.GetLastPaddleHit();
                if (lastPaddleHit != null)
                {
                    //Slow down the opposite paddle
                    Paddle oppositePaddle = FindOppositePaddle(lastPaddleHit.isRightPaddle);
                    if (oppositePaddle != null)
                    {
                        oppositePaddle.ApplySpeedModifier(slowDownFactor, slowDownDuration);
                        Debug.Log($"Applying slow-down to opposite paddle. Modifier: {slowDownFactor}");
                    }

                    Destroy(gameObject);
                }
            }
        }
    }

    private Paddle FindOppositePaddle(bool isRightPaddle)
    {
        Paddle[] paddles = FindObjectsOfType<Paddle>();
        foreach (Paddle paddle in paddles)
        {
            if (paddle.isRightPaddle != isRightPaddle)
            {
                return paddle;
            }
        }
        return null;
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }
}