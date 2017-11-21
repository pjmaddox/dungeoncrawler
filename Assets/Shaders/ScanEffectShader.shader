Shader "Hidden/ScanEffectShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_ScanDistance("Scan Distance", float)
		_ScanWidth("Scan Effect Width", float)
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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
				float4 ray : TEXCOORD1;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float _ScanDistance;
			float _ScanWidth;

			fixed4 frag (v2f i) : SV_Target
			{
				//Get raw depth value from depth buffer for this vertex
				float rawDepth = DecodeFloatRG(tex2D(_CameraDepthTexture, i.uv_depth));

				//Get value from 0 - 1 for depth at this vertex (normalized)
				float linearDepth = Linear01Depth(rawDepth);

				//Results in a vector pointing from the camera to the farplane - multiplying the depth times the normalized, interpolated ray.
				float4 wsDir = linearDepth * i.interpolatedRay;

				//ws = world space. Add the camera's worldspace position to the calculated direction from the camera to get worldspace coordinates for the vertex. 
				float3 wsPos = _WorldSpaceCameraPos + wsDir;

				//Get scan color effect
				//Find worldspace distance from the camera to the given vertex (ws)
				float dist = distance(wsPos, _WorldSpaceCameraPos);

				float4 baseColor = tex2D(_MainTex, i.uv);
				float4 scanColor;

				//This was an initial test and creates a solid white ring (1 = float4(1,1,1,1) of width _ScanWidth which expands for _ScanDistance)
				//if (dist < _ScanDistance && dist > _ScanDistance - _ScanWidth)
				//{
				//	return 1;
				//}
				
				//If not out of range of the scan, and is within the width of the scan effect
				if(dist < _ScanDistance && dist >= _ScanDistance - _ScanWidth)
				{
					scanColor = 1 - ((_ScanDistance - dist) / _ScanWidth);
				}
				return baseColor + scanColor;
			}

			ENDCG
		}
	}
}
