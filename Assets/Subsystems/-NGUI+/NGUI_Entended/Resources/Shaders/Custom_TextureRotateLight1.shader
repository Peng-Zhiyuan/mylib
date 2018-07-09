// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/Custom/TextureRotateLight 1"
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
			ColorMask RGB
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
			float4 _ClipRange0 = float4(0.0, 0.0, 1.0, 1.0);
			float2 _ClipArgs0 = float2(1000.0, 1000.0);

	
			struct appdata_t
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				half4 color : COLOR;
			};
			struct v2f
			{
				float4 vertex : SV_POSITION;
				half2 uv_main : TEXCOORD0;
				//half2 uv_light : TEXCOORD1;
				half4 color : COLOR;
				float2 worldPos : TEXCOORD1;

			};
	
			v2f o;

			v2f vert (appdata_t v)
			{
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv_main = v.texcoord;
				//o.uv_light = v.texcoord;

				o.color = v.color;
				o.worldPos = v.vertex.xy * _ClipRange0.zw + _ClipRange0.xy;
				return o;
			}
				
			half4 frag (v2f IN) : COLOR
			{
				// Softness factor
				float2 factor = (float2(1.0, 1.0) - abs(IN.worldPos)) * _ClipArgs0;
				const float pi = 3.1415926;
				half2 h2 = half2( 1- 2*IN.uv_main.x,  1- 2*IN.uv_main.y);
				float raid =atan2(h2.y,h2.x)- fmod (_Time.y * _Speed,  2*pi);
				sincos(raid,h2.x,h2.y);
				half2 uv_light =half2((1- h2.x)/2, (1- h2.y)/2);
				fixed4 c = tex2D(_MainTex, IN.uv_main) * IN.color;
				fixed4 l = tex2D(_LightTex, uv_light);
				c.rgb *= (_LightScale*l.a + 1);
				c.a *= clamp( min(factor.x, factor.y), 0.0, 1.0);
				return c;
			}
//	
//			struct v2f
//			{
//				float4 vertex : SV_POSITION;
//				half2 uv_main : TEXCOORD0;
//				half2 uv_light : TEXCOORD1;
//				half4 color : COLOR;
//				float2 worldPos : TEXCOORD2;
//
//			};
//	
//			v2f o;
//
//			v2f vert (appdata_t v)
//			{
//				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
//				o.uv_main = v.texcoord;
//				o.uv_light = v.texcoord;
//				const float pi = 3.1415926;
//				half2 h2 = half2( 1- 2*v.texcoord.x,  1- 2*v.texcoord.y);
//				float raid =atan2(h2.y,h2.x)- fmod (_Time.y * _Speed,  2*pi);
//				sincos(raid,h2.x,h2.y);
//				o.uv_light =half2((1- h2.x)/2, (1- h2.y)/2);
//				o.color = v.color;
//				o.worldPos = v.vertex.xy * _ClipRange0.zw + _ClipRange0.xy;
//				return o;
//			}
//				
//			half4 frag (v2f IN) : COLOR
//			{
//				// Softness factor
//				float2 factor = (float2(1.0, 1.0) - abs(IN.worldPos)) * _ClipArgs0;
//
//				fixed4 c = tex2D(_MainTex, IN.uv_main) * IN.color;
//				fixed4 l = tex2D(_LightTex, IN.uv_light);
//				c.rgb *= (_LightScale*l.a + 1);
//				c.a *= clamp( min(factor.x, factor.y), 0.0, 1.0);
//				return c;
//			}
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
