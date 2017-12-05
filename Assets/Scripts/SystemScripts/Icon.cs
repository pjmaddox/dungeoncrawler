using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
    [System.Serializable]
	public class Icon 
	{
		[SerializeField] Sprite iconImage;
        [SerializeField] string hoverText;

        public Sprite IconImage { get { return iconImage; } set { iconImage = value; } }
        public string HoverText { get { return hoverText; } set { hoverText = value; } }
	}
}