using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Games.Shooting.Sushi;

namespace Systems.Managers{
	[DefaultExecutionOrder(-10)]
	public class GameManager : SingletonMonoBehaviour<GameManager>{
		public GameState NowGame = GameState.Music;
		public int CoinCount = 0;
		public int UseCoin = 0;
		public int NoMoneyCount = 0;
		public Dictionary<SushiType, int> SushiScores = new Dictionary<SushiType, int>();

		void Start(){
			foreach (var i in Enumerable.Range(0,Enum.GetValues(typeof(SushiType)).Length)){
				SushiScores[(SushiType) i] = 0;
			}
		}

		void Update(){
			//Debug.Log(CoinCount);
			//Debug.Log(SushiScores.Values.Sum());
		}
	}
}