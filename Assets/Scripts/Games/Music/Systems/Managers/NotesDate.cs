using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

namespace Games.Music.Systems.Managers{
	public class NotesDate : MonoBehaviour{
		private const string fileName = "Music.csv";
		private TextAsset csvFile;
		private List<string[]> csvDatas = new List<string[]>();

		public static NotesStatus[] NotesStatuses { get; private set; }

		void Start(){
			csvFile = Resources.Load(fileName) as TextAsset;
			var reader = new StringReader(csvFile.text);

			while (reader.Peek() > -1){
				var line = reader.ReadLine();
				csvDatas.Add(line.Split(','));
			}

			NotesStatuses = new NotesStatus[csvDatas.Count];

			foreach (var i in Enumerable.Range(0,csvDatas.Count)){
				NotesStatuses[i].Lane = int.Parse(csvDatas[i][0]);
				NotesStatuses[i].Time = float.Parse(csvDatas[i][1]);
			}

			NotesStatuses = NotesStatuses.OrderBy(x => x.Time).ToArray();
			
		}

		// Update is called once per frame
		void Update(){

		}
	}
}