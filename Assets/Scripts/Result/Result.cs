using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Systems.Managers;
using Games.Shooting.Sushi;
using UnityEditor;
using Systems.Managers;

namespace Result{
	public class Result : MonoBehaviour{
		[SerializeField]AudioClip jarin;
		[SerializeField]AudioClip dodon;
		[SerializeField]AudioClip people;
		[SerializeField] private Text coinText;
		[SerializeField] private Text coinCount;
		[SerializeField] private GameObject prices;
		[SerializeField] private Text[] others;
		private AudioSource audioSource;
		List<Text> netaText = new List<Text>();
		private bool isEnd;
		
		
		void Start(){
			audioSource = GetComponent<AudioSource>();
			foreach (var i in Enumerable.Range(0,prices.transform.childCount)){
				var temp = prices.transform.GetChild(i).gameObject;
				netaText.Add(temp.GetComponent<Text>());
			}
			BGMManager.Instance.StartMusic();
			StartCoroutine(Display());
		}

		// Update is called once per frame
		void Update(){
			if (isEnd){
				if (Input.anyKeyDown){
					isEnd = false;
					FadeManager.Instance.LoadScene(Scene.Game,2,true);
				}
			}
		}

		IEnumerator Display(){
			var scores = GameManager.Instance.SushiScores;
			audioSource.PlayOneShot(dodon);			
			yield return new WaitForSeconds(2);

			coinText.text = "取った数";
			audioSource.PlayOneShot(jarin);
			yield return new WaitForSeconds(1);
			coinCount.text = GameManager.Instance.CoinCount.ToString() + "枚";
			audioSource.PlayOneShot(jarin);
			yield return new WaitForSeconds(1);
			
			foreach (var i in Enumerable.Range(0,netaText.Count)){
				var j = (SushiType)Enum.ToObject(typeof(SushiType), i);
				netaText[i].text = $"× {scores[j]/SushiList.Instance.Neta[i].GetComponent<Sushi>().Price}   {scores[j].ToString()} 円";
				audioSource.PlayOneShot(jarin);
				yield return new WaitForSeconds(1);
			}

			others[0].text = "無銭飲食";
			audioSource.PlayOneShot(jarin);
			yield return new WaitForSeconds(1);
			others[1].text = GameManager.Instance.NoMoneyCount.ToString() + "回";
			audioSource.PlayOneShot(jarin);
			yield return new WaitForSeconds(1);

			others[2].text = "成績";
			audioSource.PlayOneShot(jarin);
			yield return new WaitForSeconds(3);
			audioSource.PlayOneShot(jarin);
			others[3].text = scores.Values.Sum().ToString() + "円";
			yield return new WaitForSeconds(1);
			audioSource.PlayOneShot(people);
			yield return new WaitForSeconds(2);
			isEnd = true;
			yield break;
		}
	}
}