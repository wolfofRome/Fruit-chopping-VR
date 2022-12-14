Shader "Custom/My3DText"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Font Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector" = "True" "RenderType"="Transparent" }
        Lighting Off Cull Off ZWrite Off Fog { Mode Off }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass{
            Color [_Color]
            SetTexture [_MainTex] {
                combine primary, texture * primary
            }
        }
    }
}
