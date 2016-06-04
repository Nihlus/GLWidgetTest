#version 330 core
layout(location = 0) in vec3 vertexPosition_modelSpace;
layout(location = 1) in vec3 vertexColour;

uniform mat4 MVP;

out vec3 fragmentColour;

void main()
{
	gl_Position = MVP * vec4(vertexPosition_modelSpace, 1.0);

	fragmentColour = vertexColour;
}