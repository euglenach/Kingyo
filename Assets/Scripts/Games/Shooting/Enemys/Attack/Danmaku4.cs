using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Shooting.Bullets;
using Games.Shooting.Sushi;
using UniRx;
using System.Linq;

namespace Games.Shooting.Enemys.Attack{
	/// <summary>
	/// Player狙い
	/// </summary>
	public class Danmaku4 : BaseAttack{
		private Vector2 vec;
		private int count = 0;
		[SerializeField] private GameObject player;
		[SerializeField] private GameObject itamae;
		
		public override void StartAttack(){
			IsStart = true;
			StartCoroutine(Attack());
		}

		IEnumerator Attack(){
			while (count < 2){
				foreach (var i in Enumerable.Range(0,5)){
					var dis = Vector2.Distance(itamae.transform.position, player.transform.position);
					vec = player.transform.position - itamae.transform.position;
					var rad = Mathf.Atan2(vec.y, vec.x);
					vec.x = Mathf.Cos(rad);
					vec.y = Mathf.Sin(rad);
					
					GenerateBullet.Generate(SushiList.Instance.GetRandomType(),itamae.transform.position,vec,5f);
				}
				count++;
				
				yield return new WaitForSeconds(1f);
			}
			IsEnd = true;
			end.OnNext(Unit.Default);
		}
	}
}
