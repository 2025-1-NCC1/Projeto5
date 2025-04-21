Shader "Unlit/Skybox_shader"
{
    Properties
    {
        _Cubemap1 ("Cubemap Day", CUBE) = "" {}
        _Cubemap2 ("Cubemap Night", CUBE) = "" {}
        _Blend ("Blend", Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "Queue" = "Background" }
        Cull Off
        Lighting Off
        ZWrite Off
        Fog { Mode Off }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            samplerCUBE _Cubemap1;
            samplerCUBE _Cubemap2;
            float _Blend;

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 texcoord : TEXCOORD0;
            };

            v2f vert (float3 v : POSITION)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v);
                o.texcoord = v;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                half4 col1 = texCUBE(_Cubemap1, i.texcoord);
                half4 col2 = texCUBE(_Cubemap2, i.texcoord);
                return lerp(col1, col2, _Blend);
            }
            ENDCG
        }
    }
    FallBack "RenderFX/Skybox"
}
