// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Seperate Alpha Colored" 
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
    	_Mask ("Mask", 2D) = "white" {}
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
		
		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		Offset -1, -1
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				
				#include "UnityCG.cginc"
	
				struct appdata_t
				{
					float4 vertex : POSITION;
					float2 texcoord : TEXCOORD0;
					fixed4 color : COLOR;
				};
	
				struct v2f
				{
					float4 vertex : SV_POSITION;
					half2 texcoord : TEXCOORD0;
					fixed4 color : COLOR;
				};
	
        		sampler2D _MainTex;
        		sampler2D _Mask;
				float4 _MainTex_ST;
				
				v2f vert (appdata_t v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
					o.color = v.color;
					return o;
				}
				
				fixed4 frag (v2f i) : COLOR
				{
					float4 MainTex = tex2D(_MainTex, i.texcoord);
         			float4 Mask = tex2D(_Mask, i.texcoord);
					//fixed4 col = tex2D(_MainTex, i.texcoord);
					float4 col = float4(MainTex.x, MainTex.y, MainTex.z, Mask.x);
					col *= i.color;
					return col;
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

		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		Offset -1, -1
		ColorMask RGB
		AlphaTest Greater .01
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMaterial AmbientAndDiffuse

		Pass
		{
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
