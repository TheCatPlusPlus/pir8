#version 460 core

layout(location = 0) in vec2 inUV;
layout(location = 1) in vec4 inFgColor;
layout(location = 2) in vec4 inBgColor;

layout(location = 1) uniform sampler2D texFont;

layout(location = 0) out vec4 outColor;

void main()
{
	float texColor = texture2D(texFont, inUV).r;
	vec4 outFgColor = inFgColor * texColor;
	vec4 outBgColor = inBgColor * (1.0f - texColor);

	outColor = outFgColor + outBgColor;
}
