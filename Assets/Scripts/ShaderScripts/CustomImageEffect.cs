﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawler
{
    [ExecuteInEditMode]
	public class CustomImageEffect : MonoBehaviour 
	{
        
        public Material EffectMaterial;

        [Range(0, 100)]
        public int BlurIterations;

        [Range(0, 4)]
        public int DownRes;

		void OnRenderImage(RenderTexture src, RenderTexture dst)
        {
            int width = src.width >> DownRes;
            int height = src.height >> DownRes;

            RenderTexture rt = RenderTexture.GetTemporary(width, height);
            Graphics.Blit(src, rt);

            for(int i = 0; i < BlurIterations; ++i)
            {
                RenderTexture rt2 = RenderTexture.GetTemporary(rt.width, rt.height);
                Graphics.Blit(rt, rt2, EffectMaterial);
                RenderTexture.ReleaseTemporary(rt);
                rt = rt2;
            }

            Graphics.Blit(rt, dst);
            RenderTexture.ReleaseTemporary(rt);
        }
	}
}
