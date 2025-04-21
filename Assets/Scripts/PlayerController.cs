using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    public CharacterComtroller characterController;

    [Header("Joystick Pack")]
    public Joystick screenJoystick;

    [Header("Input System")]
    public InputActionReference movementAction;

    [Header("Settings")]
    public float moveSpeed = 5f;

    private Vector2 inputVector = Vector2.zero;
    private Vector2 lastMovement;

    private SpriteRenderer spriteRenderer;

    public GameObject PlayerGovoritPanel;

    private void Awake()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        movementAction.action.Enable();
    }

    private void OnEnable()
    {
        movementAction.action.performed += OnMovementPerformed;
        movementAction.action.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        movementAction.action.performed -= OnMovementPerformed;
        movementAction.action.canceled -= OnMovementCancelled;
    }

    void Update()
    {
        Vector2 finalInput = GetCombinedInput();
        MoveCharacter(finalInput);
    }

    Vector2 GetCombinedInput()
    {
        if (screenJoystick.Direction != Vector2.zero)
        {
            return screenJoystick.Direction;
        }
        return inputVector;
    }

    void MoveCharacter(Vector2 movement)
    {
        //  вантование ввода и сохранение направлени€

        if (movement==Vector2.zero)
            characterController.Move(movement, 0);
        else
            characterController.Move(movement, moveSpeed);

    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext context)
    {
        inputVector = Vector2.zero;
    }

    public void TakeDammage()
    {
        StartCoroutine(Dammage());
    }

    IEnumerator Dammage()
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = true;

        yield return null;
    }
}