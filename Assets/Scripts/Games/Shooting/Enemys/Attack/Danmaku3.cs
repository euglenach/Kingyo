using System.Collections;
using System.Collections.Generic;
using Games.Shooting.Bullets;
using UnityEngine;
using System.Linq;
using Games.Shooting.Sushi;
using UnityEditor;
using UniRx;

namespace Games.Shooting.Enemys.Attack{
	/// <summary>
	/// ランダムなレーンに打つ
	/// </summary>
	public class Danmaku3 : BaseAttack{
		private int count = 0;
		private Vector2 vec;
		[SerializeField] private GameObject itamae;
		[SerializeField] private GameObject lanepos;
		private List<GameObject> lanes = new List<GameObject>();
		private const float moveSpeed = 5;
		private Rigidbody2D itamaeRb;
		private Vector2 itav;


		// Update is called once per frame
		void Update(){

		}

		public override void StartAttack(){
			foreach (var i in Enumerable.Range(0,lanepos.transform.childCount)){
				lanes.Add(lanepos.transform.GetChild(i).gameObject);
			}
			itamaeRb = itamae.GetComponent<Rigidbody2D>();
			
			count = 0;
			vec = Vector2.left;
			StartCoroutine(Attack());
		}

		IEnumerator Attack(){
			//while (count < 2){
				var ran = Random.Range(0, lanes.Count);
				var pos = lanes[ran].transform.position;
				
				var dis = Vector2.Distance(itamae.transform.position, pos);//移動距離		
				itav = pos - itamae.transform.position;
				float rad = Mathf.Atan2(itav.y, itav.x);
				itav.x = Mathf.Cos(rad);
				itav.y = Mathf.Sin(rad);
				itamaeRb.velocity = itav * moveSpeed;
				
				var movetime = dis / moveSpeed; //移動時間
				
				yield return new WaitForSeconds(movetime);

				itamae.transform.position = pos;
				itamaeRb.velocity = Vector2.zero;
			
				foreach (var i in Enumerable.Range(0,3)){
					GenerateBullet.Generate(SushiList.Instance.GetRandomType(),itamae.transform.position,vec,5f);
					yield return new WaitForSeconds(0.3f);
				}
				count++;
				
				yield return new WaitForSeconds(0.5f);
			//}
			IsEnd = true;
			end.OnNext(Unit.Default);
		}
	}
}