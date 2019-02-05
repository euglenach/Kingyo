using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Managers{
	[DefaultExecutionOrder(-1)]
	public class SEManager : MonoBehaviour{
		private AudioSource[] audioSources;
		
		private void Awake() {
			audioSources = GetComponentsInChildren<AudioSource>();
		}
		
		public void SoundCall(int num) {
			audioSources[num].PlayOneShot(audioSources[num].clip);
		}
	}
}