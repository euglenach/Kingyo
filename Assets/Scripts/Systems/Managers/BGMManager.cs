using System.Collections;
using System.Collections.Generic;
using Games.Shooting.Players;
using UnityEngine;

namespace Systems.Managers{
	public class BGMManager : SingletonMonoBehaviour<BGMManager>{
		[SerializeField] private AudioClip[] audioClips;
		private AudioSource audioSource;
		
		private void Start(){
			audioSource = GetComponent<AudioSource>();
		}

		public void StartMusic(){
			audioSource.Stop();
			switch (SceneManager.NowScene){
				case Scene.Title:
					PlayMusic(0);
					break;
				case Scene.Game:
					if(GameManager.Instance.NowGame == GameState.Music)PlayMusic(1);
					if(GameManager.Instance.NowGame == GameState.Shooting)PlayMusic(2);
					break;
				case Scene.Result:
					PlayMusic(3);
					break;
				
			}
		}

		private void PlayMusic(int clipIndex){
			var temp = audioClips[clipIndex];
			if (temp == null) return;
			audioSource.clip = temp;
			audioSource.Play();
		}
	}
}