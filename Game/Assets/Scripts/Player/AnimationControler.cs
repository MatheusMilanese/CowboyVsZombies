using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    
    [SerializeField] private Animator _animator;
    private PlayerController _playerMove;

    private Rigidbody2D playRb;
    private bool _isBack;

    public bool isBack {
        get { return _isBack; }
    }

    void Start()
    {
        _playerMove = GetComponent<PlayerController>();
        playRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnInput();
        
    }

    void OnInput(){
        if(Input.GetKey(KeyCode.UpArrow)){
            _isBack = true;
        }
        else if( (Input.GetKey(KeyCode.DownArrow) || ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))){
            _isBack = false;
        } 
        
        UpdateAnimation();
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
