using UnityEngine;

/// <summary>
/// This script attaches to the 'Background' object and moves it up if it goes below the viewport border.
/// This script is used to create the effect of infinite movement.
/// </summary>

public class RepeatingBackground : MonoBehaviour
{
    [Tooltip("Vertical size of the sprite in world space. Attach a BoxCollider2D to get the exact size.")]
    public float verticalSize;
    
    private Vector3 originalPosition;

    private void Start()
    {
        // Store the original position of the background
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position.y < -verticalSize)
        {
            ResetBackgroundPosition();
        }
    }

    private void ResetBackgroundPosition()
    {
        Vector3 resetOffset = new Vector3(0, verticalSize * 2f, 0);
        transform.position = originalPosition + resetOffset;
    }
}
