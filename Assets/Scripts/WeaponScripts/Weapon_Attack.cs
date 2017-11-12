using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
	public class Weapon_Attack : MonoBehaviour 
	{
        public Weapon_Master weaponMaster;
        public AnimationClip FirstAttack;
        public AnimationClip SecondAttack;
        public AnimationClip ThirdAttack;
        public AnimationClip StabAttack;

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

		void Start () 
		{
			
		}
		
		void Update () 
		{
			
		}
	}
}
