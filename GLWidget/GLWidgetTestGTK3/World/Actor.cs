//
//  Actor.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2016 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using GLib;
using GLWidgetTestGTK3.Data;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GLWidgetTestGTK3.World
{
	public class Actor
	{
		public Transform Transform;
		private readonly Mesh Mesh;

		/// <summary>
		/// Creates a new instance of the <see cref="Actor"/> class.
		/// </summary>
		/// <param name="Mesh">The mesh bound to the actor.</param>
		public Actor(Mesh Mesh)
		{
			this.Mesh = Mesh;
			this.Transform = new Transform(new Vector3(0.0f, 0.0f, 0.0f));
		}

		/// <summary>
		/// Performs any arbitrary actions needed every frame, such as animations, texture manipulations or state
		/// updates.
		/// </summary>
		/// <param name="deltaTime">The time (in thousands of a second) taken to render the previous frame.</param>
		public void Tick(float deltaTime)
		{

		}

		/// <summary>
		/// Renders this actor within the current OpenGL context.
		/// </summary>
		/// <param name="ShaderProgramID">The ID of the currently active shader.</param>
		/// <param name="ViewMatrix">The camera view matrix, calulcated from the camera position.</param>
		/// <param name="ProjectionMatrix">The perspective projection currently in use.</param>
		public void Render(int ShaderProgramID, Matrix4 ViewMatrix, Matrix4 ProjectionMatrix)
        {
			// Enable the mesh vertex array
	        GL.BindBuffer(BufferTarget.ArrayBuffer, Mesh.VertexBufferID);

			GL.EnableVertexAttribArray(0);
	        GL.VertexAttribPointer(
            				0,
            				3,
            				VertexAttribPointerType.Float,
            				false,
            				0,
            				0);

	        // Enable the normal attributes
	        GL.EnableVertexAttribArray(3);
			GL.VertexAttribPointer(
							2,
							3,
							VertexAttribPointerType.Float,
							false,
							0,
							0);

	        Matrix4 modelTranslation = Matrix4.CreateTranslation(Transform.Translation);
	        Matrix4 modelScale = Matrix4.Scale(Transform.Scale);
	        Matrix4 modelRotation = Matrix4.Rotate(Transform.Rotation);

	        Matrix4 modelViewProjection = modelScale *  modelRotation * modelTranslation * ViewMatrix * ProjectionMatrix;

	        // Send the model matrix to the shader
	        int projectionShaderVariableHandle = GL.GetUniformLocation(ShaderProgramID, "ModelViewProjection");
	        GL.UniformMatrix4(projectionShaderVariableHandle, false, ref modelViewProjection);

	        // Draw the model
	        GL.DrawArrays(BeginMode.Triangles, 0, Mesh.GetVertexCount());

	        // Release the attribute arrays
	        GL.DisableVertexAttribArray(0);
	        GL.DisableVertexAttribArray(3);
        }
	}
}