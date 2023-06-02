using Fusion;
using UnityEngine;

namespace Network
{
    public class PlayerSpawner : MonoBehaviour
    {
    
        public Transform[] spawnPoints;
        [SerializeField] private NetworkPrefabRef playerPrefab;

        public void PlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            if (player == runner.LocalPlayer)
            {
                // Spawn al jugador local
                Debug.Log("Local player joined");
                Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                runner.Spawn(playerPrefab, spawnPoint, Quaternion.identity, player);
            }
            else
            {
                Debug.Log("Remote player joined");
            }
        }
    }
}
