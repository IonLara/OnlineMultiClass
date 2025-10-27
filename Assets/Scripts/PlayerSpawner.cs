using UnityEngine;
using Fusion;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined, IPlayerLeft
{
    public GameObject playerPrefab;
    public bool spawnLocal = true;

    public void PlayerJoined(PlayerRef player)
    {
        if (spawnLocal == true && player == Runner.LocalPlayer)
        {
            var foo = Runner.Spawn(playerPrefab, Vector3.up, Quaternion.identity, player);



        }
        if (spawnLocal == false && Runner.IsServer)
        {
            Runner.Spawn(playerPrefab, Vector3.up, Quaternion.identity, player);
        }
    }

    public void PlayerLeft(PlayerRef player)
    {
        PlayerManager.singleton.RPC_CleanPlayer(player);
    }
}
