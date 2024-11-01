using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Dependencies")]
    public InputActionReference MovementInput;
    public Rigidbody2D Rigidbody;
    public EntityHealth Health;

    public float MovementSpeed = 10;
    public float MovementSmoothTime = 0.3f;

    private Vector3 referenceVelocity;

    private void OnEnable()
    {
        GameContext.Instance.Player = this;
    }

    private void OnDisable()
    {
        if (GameContext.Instance.Player == this)
        {
            GameContext.Instance.Player = null;
        }
    }

    private void Update()
    {
        var targetVelocity = MovementInput.action.ReadValue<Vector2>();
        targetVelocity *= MovementSpeed;

        Rigidbody.velocity = Vector3.SmoothDamp(Rigidbody.velocity, targetVelocity, ref referenceVelocity, MovementSmoothTime);
    }
}
