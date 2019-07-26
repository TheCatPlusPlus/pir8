#version 460 core

layout(location = 0) in vec2 inUV;
layout(location = 1) in vec4 inColor;

layout(location = 1) uniform sampler2D texFont;

layout(location = 0) out vec4 outColor;

void main()
{
	outColor = texture2D(texFont, inUV) * inColor;
}
