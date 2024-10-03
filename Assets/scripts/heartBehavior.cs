using UnityEngine;

public class heartBehavior : MonoBehaviour
{
    public float amplitude = 1.0f; // Amplitude of the side-to-side movement
    public float frequency = 1.0f; // Frequency of the side-to-side movement
    public float riseSpeed = 1.0f; // Speed at which the heart moves up
    public float fadeStartHeight = 5.0f; // Height at which the heart starts fading
    public float fadeDuration = 2.0f; // Duration in seconds over which the heart fades out

    private Vector3 startPosition;
    private float startTime; // Individual start time for movement
    private float fadeStartTime;
    private SpriteRenderer spriteRenderer;
    private bool isFading = false;

    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        startTime = Time.time; // Capture the start time when the heart is created
        if (spriteRenderer == null)
        {
            Debug.LogError("HeartBehavior requires a SpriteRenderer to function properly.");
        }
    }

    void Update()
    {
        HandleMovement();
        CheckForFadeStart();
        if (isFading)
        {
            HandleFading();
        }
    }

    private void HandleMovement()
    {
        // Use startTime to calculate the x position independently for each heart
        float x = amplitude * Mathf.Sin((Time.time - startTime) * frequency);
        float y = riseSpeed * Time.deltaTime;
        transform.position = new Vector3(startPosition.x + x, transform.position.y + y, startPosition.z);
    }

    private void CheckForFadeStart()
    {
        if (transform.position.y >= startPosition.y + fadeStartHeight && !isFading)
        {
            isFading = true;
            fadeStartTime = Time.time; // Set the time when fading starts
        }
    }

    private void HandleFading()
    {
        if (isFading)
        {
            float t = (Time.time - fadeStartTime) / fadeDuration;
            spriteRenderer.color = Color.Lerp(new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1), new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0), t);

            // Destroy the heart once it's completely faded
            if (t >= 1)
            {
                Destroy(gameObject);
            }
        }
    }
}