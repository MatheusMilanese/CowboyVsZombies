using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // the speed at which to follow
    [SerializeField] private float speedBuff = 0;
    [SerializeField] private GameObject _BloodPrefab;

    

    private Image _LifeBar;
 
    private Transform _target; // the object to follow
    private GameController _gameController;

    //vida do boss na UI

    private GameObject _lifeBar;

    [SerializeField] private GameObject _lifeBarPrefab;

    private GameObject _lifeBarPrefabInstance;

    

    private float _life = 5f;
    private float maxLife = 5f;

    private void Awake() {
        var player = GameObject.FindGameObjectWithTag("Player");
        if(player != null){
            _target = player.GetComponent<Transform>();
        }
        _gameController = GameObject.FindObjectOfType<GameController>();
        
        //buscar pela tag
       
    }

    void Start () {
        _lifeBarPrefabInstance = Instantiate(_lifeBarPrefab);
         _LifeBar = GameObject.FindGameObjectWithTag("BossLifeBar").GetComponent<Image>();
         if(_LifeBar == null){
            Debug.Log("LifeBar não encontrada");
        }
       
    }


    void Update() {
        
        //quando a animação de nascer acabar permitir que o boss ande
        if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Boss")){
            speedBuff = speed;
        } 

        if(_target != null){
                 transform.position = Vector3.MoveTowards(transform.position, _target.position, speedBuff * Time.deltaTime);
                 gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(_target.position.x - transform.position.x, _target.position.y - transform.position.y).normalized * speedBuff;
                 Debug.Log("Andando");
        } 
        rotacaoBoss();
        life();

        
  
    }
     //quando a animação de nascer acabar permitir que o boss ande
   


    

    void rotacaoBoss(){
        //ratacionar boss no eixo y
        
        if(gameObject.GetComponent<Rigidbody2D>().velocity.x > 0){
            transform.eulerAngles = new Vector2(0, 0);
        }else if(gameObject.GetComponent<Rigidbody2D>().velocity.x < 0){
            transform.eulerAngles = new Vector2(0, 180);
        }

            
    }

    void life(){
        //fiminuir a vida do boss que é uma imagem pelo widh
      
        var _lifeTransfomr =  _LifeBar.transform as RectTransform;
        _lifeTransfomr.sizeDelta = new Vector2((604/maxLife) * _life, _lifeTransfomr.sizeDelta.y);
        if(_life <= 0){
     

            Destroy(gameObject);
            Destroy(_lifeBarPrefabInstance);
            _gameController.amountZombieKills++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Bullet"){
            _life--;
            Destroy(other.gameObject);
            //Instantiate(_BloodPrefab, transform.position, Quaternion.identity);
            
        }
    }
}
