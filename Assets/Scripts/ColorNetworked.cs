using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorNetworked : NetworkBehaviour
{
    [Networked, OnChangedRenderAttribute(nameof(ColorChanged))]
    public Color NetworkColor {  get; set; }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            NetworkColor = Color.red;
        }
    }

    public void ColorChanged()
    {
        Debug.Log("COLOR STUFF");
    }
}
