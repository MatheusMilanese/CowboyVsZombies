using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GunController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private AnimationControler _animController;
    [SerializeField] private Transform[] _bulletPoints;
    [SerializeField] private float shotForce;
    [SerializeField] private bulletController _bulletPrefab;

    private AudioClip _shotSound;
    private float _forceX, _forceY;
    private int _posPoint;
    float rotation = 0.0f;

    private void Start() {
        rotation = 0.0f;
        _posPoint = 0;
        _forceX = shotForce;
        _forceY = 0;
        

    }

    void Update()
    {
        OnRotate();
        OnShot();
        if(_animController.isBack){
            _spriteRenderer.sortingOrder = 9;
        }
        else {
            _spriteRenderer.sortingOrder = 11;
        }
    }

    void OnShot(){
        if(Input.GetKeyDown(KeyCode.Space)){
            bulletController newBullet = Instantiate(_bulletPrefab, _bulletPoints[_posPoint].position, Quaternion.identity);
            newBullet.AddStartingForce(_forceX, _forceY);
            GetComponent<AudioSource>().Play();
        }
    }

    void OnRotate(){
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (Input.GetKey(KeyCode.UpArrow)){
                rotation = 135.0f;
                _posPoint = 3;
                _forceX = -shotForce/1.5f;
                _forceY = shotForce/1.5f;
            }
            else if (Input.GetKey(KeyCode.DownArrow)){
                rotation = -135.0f;
                _posPoint = 5;
                _forceX = -shotForce/1.5f;
                _forceY = -shotForce/1.5f;
            }
            else{
                rotation = 180.0f;
                _posPoint = 4;
                _forceX = -shotForce;
                _forceY = 0;
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow)) {
            if (Input.GetKey(KeyCode.UpArrow)){
                rotation = 45.0f;
                _posPoint = 1;
                _forceX = shotForce/1.5f;
                _forceY = shotForce/1.5f;
            }
            else if (Input.GetKey(KeyCode.DownArrow)){
                rotation = -45.0f;
                _posPoint = 7;
                _forceX = shotForce/1.5f;
                _forceY = -shotForce/1.5f;
            }
            else{
                rotation = 0.0f;
                _posPoint = 0;
                _forceX = shotForce;
                _forceY = 0;
            }
        }

        else if (Input.GetKey(KeyCode.UpArrow)){
            rotation = 90.0f;
            _posPoint = 2;
            _forceX = 0;
            _forceY = shotForce;
        }

        else if (Input.GetKey(KeyCode.DownArrow)){
            rotation = -90.0f;
            _posPoint = 6;
            _forceX = 0;
            _forceY = -shotForce;
        }

        // Rotate the GameObject towards the specified rotation
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
