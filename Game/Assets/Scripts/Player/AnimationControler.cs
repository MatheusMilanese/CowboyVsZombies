using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    
    [SerializeField] private Animator _animator;
    private PlayerMove _playerMove;
    private bool _isBack;

    public bool isBack {
        get { return _isBack; }
    }

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
            _isBack = true;
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            _isBack = false;
        }
    }

    void UpdateAnimation(){
        if(_playerMove.isMoving){
            _animator.SetInteger("tipo", (_isBack ? 2 : 3));
        }
        else{
            _animator.SetInteger("tipo", (_isBack ? 1 : 0));
        }
    }
}
