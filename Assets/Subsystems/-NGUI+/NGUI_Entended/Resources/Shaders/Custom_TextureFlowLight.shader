// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/TextureFlowLight"
{
	Properties
	{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "black" {}
		_LightTex ("Light", 2D) = "black" {}
		_Speed ("Speed", Float) = 0.5
		_Delay ("Delay", Float) = 0
	}
	
	SubShader
	{
		LOD 200

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
		
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Fog { Mode Off }
			Offset -1, -1
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag			
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _LightTex;
			float4 _LightTex_ST;
			fixed _Speed;
			fixed _Delay;
	
			struct appdata_t
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
			};
	
			struct v2f
			{
				float4 vertex : SV_POSITION;
				half2 uv_main : TEXCOORD0;
				half2 uv_light : TEXCOORD1;
				fixed4 color : COLOR;
			};
	
			v2f o;

			v2f vert (appdata_t v)
			{
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv_main = v.texcoord;
				float t = fmod (_Time.y, _Delay + 1 / _Speed);
				if (t > 1/_Speed)
					o.uv_light = half2 (1, 1);
				else 
					o.uv_light = half2 (-0.36 + v.texcoord.x / 3 - t * _Speed / 1.5, v.texcoord.y / 3);
				o.color = v.color;
				return o;
			}
				
			fixed4 frag (v2f IN) : COLOR
			{
				fixed4 c = tex2D(_MainTex, IN.uv_main) * IN.color;
				fixed4 l = tex2D(_LightTex, IN.uv_light);
				c.rgb *= fixed3 (l.r + 1, l.g + 1, l.b + 1);
				return c;
			}
			ENDCG
		}
	}

	SubShader
	{
		LOD 100

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
		
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Fog { Mode Off }
			Offset -1, -1
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMaterial AmbientAndDiffuse
			
			SetTexture [_MainTex]
			{
				Combine Texture * Primary
			}
		}
	}
}