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
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(_target.position.x - transform.position.x, _target.position.y - transform.position.y).normalized * speed;
        }
         rotacaoBoss();

         //rodar o boss 360 graus e depois voltar para a posição inicial
         
    }

    void rotacaoBoss(){
        //ratacionar boss no eixo y
        if(gameObject.GetComponent<Rigidbody2D>().velocity.x > 0){
            transform.eulerAngles = new Vector2(0, 0);
        }else if(gameObject.GetComponent<Rigidbody2D>().velocity.x < 0){
            transform.eulerAngles = new Vector2(0, 180);
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
