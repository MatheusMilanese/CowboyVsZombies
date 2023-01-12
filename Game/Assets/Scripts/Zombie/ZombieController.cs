using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // the speed at which to follow

    private Transform _target; // the object to follow
    private GameController _gameController;

    private void Awake() {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _gameController = GameObject.FindObjectOfType<GameController>();
    }  


    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Bullet"){
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            _gameController.amountZombieKills++;
        }
    }
}
