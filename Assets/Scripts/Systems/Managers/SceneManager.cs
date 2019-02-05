using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Managers{
	[DefaultExecutionOrder(-10)]
	public static class SceneManager{
		public static Scene NowScene => GetActiveScene();

		private static Scene GetActiveScene()
		{
			return (Scene)UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
		}


		public static void LoadScene(Scene next) {
			UnityEngine.SceneManagement.SceneManager.LoadScene((int)next);
		}
	}
}