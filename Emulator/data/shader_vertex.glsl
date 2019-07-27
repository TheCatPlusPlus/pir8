#version 460 core

layout(location = 0) in vec2 inPosition;
layout(location = 1) in vec2 inUV;
layout(location = 2) in vec4 inFgColor;
layout(location = 3) in vec4 inBgColor;

layout(location = 0) uniform mat4 mvp;

layout(location = 0) out vec2 outUV;
layout(location = 1) out vec4 outFgColor;
layout(location = 2) out vec4 outBgColor;

void main()
{
	outUV = inUV;
	outFgColor = inFgColor;
	outBgColor = inBgColor;
	gl_Position = mvp * vec4(inPosition, 0, 1);
}
