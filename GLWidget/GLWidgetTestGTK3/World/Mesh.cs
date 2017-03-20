//
//  Mesh.cs
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
using System.Collections.Generic;
using GLWidgetTestGTK3.Data;
using OpenTK.Graphics.OpenGL;

namespace GLWidgetTestGTK3.World
{
	public class Mesh
	{
		private List<Vertex> Vertices;

		private int vertexBufferID = -1;
		public int VertexBufferID
		{
			get { return vertexBufferID; }
		}

		private int normalBufferID = -1;
		public int NormalBufferID
		{
			get { return normalBufferID; }
		}

		private bool cullFaces;

		public bool CullFaces
		{
			get;
			set;
		}

		public Mesh(List<Vertex> Vertices)
		{
			this.Vertices = Vertices;

			this.vertexBufferID = UploadVertexPositions();
			this.normalBufferID = UploadVertexNormals();
		}

		public int GetVertexCount()
		{
			return Vertices.Count;
		}

		private int UploadVertexPositions()
		{
			if (vertexBufferID > 0)
			{
				return vertexBufferID;
			}

			// Generate a buffer
			GL.GenBuffers(1, out vertexBufferID);

			// Get the vertex positions
			float[] vertexPositions = GetVertexPositions();

			// Upload the vertices to the GPU
			GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferID);
			GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertexPositions.Length * sizeof(float)), vertexPositions, BufferUsageHint.StaticDraw);

			return vertexBufferID;
		}

		private int UploadVertexNormals()
		{
			if (normalBufferID > 0)
			{
				return normalBufferID;
			}

			// Generate a buffer
			GL.GenBuffers(1, out normalBufferID);

			// Get the vertex positions
			float[] vertexNormals = GetVertexNormals();

			// Upload the vertices to the GPU
			GL.BindBuffer(BufferTarget.ArrayBuffer, normalBufferID);
			GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertexNormals.Length * sizeof(float)), vertexNormals, BufferUsageHint.StaticDraw);

			return vertexBufferID;
		}

		private float[] GetVertexPositions()
		{
			List<float> vertexPositions = new List<float>();

			foreach (Vertex StoredVertex in Vertices)
			{
				vertexPositions.Add(StoredVertex.Position.X);
				vertexPositions.Add(StoredVertex.Position.Y);
				vertexPositions.Add(StoredVertex.Position.Z);
			}

			return vertexPositions.ToArray();
		}

		private float[] GetVertexNormals()
		{
			List<float> vertexNormals = new List<float>();

			foreach (Vertex StoredVertex in Vertices)
			{
				vertexNormals.Add(StoredVertex.Normal.X);
				vertexNormals.Add(StoredVertex.Normal.Y);
				vertexNormals.Add(StoredVertex.Normal.Z);
			}

			return vertexNormals.ToArray();
		}
	}
}