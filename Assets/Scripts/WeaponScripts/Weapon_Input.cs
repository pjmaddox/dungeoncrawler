using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
	public class Weapon_Input : MonoBehaviour 
	{
        public Weapon_Master weaponMaster;

        void OnEnable()
		{
			SetInitialReferences();
		}

		void OnDisable()
		{

		}

		void SetInitialReferences()
		{
            weaponMaster = GetComponent<Weapon_Master>();
		}
		
		void Update () 
		{
            CheckForAttack();
		}

        void CheckForAttack()
        {
            if (Input.GetButtonDown("Fire1"))
                DetermineAttackType();
        }

        void DetermineAttackType()
        {
            //Check for lung attack
            var verticalInput = Input.GetAxis("Vertical");
            if (verticalInput < 0)
                weaponMaster.CallEventPlayerLungeAttack();
            else
            {
                weaponMaster.CallEventPlayerComboAttack();
            }

        }
	}
}
