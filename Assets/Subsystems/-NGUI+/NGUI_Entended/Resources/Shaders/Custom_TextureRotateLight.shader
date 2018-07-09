// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/TextureRotateLight"
{
	Properties
	{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "black" {}
		_LightTex ("Light", 2D) = "black" {}
		_Speed ("Speed", Float) = 0.5
		_LightScale ("LightScale", Float) = 1
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

			fixed _LightScale;
	
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
//			    const float pi = 3.1415926;
//				float T= 2*pi/ _Speed;
//				float t = fmod (_Time.y, T);
//				half2 h2 = half2( 1- 2*v.texcoord.x,  1- 2*v.texcoord.y);
//				float raid =atan2(h2.y,h2.x)- t * _Speed;
//				sincos(raid,h2.x,h2.y);
//				o.uv_light =half2((1- h2.x)/2, (1- h2.y)/2);
				const float pi = 3.1415926;
				half2 h2 = half2( 1- 2*v.texcoord.x,  1- 2*v.texcoord.y);
				float raid =atan2(h2.y,h2.x)- fmod (_Time.y * _Speed,  2*pi);
				sincos(raid,h2.x,h2.y);
				o.uv_light =half2((1- h2.x)/2, (1- h2.y)/2);
				o.color = v.color;
				return o;
			}
				
			fixed4 frag (v2f IN) : COLOR
			{
				fixed4 c = tex2D(_MainTex, IN.uv_main) * IN.color;
				fixed4 l = tex2D(_LightTex, IN.uv_light);
				c.rgb *= (_LightScale*l.a + 1);
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
