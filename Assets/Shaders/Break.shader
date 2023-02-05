Shader "Custom/Break" {
   Properties {
       _MainTex ("Texture", 2D) = "white" {}
       _BreakAmount ("Break Amount", Range(0, 1)) = 0.5
   }

   SubShader {
       Tags {"Queue"="Transparent" "RenderType"="Transparent"}
       LOD 100

       Pass {
           CGPROGRAM
           #pragma vertex vert
           #pragma fragment frag
           #include "UnityCG.cginc"

           struct appdata {
               float4 vertex : POSITION;
               float2 uv : TEXCOORD0;
           };

           struct v2f {
               float2 uv : TEXCOORD0;
               float4 vertex : SV_POSITION;
           };

           sampler2D _MainTex;
           float _BreakAmount;

           v2f vert (appdata v) {
               v2f o;
               o.vertex = UnityObjectToClipPos(v.vertex);
               o.uv = v.uv;
               return o;
           }

           float4 frag (v2f i) : SV_Target {
               float4 col = tex2D(_MainTex, i.uv);
               col.a *= step(_BreakAmount, i.uv.y);
               return col;
           }
           ENDCG
       }
   }
   FallBack "Diffuse"
}