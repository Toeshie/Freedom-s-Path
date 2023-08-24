
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;


public class Movement : MonoBehaviour
{
    private bool canMove = true;
    [SerializeField] private Rigidbody2D playerRigidBody2D;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;

    [SerializeField] private List<Sprite> nSprites;
    [SerializeField] private List<Sprite> sSprites;
    [SerializeField] private List<Sprite> eSprites;
    [SerializeField] private List<Sprite> neSprites;
    [SerializeField] private List<Sprite> seDownSprites;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float frameRate;

    [SerializeField]private AudioSource walkingAudioSource = null;

    [SerializeField] private AudioClip[] playerWalking;

   

    private float idleTime;

    private Vector2 direction;

    private void FixedUpdate()
    {
        if (canMove)
        {
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            playerRigidBody2D.velocity = direction * movementSpeed;
            SpriteSelector();
            if (direction != Vector2.zero && !walkingAudioSource.isPlaying)
            {
                int randomIndex = UnityEngine.Random.Range(0, playerWalking.Length);
                walkingAudioSource.clip = playerWalking[randomIndex];
                StartCoroutine(StepSoundTimer());
            }
        }
        
        if(!canMove)
        {
            playerRigidBody2D.velocity = new Vector2(0,0);
        }
        FlipSprite();
    }


    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }

    private void FlipSprite()
    {
        if (!playerSpriteRenderer.flipX && direction.x < 0)
        {
            playerSpriteRenderer.flipX = true;
        }
        else if (playerSpriteRenderer.flipX && direction.x > 0)
        {
            playerSpriteRenderer.flipX = false;
        }
    }

    private List<Sprite> SetSprite()
    {
        List<Sprite> selectedSprites = null;

        if (direction.y > 0)
        {
            if (Mathf.Abs(direction.x) > 0)
            {
                selectedSprites = neSprites;
            }
            else
            {
                selectedSprites = nSprites;
            }

        }else if (direction.y < 0)
        {
            if (Mathf.Abs(direction.x) >0)
            {
                selectedSprites = seDownSprites;
            }
            else
            {
                selectedSprites = sSprites;
            }
            
        }else if (Mathf.Abs(direction.x) >0)
        {
            selectedSprites = eSprites;
        }
        return selectedSprites;
    }


    private void SpriteSelector()
    {
        List<Sprite> directionSprites = SetSprite();

        if (directionSprites != null)
        {
            float playTime = Time.time - idleTime;
            int frame = (int)((playTime * frameRate) % directionSprites.Count);
            playerSpriteRenderer.sprite = directionSprites[frame];
        }
        else
        {
            idleTime = Time.time;
        }
    }

    private IEnumerator StepSoundTimer()
    {
        yield return new WaitForSeconds(0.17f);
        walkingAudioSource.Play();
    }
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /* 
    private Rigidbody2D playerRb;
    private Vector2 movementInput;
    private Vector2 smoothVectorInput;
    private Vector2 movementInputSmoothVelocity;
    [SerializeField] private float movementSpeed = 3;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            smoothVectorInput = Vector2.SmoothDamp(smoothVectorInput, movementInput, ref movementInputSmoothVelocity, 0.1f);
            playerRb.velocity = smoothVectorInput * movementSpeed; 
        }
        else
        {
            playerRb.velocity = new Vector2(0,0);
            movementInput = new Vector2(0, 0);
        }
        
    }

    private void OnMove(InputValue inputValue)
    {
        if (canMove)
        {
            movementInput = inputValue.Get<Vector2>(); 
        }
    }+*/
}