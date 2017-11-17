using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
	public class Weapon_Master : MonoBehaviour 
	{
        public delegate void GeneralEventHandler();
        public event GeneralEventHandler EventDroppedWeapon;

        public delegate void PlayerAttackHandler();
        public event PlayerAttackHandler EventPlayerLungeAttack;
        public event PlayerAttackHandler EventPlayerComboAttack;
        public event PlayerAttackHandler EventAttackFinished;

        public delegate void AttackHitHandler(Transform hitTarget, Vector3 hitLocation);
        public event AttackHitHandler EventDefaultHit;
        public event AttackHitHandler EventEnemyHit;

        public bool IsInPlayersHands;
        public bool CanAttack;
        public bool HasAmmo;

        void OnEnable()
		{
			SetInitialReferences();
		}

		void OnDisable()
		{

		}

		void SetInitialReferences()
		{

		}

        public void CallEventPlayerLungeAttack()
        {
            if (EventPlayerLungeAttack != null)
                EventPlayerLungeAttack();
        }

        public void CallEventDroppedWeapon()
        {
            if (EventDroppedWeapon != null)
                EventDroppedWeapon();
        }

        public void CallEventPlayerComboAttack()
        {
            if (EventPlayerComboAttack != null)
                EventPlayerComboAttack();
        }

        public void CallEventAttackFinished()
        {
            if (EventAttackFinished != null)
                EventAttackFinished();
        }

        public void CallEventDefaultHit(Transform target, Vector3 location)
        {
            if (EventDefaultHit != null)
                EventDefaultHit(target, location);
        }

        public void CallEventEnemyHit(Transform target, Vector3 location)
        {
            if (EventEnemyHit != null)
                EventEnemyHit(target, location);
        }
    }
}
