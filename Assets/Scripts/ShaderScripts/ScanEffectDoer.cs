using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShaderPractice
{
    public class ScanEffectDoer : MonoBehaviour
    {
		
        [SerializeField] float currentScanSize;
		[SerializeField] bool isScanning;
        public float scanMaxSize = 200f;
		public float scanEffectWidth = 10f;
		public float scanSizeIncreaseSpeed = 15f;
		public Camera targetCamera;
        [SerializeField]
        Transform scanOrigin;

	    public Material effectMaterial;

        // Update is called once per frame
        void Update()
        {
			//Look for click
			if (!isScanning && Input.GetMouseButtonDown (0)) {
				isScanning = true;
                DetectClickLocation();
            }

            if(isScanning)
                currentScanSize += Time.deltaTime * scanSizeIncreaseSpeed;

			//Check For Done
			if (isScanning && currentScanSize >= scanMaxSize)
                isScanning = false;
        }

		void OnRenderImage(RenderTexture src, RenderTexture dst)
		{
            //Set some crap on the effect material
            //Here

            //Get some info from depth buffer and some other shit and apply to Material so shader can mess with it.

            Graphics.Blit(src, dst, effectMaterial);
		}

		void DetectClickLocation()
		{
            RaycastHit hitInfo;
            Physics.Raycast(targetCamera.transform.position, targetCamera.transform.forward, out hitInfo);
            scanOrigin = hitInfo.transform;
		}
    }
}
