#version 330 core

in vec3 fragmentColour;

out vec3 color;

void main()
{
	//color = vec3(0.18, 0.204, 0.212);
	color = fragmentColour;
}