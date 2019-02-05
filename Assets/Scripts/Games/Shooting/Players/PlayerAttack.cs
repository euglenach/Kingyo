using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Shooting.Players{
    public class PlayerAttack : MonoBehaviour{

        public GameObject kobanPrefab;
        bool attackFlag = true;

        private void Attack(){

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(kobanPrefab, transform.position, Quaternion.identity);
            }
        }

        void Update()
        {
            if (attackFlag){
                Attack();
            }
        }
    }
}