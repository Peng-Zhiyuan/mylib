// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Seperate Alpha Colored Grey (SoftClip)" 
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
    	_Mask ("Mask", 2D) = "white" {}
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

		Cull Off
		Lighting Off
		ZWrite Off
		Offset -1, -1
		Fog { Mode Off }
		ColorMask RGB
		AlphaTest Greater .01
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _Mask;
			float4 _MainTex_ST;
			float2 _ClipSharpness = float2(20.0, 20.0);

			struct appdata_t
			{
				float4 vertex : POSITION;
				half4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : POSITION;
				half4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float2 worldPos : TEXCOORD1;
			};

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				o.texcoord = v.texcoord;
				o.worldPos = TRANSFORM_TEX(v.vertex.xy, _MainTex);
				return o;
			}

			half4 frag (v2f i) : COLOR
			{
				// Softness factor
				float2 factor = (float2(1.0, 1.0) - abs(i.worldPos)) * _ClipSharpness;
			
				// Sample the texture
				float4 MainTex = tex2D(_MainTex, i.texcoord);
         		float4 Mask = tex2D(_Mask, i.texcoord);
				float4 col = float4(MainTex.x, MainTex.y, MainTex.z, Mask.x);
				if((i.color.r==0)&&(i.color.b==1))
				{
					col *= float4 (i.color.g, i.color.g, i.color.g, i.color.a); 
					col.rgb=dot(col.rgb, float3(0.5, 0.4, 0.11));
				} 
				else
				{
					col *= i.color;
				}
				col.a *= clamp( min(factor.x, factor.y), 0.0, 1.0);		

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