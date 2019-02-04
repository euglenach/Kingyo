using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Shooting.Sushi;

namespace Systems.Managers{
	public class GameManager : SingletonMonoBehaviour<GameManager>{
		private GameState nowGame = GameState.Music;
		public int CoinCount;
		public Dictionary<SushiType, int> SushiScores = new Dictionary<SushiType, int>();
		
	}
}