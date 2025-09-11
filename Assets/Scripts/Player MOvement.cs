using UnityEngine;
using UnityEngine.InputSystem;
using Fusion;

public class PlayerMOvement : NetworkBehaviour
{
    private CharacterController _controller;

    public float playerSpeed = 2f;

    public InputActions inputActions;

    private void Awake()
    {
        inputActions = new InputActions();
        inputActions.Player.Enable();
        gameObject.TryGetComponent(out _controller);
    }

    public override void FixedUpdateNetwork()
    {
        InputSystem.Update();
        Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        _controller.Move(move * Runner.DeltaTime * playerSpeed);

        if(move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

    }
}
