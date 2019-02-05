using System.Collections;
using System.Collections.Generic;
using Systems.Managers;
using UnityEngine;
using UniRx;

namespace Games.Music.Systems.Managers {

    public class NotesManager : MonoBehaviour {
        [SerializeField]
        private GameObject notes;
        [SerializeField]
        private float lineYPos;

        private Camera camera;
        private float delta = -3;
        private float distance;
        private float top;
        private float down;
        private int notesCount;
        private bool finished = false;

        private void Start(){
            camera = Camera.main;
            top = camera.ViewportToWorldPoint(Vector3.one).y;
            down = camera.ViewportToWorldPoint(Vector3.zero).y;
            distance = top - lineYPos;
            this
                .ObserveEveryValueChanged(n => n.delta)
                .First(n => n > 0)
                .Subscribe(_ => BGMManager.Instance.StartMusic());
        }

        private void FixedUpdate() {
            delta += Time.deltaTime;
            if (!finished){
                //                                                    fps
                var time = NotesDate.NotesStatuses[notesCount].Time - 0.02 * (distance / Notes.notesSpeed);
                if (delta > time){
                    Instantiate(notes,
                                new Vector3(-2.883f + 1.916f * NotesDate.NotesStatuses[notesCount].Lane, top, 0),
                                Quaternion.identity);
                    notesCount++;
                    if (notesCount == NotesDate.NotesStatuses.Length) finished = true;
                }
            }

        }

        private void Update()
        {
            for (int i = 0; i < NotesDate.NotesStatuses.Length; i++){
                if (delta - 0.2 < NotesDate.NotesStatuses[i].Time && NotesDate.NotesStatuses[i].Time < delta + 0.2){
                    switch (NotesDate.NotesStatuses[i].Lane){
                        case 0:
                            if (Input.GetKeyDown(KeyCode.D)) Debug.Log("hit");
                            break;
                        case 1:
                            if (Input.GetKeyDown(KeyCode.F)) Debug.Log("hit");
                            break;
                        case 2:
                            if (Input.GetKeyDown(KeyCode.J)) Debug.Log("hit");
                            break;
                        case 3:
                            if (Input.GetKeyDown(KeyCode.K)) Debug.Log("hit");
                            break;
                            //コインゲット
                    }
                }
            }
        }
    }


}

