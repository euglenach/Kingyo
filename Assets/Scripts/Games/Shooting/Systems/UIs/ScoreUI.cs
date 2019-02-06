using System.Collections;
using System.Collections.Generic;
using Systems.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Games.Shooting.Systems.UIs{
	public class ScoreUI : MonoBehaviour{
		private Text scoreText;

		private void Start(){
			scoreText = GetComponent<Text>();
		}

		void Update(){
			scoreText.text = $"残りコイン {GameManager.Instance.CoinCount - GameManager.Instance.UseCoin}";
		}
	}
}