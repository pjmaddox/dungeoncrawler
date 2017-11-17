using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
	public class Player_Experience : MonoBehaviour 
	{

        private Player_Master playerMaster;

        [SerializeField]
        private int currentExperience = 0;
        [SerializeField]
        private int currentLevel = 1;


		void OnEnable()
		{
			SetInitialReferences();
            playerMaster.EventPlayerEarnedExperience += GainExperience;
		}

		void OnDisable()
		{
            playerMaster.EventPlayerEarnedExperience -= GainExperience;
        }

		void SetInitialReferences()
		{
            GetComponent<Player_Master>();
		}

		void GainExperience(int expToGain)
        {
            Debug.Log("Current experience changed from " + currentExperience + " to " + (currentExperience + expToGain) + ".");
            currentExperience += expToGain;
            CheckForLevelUp();
        }

        void CheckForLevelUp()
        {
            Debug.Log("Checking for level up. Current XP = " + currentExperience + " against " + ((2 << currentLevel) + 200));
            if (currentExperience >= (2 << currentLevel) + 200)
            {
                currentLevel++;
                playerMaster.CallEventPlayerLeveledUp();
            }
        }
	}
}