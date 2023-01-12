using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lampiao_anim : MonoBehaviour
{
    Image img_principal;
    public Sprite[] sprites;

    [SerializeField] private float anim_speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
       img_principal = GetComponent<Image>(); 
       StartCoroutine(WaitAndPrint(anim_speed,false));
    }

    IEnumerator WaitAndPrint(float waitTime, bool i)
    {
        yield return new WaitForSeconds(waitTime);
        img_principal.sprite = sprites[i ? 0 : 1];
        StartCoroutine(WaitAndPrint(anim_speed,!i));
    }
}
