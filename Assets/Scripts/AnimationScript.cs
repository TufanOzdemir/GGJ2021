using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    private Animator _animator;
    bool secondAttack = false;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
       

        var attackState = _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");

        if (attackState != true && Input.GetAxisRaw("Fire1") != 0)
        {
            _animator.SetTrigger("Attack");
        }

        if (attackState == true && Input.GetAxisRaw("Fire1") != 0 && secondAttack == false)
        {
            secondAttack = true;
        }

        //if (attackState && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && secondAttack == true)
        //{
        //    _animator.Play("New State");
        //    secondAttack = false;
        //}

        _animator.SetFloat("Blend", Input.GetAxis("Vertical") * Container.Instance.PlayerStats.MoveSpeed);
    }
}
