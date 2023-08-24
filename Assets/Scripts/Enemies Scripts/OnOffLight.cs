using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OnOffLight : MonoBehaviour
    {
        [SerializeField] private float interval = 5f;

        private Light2D myLight;
        private Collider2D myCollider;

        [SerializeField] private AudioSource lightOnOffSource = null;
        [SerializeField] private AudioClip lightOnOffClip = null;

        private void Awake()
        {
            myLight = GetComponent<Light2D>();
            myCollider = GetComponent<Collider2D>();
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            StartCoroutine(ToggleLightRoutine());
        }

        private IEnumerator ToggleLightRoutine()
        {
            while (true)
            {
                TurnOnLight();
                yield return new WaitForSeconds(interval);
            
                TurnOffLight();
                yield return new WaitForSeconds(interval);
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private void TurnOffLight()
        {
            lightOnOffSource.PlayOneShot(lightOnOffClip);
            myLight.enabled = false;
            myCollider.enabled = false;
        }

        private void TurnOnLight()
        {
            lightOnOffSource.PlayOneShot(lightOnOffClip);
            myLight.enabled = true;
            myCollider.enabled = true;
        }
    }

