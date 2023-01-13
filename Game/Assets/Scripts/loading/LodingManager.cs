using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LodingManager : MonoBehaviour
{   
    [SerializeField]private bool isLoding = false;
    [SerializeField] private string cena_morte;
    public GameObject prefab;

    private GameObject loading;
    public bool IsLoding
    {
        get { return isLoding; }
        set { isLoding = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isLoding){
            StartCoroutine(Loading());
        }
    }

    IEnumerator Loading(){
        isLoding = false;
        if(GameObject.Find("Loading") == null){
            loading =  Instantiate(prefab);
            loading.name = "Loading";
        }
        //recuperar o animator do filhdo do filho
        Animator anim = loading.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        //cena so carrega quando a animação terminar
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(cena_morte, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        //espera a animação terminar
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        //ativa a cena
        asyncLoad.allowSceneActivation = true;
    }
}
