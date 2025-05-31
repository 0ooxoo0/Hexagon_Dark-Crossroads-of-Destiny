using Unity.VisualScripting;
using UnityEngine;

public class OlenController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] CharacterComtroller _characterController;
    [SerializeField] Transform Target;

    public float moveSpeed = 5f;

    public float rotationSmoothing = 0.2f;
    private Vector2 smoothedDirection;
    private Vector2 previousDirection;
    void Start()
    {
        Run();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        anim.enabled = true;

        Vector2 direction = (Vector2)Target.position - (Vector2)transform.position;
        float distance = direction.magnitude;

        // Сглаживание направления
        smoothedDirection = Vector2.Lerp(previousDirection, direction.normalized,
            rotationSmoothing * Time.fixedDeltaTime * 50f);
        previousDirection = smoothedDirection;

        _characterController.Move(smoothedDirection, moveSpeed * Mathf.Clamp01(distance));
    }
}
