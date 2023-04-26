 Shader "BabaHamood"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BaseColor("base color", Color) = (1,1,1,1)
        //_AmbientColor("amby", Color) = (1,1,1,1)
        //_DiffuseColor("diffusy", Color) = (1,1,1,1)
        _SpecularColor("Specular Color", Color) = (1,1,1,1)


        //_ScrollingSpeed ("scrolling speed", float) = 1
        _Glossiness("gloss", float) = 1.0
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
            // make fog work
            //#pragma multi_compile_fog

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 viewDir : TEXCOORD1;
                float2 uv : TEXCOORD0;
                float3 normal: NORMAL;
            };

            struct v2f
            {
                float3 worldNormal: NORMAL;
                float2 uv : TEXCOORD0;
                float3 viewDir : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            //float4 _MyColor;
            //float _ScrollingSpeed;
            //float4 _AmbientColor;
            //float4 _DiffuseColor;
            float4 _BaseColor;
            float4 _SpecularColor;
            float _Glossiness;

            /*float2 Rotate(float2 uv)
            {
                uv.x += _CosTime.w + _ScrollingSpeed;
                uv.y += _SinTime.w + _ScrollingSpeed;
                return uv;
            }*/

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.viewDir = WorldSpaceViewDir(v.vertex);
                //o.uv = Rotate(o.uv);

                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                float4 col = tex2D(_MainTex, i.uv);
                float3 normalizedNormal = normalize(i.worldNormal);

                //ambient light
				float4 ambientLight = _BaseColor * UNITY_LIGHTMODEL_AMBIENT;

                //diffuse lgiht
				float NdotL = max(dot(_WorldSpaceLightPos0, normalizedNormal), 0);
			    float4 diffuseLight = fixed4(_BaseColor.rgb * _LightColor0.rgb * NdotL, 1);
                NdotL = NdotL > 0 ? 1 : 0;

                //specular light
                float3 viewDir = normalize(i.viewDir);
                float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);
                float NdotH = dot(normalizedNormal, halfVector);

                float4 specularLight = _SpecularColor * pow(NdotH, _Glossiness * _Glossiness);

                float4 light = ambientLight + diffuseLight + specularLight;
                return light;

				//return fixed4(_BaseColor.rgb * NdotL,1);      
            }
            ENDCG
        }
    }
}