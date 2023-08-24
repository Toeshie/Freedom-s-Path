using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteSwap : MonoBehaviour
{
    [SerializeField] private Sprite controllerSprite;
    [SerializeField] private Sprite keyboardSprite;

    private SpriteRenderer graffitiSpriteRenderer;

    private void Awake()
    {
        graffitiSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        bool controllerInputDetected = false;
        bool keyboardInputDetected = false;

        foreach (var device in InputSystem.devices)
        {
            if (device is Keyboard)
            {
                keyboardInputDetected = true;
            }
            else if (device is Gamepad)
            {
                controllerInputDetected = true;
            }
        }

        if (controllerInputDetected)
        {
            graffitiSpriteRenderer.sprite = controllerSprite;
        }
        else if (keyboardInputDetected)
        {
            graffitiSpriteRenderer.sprite = keyboardSprite;
        }
    }
}