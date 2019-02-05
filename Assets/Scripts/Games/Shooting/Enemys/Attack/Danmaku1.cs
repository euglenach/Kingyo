using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Games.Shooting.Bullets;
using Games.Shooting.Sushi;
using UniRx;

namespace Games.Shooting.Enemys.Attack{
	/// <summary>
	/// 全方位弾幕
	/// </summary>
	public class Danmaku1 : BaseAttack{
		private Vector2 vec;
		
		private int count = 0;

		public override void StartAttack(){
			count = 0;
			IsStart = true;
			StartCoroutine(Attack());
		}

		IEnumerator Attack(){
			while (count < 3){
				foreach (var i in Enumerable.Range(0,360).Where(n => n % 6 == 0)){
					vec.x = Mathf.Cos(Mathf.Deg2Rad * i);
					vec.y = Mathf.Sin(Mathf.Deg2Rad * i);
					GenerateBullet.Generate(SushiList.Instance.GetRandomType(),transform.position,vec,10f);
				}
				count++;
				
				yield return new WaitForSeconds(1f);
			}

//			if (count == 10){
//				IsEnd = true;
//				end.OnNext(Unit.Default);
//				yield break;
//			}

			IsEnd = true;
			end.OnNext(Unit.Default);
		}
	}
}