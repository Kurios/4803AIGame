//-----------------------------------------------------------------------------
// The Pixel Shader
//-----------------------------------------------------------------------------

//------------------------------------------------------
//--                                                  --
//--		   www.riemers.net                    --
//--   		    Basic shaders                     --
//--		Use/modify as you like                --
//--                                                  --
//------------------------------------------------------

struct VertexToPixel
{
    float4 Position   	: POSITION;    
    float4 Color		: COLOR0;
    float LightingFactor: TEXCOORD1;
    float2 TextureCoords: TEXCOORD0;
};

struct PixelToFrame
{
    float4 Color : COLOR0;
};

//------- Constants --------
float4x4 xView;
float4x4 xProjection;
float4x4 xWorld;
float3 xLightDirection;
float xAmbient;
bool xEnableLighting;
//bool xShowNormals;
//float3 xCamPos;
//float3 xCamUp;
//float xPointSpriteSize;

//------- Texture Samplers --------

Texture xTexture;
sampler TextureSampler = sampler_state { 
	texture = <xTexture>; 
	magfilter = LINEAR; 
	minfilter = LINEAR; 
	mipfilter=LINEAR; 
	AddressU = mirror; 
	AddressV = mirror;
};

Texture xTexture1;
sampler AmbientSampler = sampler_state { 
	texture = <xTexture1>; 
	magfilter = LINEAR; 
	minfilter = LINEAR; 
	mipfilter=LINEAR; 
	AddressU = mirror; 
	AddressV = mirror;
};


//------- Technique: Textured --------

VertexToPixel TexturedVS( float4 inPos : POSITION, float3 inNormal: NORMAL, float2 inTexCoords: TEXCOORD0)
{	
	VertexToPixel Output = (VertexToPixel)0;
	float4x4 preViewProjection = mul (xView, xProjection);
	float4x4 preWorldViewProjection = mul (xWorld, preViewProjection);
    
	Output.Position = mul(inPos, preWorldViewProjection);	
	Output.TextureCoords = inTexCoords;
	
	float3 Normal = normalize(mul(normalize(inNormal), xWorld));	
	Output.LightingFactor = 1;
	if (xEnableLighting)
		Output.LightingFactor = dot(Normal, -xLightDirection);
    
	return Output;    
}

PixelToFrame TexturedPS(VertexToPixel PSIn) 
{
	PixelToFrame Output = (PixelToFrame)0;		
	
	Output.Color = tex2D(TextureSampler, PSIn.TextureCoords);
	Output.Color.rgb *= saturate(PSIn.LightingFactor) + xAmbient;

	return Output;
}

technique Textured
{
	pass Pass0
	{   
		VertexShader = compile vs_2_0 TexturedVS();
		PixelShader  = compile ps_2_0 TexturedPS();
	}
}

//------- Technique: TexturedNoShading --------

VertexToPixel TexturedNoShadingVS( float4 inPos : POSITION, float3 inNormal: NORMAL, float2 inTexCoords: TEXCOORD0)
{	
	VertexToPixel Output = (VertexToPixel)0;
	float4x4 preViewProjection = mul (xView, xProjection);
	float4x4 preWorldViewProjection = mul (xWorld, preViewProjection);
    
	Output.Position = mul(inPos, preWorldViewProjection);	
	Output.TextureCoords = inTexCoords;
    
	return Output;    
}

PixelToFrame TexturedNoShadingPS(VertexToPixel PSIn) 
{
	PixelToFrame Output = (PixelToFrame)0;		
	
	Output.Color = tex2D(TextureSampler, PSIn.TextureCoords);

	return Output;
}

technique TexturedNoShading
{
	pass Pass0
	{   
		VertexShader = compile vs_2_0 TexturedNoShadingVS();
		PixelShader  = compile ps_2_0 TexturedNoShadingPS();
	}
}

//------- Technique: RenderSomething --------

VertexToPixel RenderSomethingVS( float4 inPos : POSITION, float3 inNormal: NORMAL, float2 inTexCoords: TEXCOORD0)
{	
	VertexToPixel Output = (VertexToPixel)0;
	float4x4 preViewProjection = mul (xView, xProjection);
	float4x4 preWorldViewProjection = mul (xWorld, preViewProjection);
    
	Output.Position = mul(inPos, preWorldViewProjection);	
	Output.TextureCoords = inTexCoords;
    
	return Output;    
}

PixelToFrame RenderSomethingPS(VertexToPixel PSIn) 
{
	PixelToFrame Output = (PixelToFrame)0;		
	
	Output.Color = float4(1,1,1,1);

	return Output;
}

technique RenderSomething
{
	pass Pass0
	{   
		VertexShader = compile vs_2_0 RenderSomethingVS();
		PixelShader  = compile ps_2_0 RenderSomethingPS();
	}
}
