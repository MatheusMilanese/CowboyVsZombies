using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D player;
    private bool _isMoving;

    [SerializeField] private float speed = 5;
    

    public bool isMoving {
        get { return _isMoving; }
    }
    
    private void Start() {
        player = GetComponent<Rigidbody2D>();      
    }
    
    private void FixedUpdate() 
    {
        OnMove();
    }
    private void OnMove(){
        float pos_x = Input.GetAxisRaw("Horizontal");
        float pos_y = Input.GetAxisRaw("Vertical");

        if(pos_x != 0 || pos_y != 0) _isMoving = true;
        else _isMoving = false;

        Vector3 position = new Vector3(pos_x,pos_y,0);
        if ((pos_x != 0 ) && (pos_y != 0))
        {
            player.velocity = (position * speed)/1.5f;
        } else {
            player.velocity = (position * speed);
        }
    }
}
