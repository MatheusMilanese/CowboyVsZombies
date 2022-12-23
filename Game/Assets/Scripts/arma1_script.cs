using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arma1_script : MonoBehaviour
{

    [SerializeField] private GameObject bala;
    [SerializeField] private Transform local_disparo;
    [SerializeField] private float tiro_speed = 300;
 
    
    private Rigidbody2D play_fisic;

    private GunDirectControll gun_direct;
    private Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        
        play_fisic = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        gun_direct = GameObject.FindGameObjectWithTag("Player").GetComponent<GunDirectControll>();

        
        
        
        InvokeRepeating("tiro",1f,1f);
    }

    private void Update() {
       
        
        
    }

    // Update is called once per frame
    private void FixedUpdate() {
        transform.eulerAngles = new Vector3(0,0,gun_direct.z);   
    }

    

    

    private void tiro(){
        GameObject tiro_disparado = (GameObject) Instantiate(bala,local_disparo.position, Quaternion.identity);
        tiro_disparado.GetComponent<Rigidbody2D>().AddForce(new Vector3(gun_direct.x_tiro *tiro_speed,gun_direct.y_tiro *tiro_speed,0));
    }
    
}
