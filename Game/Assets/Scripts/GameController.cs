using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text _textZombieKill;
    private int _amountZombieKills = 0;

    public int amountZombieKills {
        get { return _amountZombieKills; }
        set { _amountZombieKills = value; }
    }

    // Update is called once per frame
    void Update()
    {
        _textZombieKill.text = "X " + _amountZombieKills.ToString();
    }
}
