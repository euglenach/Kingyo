using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using System;
using UnityEditor;

namespace UIs{
    public class ChangeFace : MonoBehaviour{
        [SerializeField] private GameObject[] tatie;

        public void Change(int index){
            Chan(index);
            Observable.Timer(TimeSpan.FromSeconds(2))
                      .Subscribe(_ => Chan(0)).AddTo(gameObject);
        }

        private void Chan(int index){
            foreach (var i in Enumerable.Range(0, tatie.Count())){
                bool b = false;
                if (i == index) b = true;
                tatie[i].SetActive(b);
            }
        }
    }
}