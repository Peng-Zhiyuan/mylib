// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "UI/Gray Transparent Colored"
{
	Properties
	{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "black" {}
		
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
		
		_ColorMask ("Color Mask", Float) = 15
		
		_Desaturate ("_Desaturate", range(0,1)) = 1
		_Brightness ("_Brightness", range(0.5, 1.5)) = 1
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
		
		Stencil
		{
			Ref [_Stencil]
			Comp [_StencilComp]
			Pass [_StencilOp]
			ReadMask [_StencilReadMask]
			WriteMask [_StencilWriteMask]
		}
		
		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		Offset -1, -1
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask [_ColorMask]
		
		Pass
		{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile _ALPHATEX_OFF _ALPHATEX_ON
				
				#include "UnityCG.cginc"
	
				struct appdata_t
				{
					float4 vertex : POSITION;
					float2 texcoord : TEXCOORD0;
				#if _ALPHATEX_ON
					float2 texcoord2 : TEXCOORD1;
				#endif
					half4 color : COLOR;
				};
	
				struct v2f
				{
					float4 vertex : SV_POSITION;
					half3 texcoord : TEXCOORD0;
				#if _ALPHATEX_ON
					half2 texcoord2 : TEXCOORD1;
				#endif
					fixed4 color : COLOR;
				};
	
				sampler2D _MainTex;
				float4 _MainTex_ST;
				
				fixed _Desaturate;
				fixed _Brightness;
				
				v2f vert (appdata_t v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.texcoord.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
					o.texcoord.z = min(v.color.r * 255, 1);
				#if _ALPHATEX_ON
					o.texcoord2 = TRANSFORM_TEX(v.texcoord2, _MainTex);
				#endif
					o.color.rgb = lerp(float3(1,1,1), v.color.rgb, o.texcoord.z);
					o.color.a = v.color.a;
					return o;
				}
				
				fixed4 frag (v2f i) : COLOR
				{
					fixed4 c0 = tex2D(_MainTex, i.texcoord.xy);
				#if _ALPHATEX_ON
					c0.a = tex2D(_MainTex, i.texcoord2).r;
				#endif
					fixed4 c1 = c0 * i.color;
					
					fixed gray = dot(c0.rgb, float3(0.299, 0.587, 0.114));
					fixed3 c3 = lerp(c1.rgb, fixed3(gray, gray, gray), _Desaturate) * _Brightness;
					
					fixed3 c2 = lerp(c3.rgb, c1.rgb, i.texcoord.z);
					return fixed4(c2, c1.a);
				}
			ENDCG
		}
	}


}
