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

               uniform float2 centre_shape;
               uniform float2 centre_gather;
               uniform float radius;
               uniform float extent;

               float4 frag(Fragment IN) : COLOR
               {
                   float2 relevent_position = IN.uv_MainTex- centre_shape;
                   float2 gather_pos = IN.uv_MainTex - centre_gather;

                   float distFromCenter = distance(IN.uv_MainTex, centre_shape);
                   float2 offset = normalize(gather_pos) * abs(distFromCenter - radius) * extent;

                   if (distFromCenter <= radius)
                       relevent_position = relevent_position + offset;

                   half4 c = tex2D(_MainTex, relevent_position+ centre_shape);

                   if (distFromCenter <= radius) {
                       if (c.r >= _Range && c.g >= _Range && c.b >= _Range)
                           c.a = 0;
                   }

                   return c;
               }

               ENDCG
           }
       }
}