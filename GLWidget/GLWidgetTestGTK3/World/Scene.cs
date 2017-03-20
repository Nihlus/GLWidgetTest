//
//  Scene.cs
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
using OpenTK.Graphics.OpenGL;

namespace GLWidgetTestGTK3.World
{
	public class Scene
	{
		public readonly List<Actor> Actors = new List<Actor>();

		private readonly int vertexArrayID = -1;
		public int VertexArrayID
		{
			get { return vertexArrayID; }
		}

		public Scene()
		{
			// Generate the vertex array
			GL.GenVertexArrays(1, out vertexArrayID);
			GL.BindVertexArray(VertexArrayID);
		}

		/// <summary>
		/// Runs the <see cref="Actor.Tick"/> function on all <see cref="Actor"/> instances
		/// in the scene. Actors can define arbitrary behaviour in their ticks, but in most
		/// cases it's used for animation.
		/// </summary>
		/// <param name="deltaTime">The time (in thousands of a second) taken to render the previous frame.</param>
		public void Tick(float deltaTime)
		{
			for (int i = 0; i < Actors.Count; ++i)
			{
				Actors[i].Tick(deltaTime);
			}
		}
	}
}