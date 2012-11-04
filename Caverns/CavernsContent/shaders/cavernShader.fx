sampler s0;



uniform extern float Fear;
uniform extern float Anger;
uniform extern float Sadness;
uniform extern float Joy;
uniform extern float Disgust;
uniform extern float Supprise;    
uniform extern float2 PlayerPos;
uniform extern float2 SecondPos;

uniform extern float2 SecondaryPos;


float2 Viewport;
void SpriteVertexShader(inout float4 color    : COLOR0,
                       inout float2 texCoord : TEXCOORD0,
                       inout float4 position : POSITION0)
{
   // Half pixel offset for correct texel centering.
   position.xy -= 0.5;
   // Viewport adjustment.
   position.xy = position.xy / Viewport;
   position.xy *= float2(2, -2);
   position.xy -= float2(1, -1);
}

float4 PixelShaderFunction(float2 coords: TEXCOORD0, in float2 vPos: VPOS) : COLOR
{
	volatile float dist;
	volatile float dist0;

	float4 color = tex2D(s0, coords);  
	if(color.a != 0){

    //Distance based Monocroming for Supprise
	//First, we get the distance
	dist = distance(vPos,PlayerPos);
	dist = dist /(300 + 200 * Supprise);
	dist0 = distance(vPos,SecondPos);
	dist0 = dist0 /(50 + 800 * Supprise);
	color.r =  color.r - ( .3 - color.r ) * dist * dist0;
	color.g =  color.g - ( .3 - color.g ) * dist * dist0;
	color.b =  color.b - ( .3 - color.b ) * dist * dist0;

    
	
	//Fear,Disgust,Joy Mappings  
    color.b = color.b * Sadness;
	color.r = color.r * Disgust;
	color.g = color.g * Joy;
	//Fear Monochroming
	//First, we get the distance
	dist = distance(color.rgb,float3(0,0,0));
	color.r =  color.r + ( dist - color.r ) * Fear;
	color.g =  color.g + ( dist - color.g ) * Fear;
	color.b =  color.b + ( dist - color.b ) * Fear;

	//Anger Inverse Alpha (Things disappear as you get angry)
	color.a = color.a * ( 1 - Anger );
	//color.a = .1;
	//Alpha seems broke for now...
	//color.r = sin(vPos.x);
	//color.b = cos(vPos.y);
	//color.g = tan(vPos.x/vPos.y);

	}
	return color;
}
technique
{
    pass P0
    {
		VertexShader = compile vs_3_0 SpriteVertexShader();
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}