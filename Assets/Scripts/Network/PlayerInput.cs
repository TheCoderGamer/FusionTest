using Fusion;
using UnityEngine;

namespace Network
{
    public class PlayerInput : MonoBehaviour
    {
        // Esto es llamado desde NetworkMangerEvents que a su vez es llamado cada tick desde PlayerMovement (FixedUpdateNetwork)
        public static void OnInput(NetworkRunner runner, NetworkInput input)
        {
            // Crea el input
            PlayerInputData inputData = new PlayerInputData();

            // Obtiene el input
            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            Vector3 position = new Vector3(direction.x, 0, direction.y);
        
            // Settea el input
            inputData.Position = position;
            
            // Envia el input al servidor
            input.Set(inputData);
        }
    }

    public struct PlayerInputData : INetworkInput
    {
        public Vector3 Position;
    }
}