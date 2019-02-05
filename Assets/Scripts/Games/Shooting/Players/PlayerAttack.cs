using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Games.Shooting.Players{
    public class PlayerAttack : MonoBehaviour{

        public GameObject kobanPrefab;
        private PlayerManager pm;

        private void Start(){
            pm = GetComponent<PlayerManager>();
        }

        private void Attack(){

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(kobanPrefab, transform.position, Quaternion.identity);
            }
        }

        void Update()
        {
            if (!pm.IsAttack){
                return;
            }
            Attack();
        }
    }
}