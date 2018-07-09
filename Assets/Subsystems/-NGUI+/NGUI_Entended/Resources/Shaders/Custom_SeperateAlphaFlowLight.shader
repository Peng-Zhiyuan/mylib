// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Seperate Alpha FlowLight"
{
	Properties
	{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "black" {}
		_Mask ("Mask", 2D) = "white" {}
		_LightTex ("Light", 2D) = "black" {}
		_Speed ("Speed", Float) = 0.5
		_Duration ("Duration", Float) = 4
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
			sampler2D _Mask;
			float4 _MainTex_ST;
			sampler2D _LightTex;
			float4 _LightTex_ST;
			fixed _Speed;
			fixed _Duration;
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
				o.uv_light = v.texcoord;
				o.uv_light.x -= fmod(_Time.y - _Delay, _Duration) * _Speed - 1;
				o.color = v.color;
				return o;
			}
				
			fixed4 frag (v2f IN) : COLOR
			{
				fixed4 c = tex2D(_MainTex, IN.uv_main) * IN.color;
				fixed4 l = tex2D(_LightTex, IN.uv_light);
				float4 Mask = tex2D(_Mask, IN.uv_main);
				c.a =Mask.r;
				c.rgb *= (l.r + 1);
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
			
			SetTexture[_MainTex]
			{
				combine texture
			}
   			SetTexture[_Mask] 
   			{
     			combine previous, texture
   			}
 	  		SetTexture[_Mask] 
	   		{
     			combine previous * primary
 	  		}
		}
	}
}
