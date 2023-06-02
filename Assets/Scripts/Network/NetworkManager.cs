using System.Threading.Tasks;
using Fusion;
using UnityEngine;

namespace Network
{
    public class NetworkManager : MonoBehaviour
    {
    
        // -- Variables --
        // Singleton (Para Nacho: Esto es una forma de hacer una "variable global" para un singleton que solo pueda settearse desde dentro de la clase)
        private static NetworkManager Instance { get; set; }
        private NetworkRunner SessionRunner { get; set; }
    
        [SerializeField] private GameObject networkRunnerPrefab;

        private NetworkMangerEvents _networkMangerEvents;


        private void Awake()
        {
            // -- Singleton de NetworkManager --
            if (Instance != null && Instance != this)
            {
                Debug.LogError("There is more than one NetworkManager in the scene!");
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        
            _networkMangerEvents = GetComponent<NetworkMangerEvents>();
        }
        
        async void Start()
        {
            CreateRunner();
        
            await Connect();
        }

        private void CreateRunner()
        {
            // Instanciar el runner y asignarle los callbacks
            SessionRunner = Instantiate(networkRunnerPrefab, this.transform).GetComponent<NetworkRunner>();
            SessionRunner.AddCallbacks(_networkMangerEvents);
        
        
            // - Asignar variables -
            
            // PlayerSpawner
            PlayerSpawner playerSpawner = SessionRunner.GetComponent<PlayerSpawner>();
            _networkMangerEvents.playerSpawner = playerSpawner;
        
            // PlayerSpawner -> Spawnpoints
            GameObject[] spawnPointsGameObject = GameObject.FindGameObjectsWithTag("SpawnPoint");
            Transform[] spawnPointsTransforms = new Transform[spawnPointsGameObject.Length];
            for (int i = 0; i < spawnPointsGameObject.Length; i++)
            {
                spawnPointsTransforms[i] = spawnPointsGameObject[i].transform;
            }
            playerSpawner.spawnPoints = spawnPointsTransforms;
        
            // PlayerInput
            PlayerInput playerInput = this.GetComponentInChildren<PlayerInput>();
            _networkMangerEvents.playerInput = playerInput;
        }
        private async Task Connect()
        {
            // Crear sala
            var args = new StartGameArgs
            {
                GameMode = GameMode.Shared,
                SessionName = "TestSession",
                SceneManager = GetComponent<NetworkSceneManagerDefault>()
            };
        
            // Iniciar sala
            var result = await SessionRunner.StartGame(args);
        
            // Verificar sala
            if (result.Ok)
            {
                Debug.Log("Connected to server");
            }
            else
            {
                Debug.Log("Failed to connect to server");
                Debug.Log(result.ErrorMessage);
            }
        }
    }
}
