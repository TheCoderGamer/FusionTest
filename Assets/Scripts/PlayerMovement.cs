using Fusion;
using Network;

public class PlayerMovement : NetworkBehaviour
{
    public float speed = 5f;
    
    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();
        
        // Llama a OnInput, obtiene el input y mueve al jugador localmente
        if(GetInput<PlayerInputData>(out var input))
        {
            // Mueve al jugador localmente
            transform.Translate(input.Position * Runner.DeltaTime * speed);
        }
    }
    
}
