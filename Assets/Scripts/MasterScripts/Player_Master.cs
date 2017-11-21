using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
	public class Player_Master : MonoBehaviour
    {

        private GameManager_Master gameManagerScript;
        private GameManager_References gameReferences;

        //General Events
        public delegate void GeneralEventHandler();

        //Ui Events
        public delegate void UiValueUpdateEventHandler(string resourceName, int newValue);
        public event GeneralEventHandler EventPlayerToggledInventoryUi;
        public event GeneralEventHandler EventPlayerToggledMenuUi;
        public event UiValueUpdateEventHandler EventUpdateResourceBar;
        

        //Experience and leveling
        public event GeneralEventHandler EventPlayerLeveledUp;

        public delegate void ExperienceEventHandler(int earnedValue);
        public event ExperienceEventHandler EventPlayerEarnedExperience;

        //Death
        public event GeneralEventHandler EventPlayerDied;

        //Player health and damage events
        public delegate void PlayerHealthChangeEventHandler(int amount);
        public event PlayerHealthChangeEventHandler EventPlayerReceivingGrossDamage;
        public event PlayerHealthChangeEventHandler EventPlayerTookNetDamage;
        public event PlayerHealthChangeEventHandler EventPlayerHealed;


        //Fields
        public int playerId;
        public bool isInventoryVisible = false;
        public bool isMenuVisible = false;

        void OnEnable()
        {
            var gameManagerObject = GameObject.Find("GameManager");
            gameManagerScript = gameManagerObject.GetComponent<GameManager_Master>();
            gameReferences = gameManagerObject.GetComponent<GameManager_References>();
        }

        #region Call Events Region

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

        public void CallEventPlayerHealed(int amountHealed)
        {
            if (EventPlayerHealed != null)
                EventPlayerHealed(amountHealed);
        }

        public void CallEventPlayerTookNetDamage(int received)
        {
            if (EventPlayerTookNetDamage != null)
                EventPlayerTookNetDamage(received);
        }

        public void CallEventPlayerReceivingGrossDamage(int amount)
        {
            if (EventPlayerReceivingGrossDamage != null)
                EventPlayerReceivingGrossDamage(amount);
        }

        public void CallEventPlayerDied()
        {
            if (EventPlayerDied != null)
                EventPlayerDied();
        }

        public void CallEventUpdateResourceBar(string resouce, int newValue)
        {
            if (EventUpdateResourceBar != null)
                EventUpdateResourceBar(resouce, newValue);
        }

        #endregion Call Events Region
    }
}
