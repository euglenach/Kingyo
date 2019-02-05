using System.Collections;
using System.Collections.Generic;
using Games.Shooting.Sushi;
using Games.Shooting.Bullets;
using UnityEngine;
using UniRx; 

namespace Games.Shooting.Enemys.Attack{
	/// <summary>
	/// うずまき
	/// </summary>
	public class Danmaku2 : BaseAttack{
		private int count = 0;
		private Vector2 vec;
		private int rad = 0;
		
		public override void StartAttack(){
			count = 0;
			rad = 0;
			IsStart = true;
			StartCoroutine(Attack());
		}

		IEnumerator Attack(){
			
			while (count < 100){
				rad += 8;
				vec.x = Mathf.Cos(Mathf.Deg2Rad * rad);
				vec.y = Mathf.Sin(Mathf.Deg2Rad * rad);
				GenerateBullet.Generate(SushiList.Instance.GetRandomType(),transform.position,vec,10f);
				count++;
				yield return new WaitForSeconds(0.05f);
			}

			IsEnd = true;
			end.OnNext(Unit.Default);
		}
	}
}