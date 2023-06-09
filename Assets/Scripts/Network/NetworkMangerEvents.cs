using System;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;

namespace Network
{
    public class NetworkMangerEvents : MonoBehaviour, INetworkRunnerCallbacks
    {
    
        public PlayerSpawner playerSpawner;
        public PlayerInput playerInput;
    
    
        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            playerSpawner.PlayerJoined(runner, player);
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
        }

        // Esto es llamado cada tick desde PlayerMovement (FixedUpdateNetwork)
        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            PlayerInput.OnInput(runner, input);
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
            Debug.Log("Runner Shutdown");
        }

        // ReSharper disable once Unity.IncorrectMethodSignature
        public void OnConnectedToServer(NetworkRunner runner)
        {
        }

        public void OnDisconnectedFromServer(NetworkRunner runner)
        {
        
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
        
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
        
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
        
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
        
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
        
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
        {
        
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
        
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
        
        }
    }
}
