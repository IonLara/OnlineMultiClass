using UnityEngine;
using Fusion;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined, IPlayerLeft
{
    public GameObject playerPrefab;

    public int id { get; set; }
    public void PlayerJoined(PlayerRef player)
    {
        if(player == Runner.LocalPlayer)
        {
            Runner.Spawn(playerPrefab, Vector3.up, Quaternion.identity,player);

        }
    }

    public void PlayerLeft(PlayerRef player)
    {
        
    }
}
