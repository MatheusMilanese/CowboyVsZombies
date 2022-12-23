using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    private Rigidbody2D player;
    
    [SerializeField] private float speed = 5;
    // Start is called before the first frame update
    
    private void Start() {
        player = GetComponent<Rigidbody2D>();      
    }

    
    
    private void FixedUpdate() 
    {
        wasd();
    }
    private void wasd(){
        float pos_x = Input.GetAxisRaw("Horizontal");
        float pos_y = Input.GetAxisRaw("Vertical");

        Vector3 position = new Vector3(pos_x,pos_y,0);
        if ((pos_x != 0 ) && (pos_y != 0))
        {
            player.velocity = (position * speed)/1.5f;
        } else {
            player.velocity = (position * speed);

        }
    }
}
