using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float maxPaddleSpeed = 4f;
    public float paddleForce = 1f;
    public bool isRightPaddle = false;

    private float currentSpeedModifier = 1f;
    private Vector3 originalScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BoxCollider c = GetComponent<BoxCollider>();
        float max = c.bounds.max.z;
        float min = c.bounds.min.z;
        Debug.Log($"max: {max}, min: {min}");

        originalScale = transform.localScale;
    }

    void Update()
    {
        float movementAxis = isRightPaddle ?
            Input.GetAxis("RightPaddle") :
            Input.GetAxis("LeftPaddle");
        // Vector3 force = new Vector3(0f, 0f, 1f) * movementAxis * paddleForce;

        Transform paddleTransform = GetComponent<Transform>();
        // paddleTransform.position += new Vector3(0f, 0f, -maxPaddleSpeed * Time.deltaTime);

        Vector3 newPosition = paddleTransform.position + new Vector3(0f, 0f, movementAxis * maxPaddleSpeed * currentSpeedModifier * Time.deltaTime);
        newPosition.z = Mathf.Clamp(newPosition.z, -4.2f, 4.2f);

        paddleTransform.position = newPosition;
        // Rigidbody rbody = GetComponent<Rigidbody>();
        // rbody.AddForce(force, ForceMode.Force);
    }
    public void ApplySpeedModifier(float modifier, float duration)
    {
        StartCoroutine(ModifySpeed(modifier, duration));
    }
    private System.Collections.IEnumerator ModifySpeed(float modifier, float duration)
    {
        currentSpeedModifier = modifier;
        Debug.Log($"Paddle slowed down! Current speed: {maxPaddleSpeed * currentSpeedModifier}");

        yield return new WaitForSeconds(duration);

        //Return speed to paddle
        currentSpeedModifier = 1f;
        Debug.Log($"Paddle speed restored! Current speed: {maxPaddleSpeed * currentSpeedModifier}");
    }

    public void ApplyGrowEffect(Vector3 growScale, float duration)
    {
        StartCoroutine(GrowPaddle(growScale, duration));
    }

    private System.Collections.IEnumerator GrowPaddle(Vector3 growScale, float duration)
    {
        transform.localScale = Vector3.Scale(originalScale, growScale);
        Debug.Log($"Paddle grown! Current scale: {transform.localScale}");

        yield return new WaitForSeconds(duration);

        //Restore to the orginal paddlee scale
        transform.localScale = originalScale;
        Debug.Log($"Paddle scale restored! Current scale: {transform.localScale}");
    }
}
