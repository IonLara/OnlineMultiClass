using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.InputSystem;

public class PlayerManager : NetworkBehaviour
{
    public static PlayerManager singleton;
    public Dictionary<PlayerRef, NetworkObject> playerList = new Dictionary<PlayerRef, NetworkObject>();

    void Awake() => singleton = this;

    public void RegisterPlayer(PlayerRef player, NetworkObject playerObject)
    {
        Debug.Log("SIGN OF LIFE!!!!");
        if (!playerList.ContainsKey(player))
        {
            Debug.Log("Registering Player: " + player.PlayerId);
            playerList.Add(player, playerObject);
        }
        else
        {
            Debug.Log("Updating Player: " + player.PlayerId);
            playerList[player] = playerObject;
        }
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void RPC_CleanPlayer(PlayerRef playerRef)
    {
        if (playerList.ContainsKey(playerRef))
        {
            RemovePlayer(playerRef);
        }
    }

    public void RemovePlayer(PlayerRef playerRef)
    {
        if (playerList.ContainsKey(playerRef))
        {
            Debug.Log("Removing Player: " + playerRef.PlayerId);
            playerList.Remove(playerRef);
        }
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            foreach (var item in playerList)
            {
                Debug.Log("Player: " + item.Key.PlayerId + " is at position: " + item.Value.transform.position);
            }
        }
    }
}
