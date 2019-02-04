using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
					break;
				case Scene.Game:
					break;
				case Scene.Result:
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