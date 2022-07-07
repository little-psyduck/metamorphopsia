Shader "Sample/SampleShader"
{
    Properties
    {
        _MainTex ("Background Texture", 2D) = "white" {}
        _Color ("Background Color", Color) = (1,1,1,1)
        [Toggle(_False)]
        _ShowTexture("Use Texture", float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct Attribute
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Fragment
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            uniform float4 _Color;
            bool _ShowTexture;

            Fragment vert (Attribute input)
            {
                Fragment output;
                output.vertex = UnityObjectToClipPos(input.vertex);
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                return output;
            }

            float4 frag (Fragment fragment) : SV_Target
            {
                float4 frag_color;

                if (_ShowTexture == true)
                    frag_color = tex2D(_MainTex, fragment.uv);
                else
                    frag_color = _Color;

                return frag_color;
            }
            ENDCG
        }
    }
}
