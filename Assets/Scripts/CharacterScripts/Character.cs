using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DungeonCrawler
{
    [System.Serializable]
	public abstract class Character
	{
        //General
        [SerializeField] protected string characterName;
        public string CharacterName { get { return characterName; } set { characterName = value; } }

        [SerializeField] GameObject characterModel;
        public GameObject CharacterModel { get { return characterModel; } set { characterModel = value; } }

        //Health
        [SerializeField] protected bool isInvulnerable;
        public bool IsInvulnerable { get { return isInvulnerable; } set { isInvulnerable = value; } }

        [SerializeField] protected int maxHealth;
        public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }

        [SerializeField] protected int currentHealth;
        public int CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }

        [SerializeField] protected bool isDead;
        public bool IsDead { get { return isDead; } set { isDead = value; } }

        //Effects

    }
}