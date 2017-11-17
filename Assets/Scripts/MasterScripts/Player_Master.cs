using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
	public class Player_Master : MonoBehaviour
    {

        private GameManager_Master gameManagerSCript;
        private GameManager_References gameReferences;

        public delegate void GeneralEventHandler();

        public event GeneralEventHandler EventPlayerToggledInventoryUi;
        public event GeneralEventHandler EventPlayerToggledMenuUi;
        public event GeneralEventHandler EventPlayerLeveledUp;

        public delegate void ExperienceEventHandler(int earnedValue);
        public event ExperienceEventHandler EventPlayerEarnedExperience;

        public int playerId;
        public bool isInventoryVisible = false;
        public bool isMenuVisible = false;

        void OnEnable()
        {
            var gameManagerObject = GameObject.Find("GameManager");
            gameManagerSCript = gameManagerObject.GetComponent<GameManager_Master>();
            gameReferences = gameManagerObject.GetComponent<GameManager_References>();
        }

        public void CallEventPlayerToggledInventory()
        {
            if (EventPlayerToggledInventoryUi != null)
                EventPlayerToggledInventoryUi();

            isInventoryVisible = !isInventoryVisible;
        }

        public void CallEventPlayerToggledMenu()
        {
            if (EventPlayerToggledMenuUi != null)
                EventPlayerToggledMenuUi();

            isMenuVisible = !isMenuVisible;
        }

        public void CallEventPlayerEarnedExperience(int amountEarned)
        {
            if (EventPlayerEarnedExperience != null)
                EventPlayerEarnedExperience(amountEarned);
        }

        public void CallEventPlayerLeveledUp()
        {
            if (EventPlayerLeveledUp != null)
                EventPlayerLeveledUp();
        }
    }
}
