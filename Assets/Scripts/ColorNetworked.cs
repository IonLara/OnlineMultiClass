using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorNetworked : NetworkBehaviour
{

    private MeshRenderer mr;
    [Networked, OnChangedRenderAttribute(nameof(ShainBrightLaikADaimond))]
    public Color color { get; set; }

    private void Start()
    {
        gameObject.TryGetComponent(out mr);
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            color = Random.ColorHSV();
        }

        if (Object.HasInputAuthority && Mouse.current.rightButton.wasPressedThisFrame)
        {
            RPC_SayOWO("OWO");
        }
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void RPC_SayOWO(string msg, RpcInfo info = default)
    {
        Debug.Log(info.Source + " Says: " + msg);
    }

    private void ShainBrightLaikADaimond()
    {
        mr.material.color = color;
    }
}
