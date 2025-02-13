using UnityEngine;

public class DemoBall : MonoBehaviour
{
    public float initialSpeed = 5f;
    public float speedIncrease = 1.2f;
    private Rigidbody rb;
    private float currentSpeed;
    // public AudioSource paddleHitSound;
    public AudioSource slowHitSound;
    public AudioSource fastHitSound;
    private Paddle lastPaddleHit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = initialSpeed;
        StartBallMovement();
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        currentSpeed = initialSpeed;
        StartBallMovement();
    }

    void StartBallMovement()
    {
        float direction = Random.Range(0, 2) == 0 ? -1f : 1f;
        Vector3 initialVelocity = new Vector3(direction, 0f, Random.Range(-0.5f, 0.5f)).normalized;
        rb.linearVelocity = initialVelocity * currentSpeed;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Paddle>() != null)
        {
            if (currentSpeed < 10f)
            {
                slowHitSound.Play();
            }
            else
            {
                fastHitSound.Play();
            }
            //If ball hit on paddle, play sound
            //paddleHitSound.Play();

            //Track what paddle last hit the ball
            lastPaddleHit = other.gameObject.GetComponent<Paddle>();

            // Increase the current speed and see which paddle it is
            currentSpeed *= speedIncrease;
            Paddle paddle = other.gameObject.GetComponent<Paddle>();

            // Set the main direction based on which paddle was hit
            float xDirection = paddle.isRightPaddle ? -1f : 1f;

            // Randomness for ball respawn
            float zDirection = Random.Range(-0.5f, 0.5f);

            Vector3 newDirection = new Vector3(xDirection, 0f, zDirection).normalized;
            rb.linearVelocity = newDirection * currentSpeed;
        }
    }

    public Paddle GetLastPaddleHit()
    {
        return lastPaddleHit;
    }
}