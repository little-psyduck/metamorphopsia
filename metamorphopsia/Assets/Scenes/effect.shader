Shader "2D/Texture Blend"
{
    Properties
    {
       _MainTex("Sprite Texture", 2D) = "white" {}
       _Color("Alpha Color Key", Color) = (0,0,0,1)
       _Range("Range",Range(0,1.01)) = 0.5
    }
        SubShader
       {
           Tags
           {
               "RenderType" = "Transparent"
               "Queue" = "Transparent"
               "PreviewType" = "plane"
           }

           Pass
           {
               Cull Off
               ZWrite Off
               Blend SrcAlpha OneMinusSrcAlpha

               CGPROGRAM
               #pragma vertex vert
               #pragma fragment frag
               #pragma multi_compile DUMMY PIXELSNAP_ON

               sampler2D _MainTex;
               float4 _Color;
               float _Range;

               struct Vertex
               {
                   float4 vertex : POSITION;
                   float2 uv_MainTex : TEXCOORD0;
               };

               struct Fragment
               {
                   float4 vertex : POSITION;
                   float2 uv_MainTex : TEXCOORD0;
               };

               Fragment vert(Vertex v)
               {
                   Fragment o;

                   o.vertex = UnityObjectToClipPos(v.vertex);
                   o.uv_MainTex = v.uv_MainTex;

                   return o;
               }
               ///////////////////////

               uniform float2 centre;
               uniform float radius;

               float4 frag(Fragment IN) : COLOR
               {
                   float2 relevent_position = IN.uv_MainTex - centre;
                   float distFromCenter = length(relevent_position);
                   distFromCenter /= radius;

                   o.Color(1.0, 1.0, 1.0, 1.0);
                   //
                   half4 c = tex2D(_MainTex, IN.uv_MainTex);
                   o.rgb = c.rgb;

                   if (c.r >= _Range && c.g >= _Range && c.b >= _Range)
                   {
                       o.a = 0;
                   }
                   else
                   {
                       o.a = 1;
                   }

                   return o;
               }

               ENDCG
           }
       }
}