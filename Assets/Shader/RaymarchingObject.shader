Shader "Custom/RaymarchingMaterial"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _RaymarchingTex ("Raymarching Texture", 2D) = "white" { }
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        Pass
        {
            Name"ForwardBase"
            Tags { "LightMode" = "ForwardBase" }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            // Eingabe-Variablen
            samplers2D _MainTex;
            samplers2D _RaymarchingTex;

            // Shader-Programmfunktionen
            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.vertex.xy * 0.5 + 0.5; // UVs von der Position ableiten
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                half4 raymarchingColor = tex2D(_RaymarchingTex, i.uv); // Raymarching-Textur abfragen
                return raymarchingColor;
            }

            ENDCG
        }
    }
}
