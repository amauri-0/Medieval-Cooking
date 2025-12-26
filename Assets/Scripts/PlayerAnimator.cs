using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private const string ON_INTERACT = "OnInteractCounter";

    [SerializeField] private Player player;


    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        BaseCounter.OnInteractCounter += BaseCounter_OnInteractCounter;
    }

    private void BaseCounter_OnInteractCounter(object sender, EventArgs e)
    {
        animator.SetTrigger(ON_INTERACT);
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
