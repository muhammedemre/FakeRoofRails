using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveOfficer : MonoBehaviour
{
    [SerializeField] private PlayerActor playerActor;
    public bool canMove = false;
    private InputSlideOfficer inputSlideOfficer;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float forwardMoveSpeed, horizontalMoveSpeed, smoothTime, flyingMoveSpeed;

    Vector3 dampRefVector = Vector3.zero;
    
    private Transform platformBorderRight, platformBorderLeft;
    private float moveRateAmount, platformWidth;
    
    public bool flying = false;
    void Start()
    {
        inputSlideOfficer = InputManager.instance.inputSlideOfficer;
    }

    private void FixedUpdate()
    {
        FlyEffect();
        MoveForward();
        PlayerHorizontalMoveSlide();
    }

    public void MoveForward()
    {
        if (canMove && !flying)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, forwardMoveSpeed);
        }
        else if (!canMove)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, 0f);
        }
    }

    public void PlayerHorizontalMoveSlide()
    {
        moveRateAmount = inputSlideOfficer.moveRate;
        if (canMove)
        {
            HorizontalMoveWithPositioning(moveRateAmount);
        }                   
    }
    
    void HorizontalMoveWithPositioning(float moveRate) 
    {
        float newXPos = transform.position.x + (moveRate * horizontalMoveSpeed * platformWidth);
        newXPos = Mathf.Clamp(newXPos, platformBorderLeft.position.x, platformBorderRight.position.x);
        Vector3 newPos = new Vector3(newXPos, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref dampRefVector, smoothTime);
    }

    public void AssignPlatformBorders(Transform _platformBorderRight, Transform _platformBorderLeft)
    {
        platformBorderRight = _platformBorderRight;
        platformBorderLeft = _platformBorderLeft;
        float diffXBetweenBorders = platformBorderRight.position.x - platformBorderLeft.position.x;
        platformWidth = diffXBetweenBorders;
    }

    void FlyEffect()
    {
        if (flying && playerRb.velocity.z < flyingMoveSpeed)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, flyingMoveSpeed);
        }
        else if (!flying && playerRb.velocity.z >= flyingMoveSpeed)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, forwardMoveSpeed);
        }
    }
}
