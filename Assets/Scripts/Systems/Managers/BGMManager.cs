using System.Collections;
using System.Collections.Generic;
using Games.Shooting.Players;
using UnityEditor;
using UnityEngine;

namespace Systems.Managers{
	[DefaultExecutionOrder(-1)]
	public class BGMManager : SingletonMonoBehaviour<BGMManager>{
		[SerializeField] private AudioClip[] audioClips;
		public AudioSource AudioSource { get; private set; }
		private float timer = -3;
		public bool isPlay => timer < nowMusicLength;
		private float nowMusicLength = 0;
		
		private void Start(){
			AudioSource = GetComponent<AudioSource>();
		}

		private void Update(){
			timer += Time.deltaTime;
		}

		public void StartMusic(){
			AudioSource.Stop();
			timer = 0;
			switch (SceneManager.NowScene){
				case Scene.Title:
					PlayMusic(0);
					AudioSource.loop = true;
					break;
				case Scene.Game:
					if (GameManager.Instance.NowGame == GameState.Music){
						PlayMusic(1);
						AudioSource.loop = false;
					}
					if (GameManager.Instance.NowGame == GameState.Shooting){
						PlayMusic(2);
						AudioSource.loop = true;
					}
					break;
				case Scene.Result:
					PlayMusic(3);
					AudioSource.loop = true;
					break;
				
			}
		}

		private void PlayMusic(int clipIndex){
			var temp = audioClips[clipIndex];
			if (temp == null){
				nowMusicLength = 0;
				return;
			}

			nowMusicLength = temp.length;
			AudioSource.clip = temp;
			AudioSource.Play();
		}
	}
}