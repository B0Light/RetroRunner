using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerCharacter;
    private CharacterController _characterController;
    private Animator _animator;
    
    public Vector3 movementInputDirection;
    private Vector3 _smoothMoveDirection;
    private Vector3 _smoothMoveVelocity;
    
    private float _currentSpeed;
    private float _currentMovementSmoothnes;
    
    [Header("Variables")]
    [Range(0.01f, 0.5f)] 
    [SerializeField] private float movementSmoothnes = 0.1f;
    [Range(3f, 10f)]
    [SerializeField] private float jumpforce = 10f;
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float gravity = 3f;
    
    [Header("Keys")]
    [SerializeField] private KeyCode runKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        SetSpd();
        Movement();
        Jump();
        Gravity();
        Vector3 moveThisDirection = new Vector3(_smoothMoveDirection.x, movementInputDirection.y, 0);

        if (movementInputDirection.x > 0)
        {
            playerCharacter.transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (movementInputDirection.x < 0)
        {
            playerCharacter.transform.rotation = Quaternion.Euler(0,180,0);
        }
        _characterController.Move(moveThisDirection * Time.deltaTime);
        SetAni();
    }
    
    private void SetSpd()
    {
        if (Input.GetKey(runKey))
        {
            _currentSpeed = runSpeed;
            _currentMovementSmoothnes = movementSmoothnes * 3f;
        }
        else
        {
            _currentSpeed = walkSpeed;
            _currentMovementSmoothnes = movementSmoothnes;
        }
    }

    private void Movement()
    {
        _smoothMoveDirection = Vector3.SmoothDamp(_smoothMoveDirection, movementInputDirection, ref _smoothMoveVelocity, _currentMovementSmoothnes);
        float yStore = movementInputDirection.y;
        movementInputDirection = (transform.right * Input.GetAxisRaw("Horizontal"));
        movementInputDirection = movementInputDirection.normalized * _currentSpeed;
        movementInputDirection.y = yStore;
        
    }

    private void Jump()
    {
        //Jump
        if (_characterController.isGrounded)
        {
            movementInputDirection.y = -1f;

            if (Input.GetKeyDown(jumpKey))
            {
                movementInputDirection.y = jumpforce;
            }
            else
            {
                movementInputDirection.y = movementInputDirection.y + (Physics.gravity.y * gravity * Time.deltaTime);
            }
        }
    }

    private void Gravity()
    {
        //Gravity
        movementInputDirection.y = movementInputDirection.y + (Physics.gravity.y * gravity * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            _animator.SetBool("isLadder", true);
            movementInputDirection.y = Input.GetAxisRaw("Vertical") * 3;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            _animator.SetBool("isLadder", false);
        }
    }

    private void SetAni()
    {
        if (movementInputDirection.x != 0)
        {
            _animator.SetBool("isWalk",true);
        }
        else
        {
            _animator.SetBool("isWalk",false);
        }
    }
}
