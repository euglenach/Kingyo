using System.Collections;
using System.Collections.Generic;
using Systems.Managers;
using UnityEngine;
using Games.Shooting.Sushi;

namespace Games.Shooting.Players{
    public class TakeItem : MonoBehaviour{
        private void OnCollisionEnter(Collision other){
            if (other.gameObject.CompareTag("Sushi")){
                var temp = other.gameObject.GetComponent<Sushi.Sushi>();
                GameManager.Instance.SushiScores[temp.SushiType] += temp.Price;
            }
        }
    }
}