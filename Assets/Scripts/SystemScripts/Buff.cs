using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
	public class Buff
	{
        //Membersaaw
		[SerializeField] string name;
        [SerializeField] float remainingDuration;
        [SerializeField] float maxDuration;
        [SerializeField] Icon buffIcon;

        //Properties
        public string Name { get { return name; } set { name = value; } }
        public float RemainingDuration { get { return remainingDuration; } set { remainingDuration = value; } }
        public float MaxDuration { get { return maxDuration; } set { maxDuration = value; } }
        public Icon BuffIcon { get { return buffIcon; } set { buffIcon = value; } }

        //Effects
        //TODO
    }
}