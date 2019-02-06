using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChangeFace : MonoBehaviour{
    [SerializeField] private GameObject[] tatie;

    public void Change(int index){
//        bool[] b = new bool[tatie.Count()];
//        b[index] = true;
        foreach (var i in Enumerable.Range(0,tatie.Count())){
            bool b = false;
            if (i == index) b = true;
            tatie[i].SetActive(b);
        }
    }
}
