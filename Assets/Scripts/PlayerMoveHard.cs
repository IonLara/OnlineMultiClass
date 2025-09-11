using UnityEngine;
using Fusion;

public class PlayerMoveHard : NetworkBehaviour
{
    private CharacterController controller;
    public float speed = 2f;

    private void Awake()
    {
        gameObject.TryGetComponent(out controller);
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput<MyInput>(out var inputs) == false) { return; }

        Debug.Log("INPUT GUT");

        Vector3 vector = new Vector3();

        if (inputs.buttons.IsSet(MyButtons.Forward)) { vector.z += 1; }
        if (inputs.buttons.IsSet(MyButtons.Backward)) { vector.z -= 1; }
        if (inputs.buttons.IsSet(MyButtons.Left)) { vector.x -= 1; }
        if (inputs.buttons.IsSet(MyButtons.Right)) { vector.x += 1; }

        controller.Move(vector * speed * Runner.DeltaTime);
    }
}
