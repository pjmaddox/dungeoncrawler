using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
	public class Player_Stats : MonoBehaviour 
	{
        //Main Stats
        public int Ferocity { get; private set; }
        public int Tenacity { get; private set; }
        public int Mysticism { get; private set; }

        //References
        private Player_Master playerMaster;

        void OnEnable()
		{
			SetInitialReferences();
		}

		void OnDisable()
		{

		}

		void SetInitialReferences()
		{
            playerMaster = GetComponent<Player_Master>();

        }
	}
}