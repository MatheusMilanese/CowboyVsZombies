using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    
    [SerializeField] private Animator _animator;
    private PlayerMove _playerMove;
    private bool isBack;

    void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        OnInput();
        UpdateAnimation();
    }

    void OnInput(){
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            isBack = true;
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            isBack = false;
        }
    }

    void UpdateAnimation(){
        if(_playerMove.isMoving){
            _animator.SetInteger("tipo", (isBack ? 2 : 3));
        }
        else{
            _animator.SetInteger("tipo", (isBack ? 1 : 0));
        }
    }
}
