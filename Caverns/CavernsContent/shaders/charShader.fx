sampler s0;



uniform extern float Fear;
uniform extern float Anger;
uniform extern int PlayerHit;

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

		//Fear Monochroming
		//First, we get the distance
		dist = distance(color.rgb,float3(0,0,0));
		color.rgb =  color.rgb + ( dist - color.rgb ) * Fear;
		//color.g =  color.g + ( dist - color.g ) * Fear;
		//color.b =  color.b + ( dist - color.b ) * Fear;

		//Anger Inverse Alpha (Things disappear as you get angry)
		color.a = color.a * ( 1 - Anger );
		//color.a = .1;
		//Alpha seems broke for now...
		//color.r = sin(vPos.x);
		//color.b = cos(vPos.y);
		if(PlayerHit > 0)
			color.r = 1;
		color.r = 1;

	}
	//color.rgb = 1;
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