// ${CHAR:Enter}
// ${SMART_INDENT_ON_ENTER:true} 
Shader "Sprites/Default-Hue"
{
    SubShader
    {
        Pass
        {
            CGPROGRAM            

                // additional empty line above^
                #pragma multi_compile BAR{caret}
            
                float3 hsv2rgb(float3 c)
                {
                    return c;                
                }
            ENDCG
        }
    }
}