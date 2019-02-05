using System.Collections;
using System.Linq;
using UnityEngine;
using Games.Shooting.Bullets;
using Games.Shooting.Sushi;

namespace Games.Shooting.Enemys.Attack{
	/// <summary>
	/// 全方位弾幕
	/// </summary>
	public class Danmaku1 : BaseAttack{
		private Vector2 vec;

		private int count = 0;

		public override void StartAttack(){
			IsStart = true;
			StartCoroutine(Attack());
		}

		IEnumerator Attack(){
			IsStart = true;
			while (count < 10){
				foreach (var i in Enumerable.Range(0,360).Where(n => n % 6 == 0)){
					vec.x = Mathf.Cos(Mathf.Deg2Rad * i);
					vec.y = Mathf.Sin(Mathf.Deg2Rad * i);
					GenerateBullet.Generate(SushiList.Instance.GetRandomType(),transform.position,vec,10f);
					Debug.Log("fdhsd");
				}
				count++;
				
				Debug.Log(vec);
				yield return new WaitForSeconds(1f);
			}

			if (count == 10){
				IsEnd = true;
				Debug.Log("fff");
				yield break;
			}
		}
	}
}