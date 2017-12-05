using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
    [System.Serializable]
	public abstract class Ability : ScriptableObject
	{
        //This versus just public fields?
        public string abilityName;
        public string description;
        public float cooldown;
        public Icon abilityIcon;

        //public string AbilityName { get { return abilityName; } set { abilityName = value; } }
        //public float Cooldown { get { return cooldown; } set { cooldown = value; } }

        public abstract void ActivateAbility();
    }
}