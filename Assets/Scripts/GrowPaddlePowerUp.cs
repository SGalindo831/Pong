using UnityEngine;

public class GrowPaddlePowerUp : MonoBehaviour
{
    public float growDuration = 5f;
    public float despawnTime = 5f;

    //Scale multiplier for the paddle power up
    public Vector3 growScale = new Vector3(1f, 1f, 2f);

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
                    //Grow the paddle that last hit the ball
                    lastPaddleHit.ApplyGrowEffect(growScale, growDuration);
                }

                //Destroy the powerup
                Destroy(gameObject);
            }
        }
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }
}