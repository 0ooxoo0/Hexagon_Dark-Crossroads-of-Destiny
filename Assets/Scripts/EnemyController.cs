using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Components")]
    public CharacterComtroller characterController;
    public Transform Target;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float stopDistance = 1f;
    public float startDistance = 3f;
    public float rotationSmoothing = 0.2f;

    private Vector2 smoothedDirection;
    private Vector2 previousDirection;
    private bool isChasing = false;

    private float Clock = 1;

    public PointsWalk PointsWalk;

    public bool Jak;

    public void Start()
    {
        if (Target == null && GameObject.FindWithTag("Player"))
        {
            Target = GameObject.FindWithTag("Player").transform;
        }
        previousDirection = Vector2.zero;
    }

    void FixedUpdate()
    {
        if (Target == null) return;
        Clock -= Time.deltaTime;


        Vector2 direction = (Vector2)Target.position - (Vector2)transform.position;
        float distance = direction.magnitude;

        // Сглаживание направления
        smoothedDirection = Vector2.Lerp(previousDirection, direction.normalized,
            rotationSmoothing * Time.fixedDeltaTime * 50f);
        previousDirection = smoothedDirection;

        if (distance <= stopDistance)
        {
            if (Clock <= 0)
            {
                Clock = 1;
                //if(Target.GetComponent<PlayerController>() != null)
                //Target.GetComponent<PlayerController>().TakeDammage();
            }
        }

        // Логика преследования с гистерезисом
        if (isChasing)
        {
            if (distance <= stopDistance)
            {
                if(PointsWalk!=null)
                    PointsWalk.PointNext();

                isChasing = false;
                characterController.Move(smoothedDirection, 0);
            }
            else
            {
                characterController.Move(smoothedDirection, moveSpeed * Mathf.Clamp01(distance / stopDistance));
            }
        }
        else
        {
            if (distance >= startDistance)
            {
                isChasing = true;
                characterController.Move(smoothedDirection, moveSpeed * Mathf.Clamp01(distance / stopDistance));
            }
            else
            {
                characterController.Move(smoothedDirection, 0);
            }
        }
    }
}