using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboText : MonoBehaviour
{
    IBoostManage _speedBoost;
    Text text;

    void Start()
    {
        _speedBoost = FindObjectOfType<PlayerSpeedBoost>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_speedBoost != null)
        {
            text.text = "COMBO: " + _speedBoost.GetAccumulatedMoves();
        }
    }
}
