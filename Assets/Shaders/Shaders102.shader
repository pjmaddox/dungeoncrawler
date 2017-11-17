﻿Shader "Custom/Shaders102"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_DisplaceTex("Displacement Texture", 2D) = "white" {}
		_DisplacementMagnitude("Displacement Magnitude", Range(0.0,.1)) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _DisplaceTex;
			float _DisplacementMagnitude;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			float4 box(sampler2D texToSample, float2 uv, float4 size)
			{

			}
			
			fixed4 frag(v2f i) : SV_Target
			{
				float2 distUv = float2(i.uv.x + _Time.x * 2, i.uv.y + _Time.x * 2);
				float2 disp = tex2D(_DisplaceTex, distUv).xy;
				disp = ((disp * 2) - 1) * _DisplacementMagnitude;

				return tex2D(_MainTex, i.uv + disp);
			}
			ENDCG
		}
	}
}
