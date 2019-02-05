using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Games.Shooting.Players{
    public class PlayerAttack : MonoBehaviour{

        public GameObject kobanPrefab;
        private PlayerManager pm;
        private AudioSource audioSource;
        [SerializeField] private AudioClip attack;

        private void Start(){
            pm = GetComponent<PlayerManager>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Attack(){

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(kobanPrefab, transform.position, Quaternion.identity);
                audioSource.PlayOneShot(attack);
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