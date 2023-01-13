using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // the speed at which to follow
    [SerializeField] private GameObject _BloodPrefab;

    private Transform _target; // the object to follow
    private GameController _gameController;

    private void Awake() {
        var player = GameObject.FindGameObjectWithTag("Player");
        if(player != null){
            _target = player.GetComponent<Transform>();
        }
        _gameController = GameObject.FindObjectOfType<GameController>();
    }


    void Update() {
        if(_target != null){
            transform.position = Vector3.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Bullet"){
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Instantiate(_BloodPrefab, transform.position, Quaternion.identity);
            _gameController.amountZombieKills++;
        }
    }
}
