using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
    [System.Serializable]
	public class CharacterBuffManager
	{
        [SerializeField] List<Buff> buffs;
        public List<Buff> Buffs { get { return buffs; } }

        public void AddBuff(Buff toAdd)
        {
            buffs.Add(toAdd);
        }

        public void RemoveBuff(Buff toRemove)
        {
            var foundItem = buffs.Find(x => x.Name == toRemove.Name);
            if (foundItem != null)
                buffs.Remove(toRemove);
        }

        public void RemoveRandomBuff()
        {

        }

        public void RemoveRandomBuffOfType()
        {

        }
    }
}