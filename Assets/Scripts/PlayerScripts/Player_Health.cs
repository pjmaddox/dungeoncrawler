using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
	public class Player_Health : MonoBehaviour 
	{
        private Player_Master playerMaster;

        [SerializeField]
        int currentHealth;

        public int maximumHealth = 100;

		void OnEnable()
		{
			SetInitialReferences();
            playerMaster.EventPlayerReceivingGrossDamage += TakeRawDamage;
            playerMaster.EventPlayerHealed += HealDamage;
            playerMaster.EventPlayerReceivingGrossDamage += MitigateAndTakeDamage;
        }

		void OnDisable()
		{
            playerMaster.EventPlayerReceivingGrossDamage -= TakeRawDamage;
            playerMaster.EventPlayerHealed -= HealDamage;
            playerMaster.EventPlayerReceivingGrossDamage -= MitigateAndTakeDamage;
        }

		void SetInitialReferences()
		{
            playerMaster = GetComponent<Player_Master>();
		}

        void MitigateAndTakeDamage(int grossDamage)
        {
            //TODO: Take armor into account or some other stat from Player_Stats
            //For now just subtract 10
            playerMaster.CallEventPlayerTookNetDamage(grossDamage - 10);
        }

        void TakeRawDamage(int amount)
        {
            currentHealth -= amount;
            playerMaster.CallEventUpdateResourceBar("Health", currentHealth);
            CheckForDeath();
        }

        void HealDamage(int amount)
        {
            currentHealth = (currentHealth + amount > maximumHealth)? maximumHealth : currentHealth + amount;
        }

        void CheckForDeath()
        {
            if (currentHealth < 1)
                playerMaster.CallEventPlayerDied();
        }

        //TESTING
        public void TestTakeDamage()
        {
            playerMaster.CallEventPlayerReceivingGrossDamage(35);
        }

        public void TestHealDamage()
        {
            playerMaster.CallEventPlayerHealed(15);
        }

	}
}