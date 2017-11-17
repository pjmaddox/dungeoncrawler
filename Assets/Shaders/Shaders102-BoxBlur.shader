Shader "Custom/BoxBlur"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags{ "RenderType" = "Opaque" }

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
		float _MainTex_TexelSize;

		v2f vert(appdata v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.uv = v.uv;
			return o;
		}

		float4 box(sampler2D texToSample, float2 uv, float4 size)
		{
			//get the sum of the float4's for all nearby texels
			float4 boxTotal = tex2D(texToSample, uv + float2(-size.x, -size.y)) + tex2D(texToSample, uv + float2(0, -size.y)) + tex2D(texToSample, uv + float2(size.x, -size.y))
							+ tex2D(texToSample, uv + float2(-size.x, 0)) + tex2D(texToSample, uv + float2(0, 0)) + tex2D(texToSample, uv + float2(size.x, 0))
							+ tex2D(texToSample, uv + float2(-size.x, size.y)) + tex2D(texToSample, uv + float2(0, size.y)) + tex2D(texToSample, uv + float2(size.x, size.y));
			return boxTotal / 9;
		}

		fixed4 frag(v2f i) : SV_Target
		{
			return box(_MainTex, i.uv, _MainTex_TexelSize);
		}
		ENDCG
		}
	}
}
