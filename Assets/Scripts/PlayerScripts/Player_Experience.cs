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
        private int ExperienceRequiredForNextLevel = 0;
        [SerializeField]
        private int expUntilNextLevel
        {
            get
            {
                return ExperienceRequiredForNextLevel - currentExperience;
            }
        }

        [SerializeField]
        private int currentLevel = 1;

        //Leveling Effects
        public GameObject levelUpParticleSystemPrefab;
        public AudioClip LevelUpAudioClip;
        public GameObject MessageCanvas;


        //TODO: Move to only having an XP until next level field?

        //TODO: Fix XP scaling - either flat amount or refer to some chart or come up with a better formula

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
            playerMaster = GetComponent<Player_Master>();
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
                Debug.Log("Leveled to: " + currentLevel + ".");
                currentLevel++;
                currentExperience = currentExperience - ExperienceRequiredForNextLevel;
                playerMaster.CallEventPlayerLeveledUp();
            }
        }

        void UpdateExperienceBarUi()
        {

        }

        void LevelUpHandler()
        {
            //Display message to player
            if (MessageCanvas)
            {

            }

            //Play Noise
            AudioSource.PlayClipAtPoint(LevelUpAudioClip, transform.position);

            //Instntiate Particle System
            Instantiate(levelUpParticleSystemPrefab, transform);
        }

        //TEST METHODS BELOW
    #region TestMethods
        public void TestAddXp()
        {
            GainExperience(50);
        }

        public void TestAddXpToGainLevel()
        {
            var remainingExp = (2 << currentLevel) + 200 - currentExperience;
            GainExperience(remainingExp);
        }
	}
    #endregion TestMethods
}