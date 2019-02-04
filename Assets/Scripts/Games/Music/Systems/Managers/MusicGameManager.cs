using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Music.Systems.Managers{
	public class MusicGameManager : MonoBehaviour{
		public bool IsEnd { get; private set; }

		public void Transition(){
			IsEnd = true;
		}
	}
}