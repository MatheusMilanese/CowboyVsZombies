using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private Rigidbody2D player;
    private bool _isMoving;

    [SerializeField] private float speed = 5;
    [SerializeField] private GameObject _bloodPrefab;

    private float _posX;
    private float _posY;
    

    public bool isMoving {
        get { return _isMoving; }
    }
    
    private void Start() {
        player = GetComponent<Rigidbody2D>();      
    }

    private void Update(){
        _posX = Input.GetAxisRaw("Horizontal");
        _posY = Input.GetAxisRaw("Vertical");
    }
    
    private void FixedUpdate() 
    {
        OnMove();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Bullet" || other.gameObject.tag == "Enemy"){
            Destroy(this.gameObject);
            Instantiate(_bloodPrefab, transform.position, Quaternion.identity);
        }
        
    }

    private void OnMove(){

        if(_posX != 0 || _posY != 0) _isMoving = true;
        else _isMoving = false;

        Vector3 position = new Vector3(_posX, _posY, 0);
        if ((_posX != 0 ) && (_posY != 0))
        {
            player.velocity = (position * speed)/1.5f;
        } else {
            player.velocity = (position * speed);
        }
    }
}
