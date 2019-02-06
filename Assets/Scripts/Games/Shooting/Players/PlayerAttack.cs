using System.Collections;
using System.Collections.Generic;
using Systems.Managers;
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

            if (Input.GetKeyDown(KeyCode.Space) && GameManager.Instance.CoinCount - GameManager.Instance.UseCoin > 0)
            {
                Instantiate(kobanPrefab, transform.position, Quaternion.identity);
                GameManager.Instance.UseCoin++;
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