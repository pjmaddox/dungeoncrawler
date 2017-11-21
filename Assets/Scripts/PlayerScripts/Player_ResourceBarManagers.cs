using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace DungeonCrawler
{
	public class Player_ResourceBarManagers : MonoBehaviour 
	{
        [System.Serializable]
        public class ResourceSlider
        {
            public string ResourceName;
            public Slider MySlider;
            public int CurrentValue;
        }

        public ResourceSlider[] resourceSliders;

        private Player_Master playerMaster;

		void OnEnable()
		{
			SetInitialReferences();
            playerMaster.EventUpdateResourceBar += UpdateResourceSlider;
        }

		void OnDisable()
		{
            playerMaster.EventUpdateResourceBar += UpdateResourceSlider;
        }

		void SetInitialReferences()
		{
            playerMaster = GetComponent<Player_Master>();

        }

        void UpdateResourceSlider(string resourceName, int newValue)
        {
            var relaventSlider = resourceSliders.FirstOrDefault(x => x.ResourceName == resourceName);
            if (relaventSlider != null)
                relaventSlider.CurrentValue = newValue;
        }
	}
}