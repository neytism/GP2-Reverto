using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerStats _playerStats;
    private float _moveSpeed;

    [SerializeField] private Rigidbody2D _rb;
    private Vector2 _moveDirection;

    private void OnEnable()
    {
        WeaponController.StartShooting += SetWalkingSpeed;
        WeaponController.WeaponReload += SetRunningSpeed;
        PlayerShoot.stopShoot += SetRunningSpeed;
    }

    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
        _moveSpeed = _playerStats.RunningSpeed;
    }

    void Update()
    {
       MovementInput();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed);
    }

    private void MovementInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector2(moveX, moveY).normalized;
    }

    public void SetWalkingSpeed()
    {
        _moveSpeed = _playerStats.WalkingSpeed;
    }
    
    public void SetRunningSpeed()
    {
        _moveSpeed = _playerStats.RunningSpeed;
    }


    
}
