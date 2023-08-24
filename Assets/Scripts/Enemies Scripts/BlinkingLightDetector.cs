using UnityEngine;

    public class BlinkingLightDetector : MonoBehaviour
    {
   
        [SerializeField] private GameObject blinkingLight;
        private bool isActive = false;
       
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player") || isActive) return;
            isActive = true;
            blinkingLight.SetActive(true);
        }
    }

