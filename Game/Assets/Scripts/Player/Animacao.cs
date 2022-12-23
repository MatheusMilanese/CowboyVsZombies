using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacao : MonoBehaviour
{

    [SerializeField] private Animator play_anim;
    [SerializeField] private Rigidbody2D play_fisic;

    private string _direction;
    public string direction
    {
        get => _direction;
        set => _direction = value;
    }
    private int anim_int;
    private float vertical,horizontal,z;

    private float play_velocit;
    // Start is called before the first frame update
    void Start()
    {
        play_anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        play_fisic = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        play_fisic = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        direction = "+Y";
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Debug Horizontal");
        vertical = Input.GetAxisRaw("Debug Vertical");
        play_velocit =  play_fisic.velocity.magnitude;
        setarAnim();
        animationPlayer();
    }
    private void animationPlayer(){
        switch (anim_int)
        {
            case 0 :
                play_anim.SetInteger("Animation",0);
                break;
            case 1 :
                play_anim.SetInteger("Animation",1);
                break;
            case 2 :
                play_anim.SetInteger("Animation",2);
                break;
            case 3 :
                play_anim.SetInteger("Animation",3);
                break;
            default:
                play_anim.SetInteger("Animation",1);
                break;
        }
    }

    private void setarAnim(){
        switch (direction)
        {
            case "+Y":
                if(play_velocit != 0){
                    anim_int = 3;
                } else {
                    anim_int = 1;
                }
                break;
            case "-Y":
                if(play_velocit != 0){
                    anim_int = 2;
                } else {
                    anim_int = 0;
                }
                break;
            case "+X":
                if(play_velocit != 0){
                    anim_int = 2;
                } else {
                    anim_int = 0;
                }
                break;
            case "-X":
                if(play_velocit != 0){
                    anim_int = 2;
                } else {
                    anim_int = 0;
                }
                break;
            default:
            anim_int = 1;
                break;
        }
    }
}
