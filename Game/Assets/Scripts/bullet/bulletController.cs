using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    private Rigidbody2D _rBody;
    [SerializeField] private float speed = 100.0f;
    
    private void Awake() {
        _rBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        AddStartingForce();
    }

    void AddStartingForce(){
        float x = Random.value < 0.5 ? -1.0f : 1.0f;
        float y = Random.Range(-0.9f, 0.9f);
        _rBody.AddForce(new Vector2(x,y) * speed);
    }
}
