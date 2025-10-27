using UnityEngine;
using Fusion;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class DiscordMod : MonoBehaviour
{
    public static DiscordMod Instance;
    private Dictionary<PlayerRef, NetworkObject> playersDic = new Dictionary<PlayerRef, NetworkObject>();
    private string TEST = "🍆";

    void Awake() => Instance = this;

    public bool TryGetPlayah(PlayerRef playerRef, out NetworkObject netObj)
    {
        if (playersDic.ContainsKey(playerRef))
        {
            netObj = playersDic[playerRef];
            return true;
        }
        else
        {
            netObj = null;
            return false;
        }
    }

    public bool TryAddPlayah(PlayerRef playerRef, NetworkObject netObj)
    {
        if (playersDic.ContainsKey(playerRef))
        {
            playersDic[playerRef] = netObj;
            return true;
        } 
        else
        {
            playersDic.Add(playerRef, netObj);
            return false;
        }
    }

    public void MandaALVPlayer(PlayerRef playerRef)
    {
        if (playersDic.ContainsKey(playerRef))
        {
            playersDic.Remove(playerRef);
        }
    }



    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            foreach (var player in playersDic)
            {
                Debug.Log("Player: " + player.Key + " is at " + player.Value.transform.position);
            }
        }
    }
}
