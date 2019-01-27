Shader "Custom/Lava"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
		_TextureScaling("Texture Scaling", Range(0,1)) = 0.1
		_ScrollDirection("Scroll Direction", Vector) = (0,0,0,0)
		_Tess("Tesselation", Range(1, 32)) = 4
		_DispAmount("Displacement Amount", Range(0,1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert tessellate:tessFixed

        // Use shader model 3.0 target, to get nicer looking lighting
        //#pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
			float3 worldPos;
        };

        half _Glossiness;
        half _Metallic;
		half _TextureScaling;
		half4 _ScrollDirection;
		half _Tess;
		half _DispAmount;

		void vert(inout appdata_full v) 
		{
			half3 worldPos = mul(unity_ObjectToWorld, v.vertex);
			half2 UV = worldPos.xz * _TextureScaling + _ScrollDirection * _Time.x;
			half4 UVbigger = half4(UV.x, UV.y, 0, 4);
			fixed4 c = tex2Dlod(_MainTex, UVbigger);
			v.vertex.y += (1 - c.r) * _DispAmount;
		}

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

		float4 tessFixed()
		{
			return _Tess;
		}

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.worldPos.xz * _TextureScaling + _ScrollDirection * _Time.x);
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
			o.Emission = c.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
