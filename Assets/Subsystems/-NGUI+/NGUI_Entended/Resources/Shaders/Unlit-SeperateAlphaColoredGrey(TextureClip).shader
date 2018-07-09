// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Community contribution: http://www.tasharen.com/forum/index.php?topic=9268.0
Shader "Hidden/Unlit/Seperate Alpha Colored Grey (TextureClip)"
{
	Properties
	{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "black" {}
		_Mask ("Mask", 2D) = "white" {}
		_Effect ("Effect", Float) = 0
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
			Offset -1, -1
			Fog { Mode Off }
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _Mask;
			sampler2D _ClipTex;
			float4 _ClipRange0 = float4(0.0, 0.0, 1.0, 1.0);
			fixed _Effect;

			struct appdata_t
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				half4 color : COLOR;
			};

			struct v2f
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				float2 clipUV : TEXCOORD1;
				half4 color : COLOR;
			};

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				o.texcoord = v.texcoord;
				o.clipUV = (v.vertex.xy * _ClipRange0.zw + _ClipRange0.xy) * 0.5 + float2(0.5, 0.5);
				return o;
			}

			half4 frag (v2f IN) : COLOR
			{
				float4 MainTex = tex2D(_MainTex, IN.texcoord);
     			float4 Mask = tex2D(_Mask, IN.texcoord);
				float4 col = float4(MainTex.x, MainTex.y, MainTex.z, Mask.x);
			
				if((IN.color.r==0)&&(IN.color.b==1))
				{
					col *= float4 (IN.color.g, IN.color.g, IN.color.g, IN.color.a); 
					col.rgb=dot(col.rgb, float3(0.5, 0.4, 0.11));
				}
				else 	col *= IN.color;
				
				float alphaDiff = col.a * tex2D(_ClipTex, IN.clipUV).a - col.a;
				float effectValue = _Effect * alphaDiff;
				col.a += effectValue;
				return col;
			}
			ENDCG
		}
	}
	Fallback "Unlit/Transparent Colored"
}
