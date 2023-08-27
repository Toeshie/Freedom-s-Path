using System.Collections;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class ReloadScene : MonoBehaviour
    {
        private Coroutine gettingCaughtSafetyDelayCoroutine = null;
        private Movement playerReference = null;
        private Vector3 respawnPosition;
        private CinemachineVirtualCamera mainVirtualCamera;
        [SerializeField] private float safetyTime = 1f;
        [SerializeField] private GameObject gettingCaughtBalloon;
        [SerializeField] private GameObject warningSign;
        private bool beenCaught = false;
        [SerializeField] private AudioSource playerEntersLightRangeSource = null;
        [SerializeField] private AudioClip playerEntersLightRangeClip = null;
        [SerializeField] private AudioClip playerGettingCaught = null;
        private void Awake()
        {
            playerReference = FindObjectOfType<Movement>();
            mainVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GettingCaught();
                playerEntersLightRangeSource.PlayOneShot(playerEntersLightRangeClip);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (gettingCaughtSafetyDelayCoroutine != null)
                {
                    StopCoroutine(gettingCaughtSafetyDelayCoroutine);
                    gettingCaughtSafetyDelayCoroutine = null;
                    warningSign.SetActive(false);
                }
            }
        }

        private void GettingCaught()
        {
            gettingCaughtSafetyDelayCoroutine = StartCoroutine(SafetyDelay());
            
            if (!beenCaught)
            {
                warningSign.SetActive(true);
            }
        }
        
        private void OnGettingCaughtActions()
        {
            playerEntersLightRangeSource.PlayOneShot(playerGettingCaught);
            gettingCaughtBalloon.SetActive(true);
            playerReference.SetCanMove(false);
            respawnPosition = CheckpointManager.GetRespawnPosition(); 
            warningSign.SetActive(false);
        }

        private void RespawningAtCheckPoint()
        {
            beenCaught = false;
            playerReference.SetCanMove(true);
            playerReference.transform.position = respawnPosition;
            mainVirtualCamera.ForceCameraPosition(respawnPosition, quaternion.identity);  
        }

        private IEnumerator SafetyDelay()
        {
            yield return new WaitForSeconds(safetyTime);
            StartCoroutine(GameOver());
        }

        private IEnumerator GameOver()
        {
            OnGettingCaughtActions();
            beenCaught = true;
            
            yield return new WaitForSeconds(3.5f);
            
            gettingCaughtBalloon.SetActive(false);
            
            if (respawnPosition != Vector3.zero)
            {
                RespawningAtCheckPoint();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
