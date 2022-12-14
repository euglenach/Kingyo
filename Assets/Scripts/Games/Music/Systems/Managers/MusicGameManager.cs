using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Systems.Managers;
using Games.Shooting.Systems.Managers;
using UnityEditor;
using UniRx;

namespace Games.Music.Systems.Managers{
	public class MusicGameManager : MonoBehaviour{
		public bool IsEnd { get; private set; }
		[SerializeField] private GameObject back;
		[SerializeField] private NotesManager nm;
		[SerializeField] private GameObject musicObj;
		private ShootingGameManager sgm;
		
		List<GameObject> backs = new List<GameObject>();
		private const float speed = 10f;

		private void Update(){
			//Debug.Log(BGMManager.Instance.isPlay +""+ nm.finished);
		}

		private void Start(){
			foreach (var i in Enumerable.Range(0,back.transform.childCount)){
				backs.Add(back.transform.GetChild(i).gameObject);
			}

			sgm = GetComponent<ShootingGameManager>();
			BGMManager.Instance
			          .ObserveEveryValueChanged(n => !n.isPlay)
			          .FirstOrDefault(n => n && nm.finished)
			          .Subscribe(_ => StartCoroutine(Transition())).AddTo(gameObject);
			
		}

		IEnumerator Transition(){
			IsEnd = true;
			backs[0].GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
			backs[1].GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
			backs[2].GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
			musicObj.transform.GetChild(0).gameObject.SetActive(false);
			yield return new WaitForSeconds(1.5f);
			Destroy(back);
			musicObj.SetActive(false);
			StartCoroutine(sgm.Transition());
		}
	}
}