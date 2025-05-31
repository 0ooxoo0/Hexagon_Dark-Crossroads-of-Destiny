using UnityEngine;

public class CharacterComtroller : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    public Animator anim;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    [Range(0, 1)] public float movementSmoothing = 0.1f;

    private Vector2 inputVector;
    private Vector2 velocitySmoothing;

    public void AnimRotation(float x, float y, float speed)
    {

        anim.SetFloat("x", x);
        anim.SetFloat("y", y);
        anim.SetFloat("Speed", speed);
    }

    public void Move(Vector2 movement, float moveSpeed)
    {


        Vector2 quantized = QuantizeTo8Directions(movement);
        if (quantized == Vector2.zero)
        {
            anim.SetFloat("Speed", 0);
            return;
        }
        // Применение скорости
        Vector2 targetVelocity = quantized * moveSpeed;
        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocitySmoothing, movementSmoothing);

        // Обновляем анимации
        AnimRotation(
        quantized.x,
        quantized.y,
        moveSpeed
    );
    }

    Vector2 QuantizeTo8Directions(Vector2 input)
    {
        if (input.magnitude < 0.1f)
            return Vector2.zero;

        // Базовые направления для 2D
        float horizontal = Mathf.Abs(input.x) > 0.5f ? Mathf.Sign(input.x) : 0;
        float vertical = Mathf.Abs(input.y) > 0.5f ? Mathf.Sign(input.y) : 0;

        // Диагонали через комбинацию осей
        return new Vector2(horizontal, vertical).normalized;
    }
}
