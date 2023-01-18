using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotaoConfig:MonoBehaviour, IPointerEnterHandler
{
    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //quando passar o mouse por cima de um objeto  canvas
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entrou");
        GetComponent<AudioSource>().Play();
    }
    
}
