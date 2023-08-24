using UnityEngine;

    public class CheckpointManager : MonoBehaviour
    {
        public static CheckpointManager Instance { get; private set; } = null;
        private Vector3 respawnPosition;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public static void SetRespawnPosition(Vector3 position)
        {
            Instance.respawnPosition = position;
        }

        public static Vector3 GetRespawnPosition()
        {
            return Instance.respawnPosition;
        }

        public static void ResetCheckPointPosition()
        {
            Instance.respawnPosition = Vector3.zero;
        }
    }
