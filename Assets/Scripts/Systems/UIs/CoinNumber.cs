﻿using System.Collections;
using System.Collections.Generic;
using Systems.Managers;
using UnityEngine;
using UnityEngine.UI;

public class CoinNumber : MonoBehaviour {

    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = GameManager.Instance.CoinCount.ToString();
	}
}
