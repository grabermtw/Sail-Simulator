Shader "Custom/WolframShader" {

	Properties {
		// Standard Properties
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

		// Custom Grid Properties
		[MaterialToggle] _GridLines("GridLines", Float) = 1
		[MaterialToggle] _GridX("X", Float) = 1
		[MaterialToggle] _GridY("Y", Float) = 1
		[MaterialToggle] _GridZ("Z", Float) = 1
      	_GridThickness ("Grid Thickness", Float) = 0.01
      	_GridSpacing ("Grid Spacing", Float) = 10.0
      	_GridColor ("Grid Color", Color) = (0.0, 0.0, 0.0, 1.0)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }

		LOD 200

		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Custom fullforwardshadows
		#include "UnityPBSLighting.cginc"

        // Access Shaderlab Properties
        sampler2D _MainTex;
        half _Glossiness;
		half _Metallic;
		fixed4 _Color;
        uniform float _GridLines;
        uniform float _GridX;
		uniform float _GridY;
	 	uniform float _GridZ;
        uniform float _GridThickness;
        uniform float _GridSpacing;
        uniform float4 _GridColor;

        // Local Variables
        int isGridLine;


		inline half4 LightingCustom(SurfaceOutputStandard s, half3 lightDir, UnityGI gi) {
			if (isGridLine) {
				return _GridColor;
			}
			else {
				return LightingStandard(s, lightDir, gi);
			}
		}

		inline void LightingCustom_GI(SurfaceOutputStandard s, UnityGIInput data, inout UnityGI gi) {
			LightingStandard_GI(s, data, gi);		
		}

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {

			if (_GridLines) {

				float3 localPos = IN.worldPos -  mul(unity_ObjectToWorld, float4(0,0,0,1)).xyz;

				if (_GridX && frac(localPos.x/_GridSpacing) < _GridThickness) {
					isGridLine = 1;
				}
				else if (_GridY && frac(localPos.y/_GridSpacing) < _GridThickness) {
					isGridLine = 1;
				}
				else if (_GridZ && frac(localPos.z/_GridSpacing) < _GridThickness) {
					isGridLine = 1;
				}
				else {
					isGridLine = 0;
				}

	          	if (isGridLine) {
	          		o.Albedo = _GridColor.rgb;
					o.Alpha  = _GridColor.a;
	          	}
	          	else {
	          		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
					o.Albedo = c.rgb;
					o.Alpha  = c.a;
	          	}
			}
			else {
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				o.Alpha  = c.a;
			}

          	o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;

		}

		ENDCG
		
	}

	FallBack "Diffuse"
}

