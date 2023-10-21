using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private Health _health;
    
    [SerializeField] private Vector3 _moveDirection;

    [SerializeField] private float moveDir = -1;

    [SerializeField] private float currentSpeed = 3f;
    
    [Header("Variables")]
    [Range(3f, 10f)]
    [SerializeField] private float gravity = 8f;
    [Range(1f, 5f)] 
    [SerializeField] private float moveRange = 3f;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _health = GetComponent<Health>();
    }

    void Update()
    {
        Movement();
        Gravity();
        Vector3 moveThisDirection = new Vector3(_moveDirection.x,  _moveDirection.y, 0);
       
        _characterController.Move(moveThisDirection * Time.deltaTime);
    }

    private void Movement()
    {
        if (_health.isDead)
        {
            _moveDirection = Vector3.zero;
            return;
        }
        _moveDirection = (transform.right * moveDir);
        _moveDirection = _moveDirection.normalized * currentSpeed;
        StartCoroutine(EnemyTurn());
    }

    private void Gravity()
    {
        //Gravity
        _moveDirection.y = _moveDirection.y + (Physics.gravity.y * gravity * Time.deltaTime);
    }
    
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(moveRange);

        if(moveDir > 0)
            moveDir = -1;
        if (moveDir < 0)
            moveDir = 1;

    }
}
