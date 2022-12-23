using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arma2_script : MonoBehaviour
{
    // Start is called before the first frame update   
    [SerializeField] private GameObject bala;
    [SerializeField] private Transform local_disparo;
    [SerializeField] private float tiro_speed = 300;
 
    private float vertical,horizontal,z;
    private float x_tiro ,y_tiro;

    private Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        z = transform.rotation.z;
        y_tiro = tiro_speed;
        InvokeRepeating("tiro",1f,1f);
    }

    private void Update() {
        setas();
        
        horizontal = Input.GetAxisRaw("Debug Horizontal");
        vertical = Input.GetAxisRaw("Debug Vertical");
    }

    // Update is called once per frame
    private void FixedUpdate() {
        transform.eulerAngles = new Vector3(0,0,z);   
    }

    private void setas(){

        if((horizontal < 0) && (vertical > 0)){
            z = 45;
            y_tiro =  1;
            x_tiro = -1;
        } else 
        
        if((horizontal < 0) && (vertical < 0)){
            z = 125;
            y_tiro =  -1;
            x_tiro = -1;
        } else  
        if((horizontal > 0) && (vertical < 0)){
            z = 225;
            y_tiro =  -1;
            x_tiro =  1;
        } else 
        if((horizontal > 0) && (vertical > 0)){
            z = 315;
            y_tiro =  1;
            x_tiro =  1;
        } else {
            if(vertical > 0){
            z = 0;
            y_tiro =  1;
            x_tiro =  0;
        } 

        if(vertical < 0){
            z = 180;
            y_tiro =  -1;
            x_tiro =  0;
        } 

        if(horizontal < 0){
            z = 90;
            y_tiro =  0;
            x_tiro =  -1;
        } 

        if(horizontal > 0){
            z = 270;
            x_tiro =  1;
            y_tiro = 0;

        } 
        }


        


    }

    private void tiro(){
        
        tiro_duplo();
              
        
    }

    private void tiro_duplo(){
            GameObject tiro_disparado = (GameObject) Instantiate(bala,local_disparo.position, Quaternion.identity);
            tiro_disparado.GetComponent<Rigidbody2D>().AddForce(new Vector3(x_tiro*tiro_speed,y_tiro*tiro_speed,0));
           
    }
}
