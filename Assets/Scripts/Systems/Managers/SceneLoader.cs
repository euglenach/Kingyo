using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Managers{
	public class SceneLoader : SingletonMonoBehaviour<SceneLoader>{
		public void Load(int nextScene){
			SceneManager.LoadScene((Scene)Enum.ToObject(typeof(Scene),nextScene));
		}

		public void Exit(){
			Application.Quit();
		}
	}
}