using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
	public class Weapon_Master : MonoBehaviour 
	{

        public delegate void PlayerAttack();
        public event PlayerAttack asd;
		
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

		void Start () 
		{
			
		}
		
		void Update () 
		{
			
		}
	}
}
