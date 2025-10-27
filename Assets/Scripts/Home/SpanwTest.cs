using UnityEngine;
using Fusion;

public class SpanwTest : NetworkBehaviour
{
    public override void Spawned()
    {

        if (HasInputAuthority)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            RPC_SpawnPlayer(Object, Object.InputAuthority);

        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    void Start()
    {

    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        if (HasInputAuthority)
        {
            RPC_DespawnPlayer(Object.InputAuthority);
        }
        base.Despawned(runner, hasState);
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void RPC_SpawnPlayer(NetworkObject player, PlayerRef playerRef)
    {
        PlayerManager.singleton.RegisterPlayer(playerRef, player);
    }
    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void RPC_DespawnPlayer(PlayerRef playerRef)
    {
        PlayerManager.singleton.RemovePlayer(playerRef);
    }
}
