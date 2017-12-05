using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DungeonCrawler
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Abilities/Projectile Ability", order = 5)]
    public class ProjectileAbility : Ability
	{
        [SerializeField] protected GameObject projectilePrefab;
        public GameObject ProjectilePrefab { get { return projectilePrefab; } set { projectilePrefab = value; } }

        public override void ActivateAbility()
        {

        }
    }
}