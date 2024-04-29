Shader "Custom/blur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurStrength ("Blur Strength", Range(0, 10)) = 1.0
        
        _TimeSpeed ("Time Speed", Float) = 1.0 // ʱ���ٶȲ���
   
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        // �����ﶨ����Ⱦģ�͵���ɫ����
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            // ����Unity�ṩ����ɫ��
            #include "UnityCG.cginc"

            // ���ݴӶ�����ɫ����Ƭ����ɫ���Ľṹ��
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            // ��׼������ɫ��
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // ��׼Ƭ����ɫ����ʵ���������Ҹ�˹ģ��
            sampler2D _MainTex;
            float _BlurStrength;
            float _BlurTime;


            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = fixed4(0, 0, 0, 0);
                float blurSize = _BlurStrength * 0.005*_BlurTime*0.1;

                for(int x = -4; x <= 4; x++)
                {
                    for(int y = -4; y <= 4; y++)
                    {
                        float2 offset = float2(x, y) * blurSize;
                        col += tex2D(_MainTex, i.uv + offset);
                    }
                }

                col /= 81; // ģ���˵Ĵ�С�������� 9x9 �ĺ�

                // ��ģ��Ч����ʱ��䰵
                col *= (1.0 - (_BlurTime * 0.02)); // ʹ��ʱ���������ģ��Ч��

                return col;
            }
            ENDCG
        }
    }
}