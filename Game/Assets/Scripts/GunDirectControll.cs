using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDirectControll : MonoBehaviour
{   
    private float vertical,horizontal;
    private float _x_tiro;

    public float x_tiro{
        get => _x_tiro;
    }

    private float _y_tiro;

    public float y_tiro{
        get => _y_tiro;
    }

    private float _z;

    public float z{
        get=> _z;
    }

     Animacao play_anim;

    
    // Start is called before the first frame update
    void Start()
    {
         
        play_anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animacao>();
        _z = transform.rotation.z;
        _y_tiro = 1;
    }

    // Update is called once per frame
    void Update()
    {
        setas();
        horizontal = Input.GetAxisRaw("Debug Horizontal");
        vertical = Input.GetAxisRaw("Debug Vertical");
    }


    private void setas(){
        // ex: y_tiro e x_tiro = um ao outro somente para manutencao de codigo
        if((horizontal < 0) && (vertical > 0)){
            _z = 45;
            _y_tiro =  1;
            _x_tiro = -1;
            play_anim.direction = "+Y";
            
        } else 
        
        if((horizontal < 0) && (vertical < 0)){
            _z = 125;
            _y_tiro =  -1;
            _x_tiro = -1;
            play_anim.direction = "-Y";
            
        } else  
        if((horizontal > 0) && (vertical < 0)){
            _z = 225;
            _y_tiro =  -1;
            _x_tiro =  1;
            play_anim.direction = "-Y";
             
        } else 
        if((horizontal > 0) && (vertical > 0)){
            _z = 315;
            _y_tiro =  1;
            _x_tiro =  1;
            play_anim.direction = "+Y";
            
        } else if(vertical > 0){
            _z = 0;
            _y_tiro =  1;
            _x_tiro =  0;
            play_anim.direction = "+Y";
        } else

        if(vertical < 0){
            _z = 180;
            _y_tiro =  -1;
            _x_tiro =  0;
            play_anim.direction = "-Y";
             
        }  else

        if(horizontal < 0){
            _z = 90;
            _y_tiro =  0;
            _x_tiro =  -1;
            play_anim.direction = "-X";

        } else

        if(horizontal > 0){
            _z = 270;
            _x_tiro =  1;
            _y_tiro = 0;
            play_anim.direction = "+X";
        } 
        


    }
}
