using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Shooting.Sushi;

namespace Systems.Managers{
	public class GameManager : SingletonMonoBehaviour<GameManager>{
		private GameState nowGame;
		public int CoinCount;
		public Dictionary<SushiType, int> SushiScores = new Dictionary<SushiType, int>();
		
		void Start(){
			nowGame = GameState.Music;
		}
	}
}