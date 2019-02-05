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
		public int CoinCount;
		public Dictionary<SushiType, int> SushiScores = new Dictionary<SushiType, int>();

		void Start(){
			foreach (var i in Enumerable.Range(0,Enum.GetValues(typeof(SushiType)).Length)){
				SushiScores[(SushiType) i] = 0;
			}
		}
	}
}