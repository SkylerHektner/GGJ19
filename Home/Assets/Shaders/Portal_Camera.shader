Shader "Unlit/Portal_Camera"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_SecondaryTex("Secondary Tex", 2D) = "white" {}
		_RefractionTex("Refraction Tex", 2D) = "white" {}
		_ReplaceColor("Replace Color", Color) = (0,0,0,0)
		_StartingOffset("Starting Offset", Vector) = (0,0,0,0)
		_ScrollSpeed("Texture Scroll Speed", Range(0.2, 4)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
			sampler2D _SecondaryTex;
			sampler2D _RefractionTex;
			float4 _ReplaceColor;
			half4 _StartingOffset;
			float _ScrollSpeed;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float4 col = tex2D(_MainTex, i.uv);
				if (abs(col.x - _ReplaceColor.x) < 0.01 && abs(col.y - _ReplaceColor.y) < 0.01 && abs(col.z - _ReplaceColor.z) < 0.01)
				{
					half2 newUV = i.uv + half2(_Time.x, _Time.x) * _ScrollSpeed + _StartingOffset.xy;
					fixed4 sampleCol = tex2D(_RefractionTex, newUV);
					newUV = i.uv * .5 + half2(-_Time.x * .7, -_Time.x * .8) * _ScrollSpeed + _StartingOffset.xy;
					sampleCol *= tex2D(_RefractionTex, newUV);
					newUV = i.uv * 1.2 + half2(_Time.x * 1.9, -_Time.x * 1.2) * _ScrollSpeed + _StartingOffset.xy;
					sampleCol *= tex2D(_RefractionTex, newUV);
					newUV = i.uv * 1.6 + half2(-_Time.x * 4.5, _Time.x * .3) * _ScrollSpeed + _StartingOffset.xy;
					sampleCol *= tex2D(_RefractionTex, newUV);

					col = tex2D(_SecondaryTex, i.uv + sampleCol.xy * 0.05);
				}
                return col;
            }
            ENDCG
        }
    }
}
