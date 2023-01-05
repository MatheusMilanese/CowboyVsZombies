using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    private Rigidbody2D _rBody;
    
    private void Awake() {
        _rBody = GetComponent<Rigidbody2D>();
    }

    public void AddStartingForce(float forceX, float forceY){
        
        _rBody.AddForce(new Vector2(forceX, forceY));
    }
}
