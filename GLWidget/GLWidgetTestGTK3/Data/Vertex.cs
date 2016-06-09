//
//  Vertex.cs
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

using OpenTK;

namespace GLWidgetTestGTK3.Data
{
	public sealed class Vertex
	{
		public Vector3 Position
		{
			get;
			private set;
		}

		public Vector3 Normal
		{
			get;
			private set;
		}

		public UVCoordinate UVCoordinate
		{
			get;
			private set;
		}

		public RGB VertexColour
		{
			get;
			private set;
		}

		public Vertex(Vector3 Position)
			:this(Position, Vector3.Zero, new UVCoordinate(0.0f, 0.0f), new RGB(1.0f, 1.0f, 1.0f))
		{
		}

		public Vertex(Vector3 Position, Vector3 Normal)
        			:this(Position, Normal, new UVCoordinate(0.0f, 0.0f), new RGB(1.0f, 1.0f, 1.0f))
		{
		}


		public Vertex(Vector3 Position, RGB VertexColour)
			:this(Position, Vector3.Zero, new UVCoordinate(0.0f, 0.0f), VertexColour)
		{
		}

		public Vertex(Vector3 Position, Vector3 Normal, RGB VertexColour)
        			:this(Position, Normal, new UVCoordinate(0.0f, 0.0f), VertexColour)
		{
		}

		public Vertex(Vector3 Position, UVCoordinate UVCoordinate)
			:this(Position, Vector3.Zero, UVCoordinate, new RGB(1.0f, 1.0f, 1.0f))
		{
		}

		public Vertex(Vector3 Position, Vector3 Normal, UVCoordinate UVCoordinate)
        			:this(Position, Normal, UVCoordinate, new RGB(1.0f, 1.0f, 1.0f))
		{
		}

		public Vertex(Vector3 Position, Vector3 Normal, UVCoordinate UVCoordinate, RGB VertexColour)
		{
			this.Position = Position;
			this.Normal = Normal;
			this.UVCoordinate = UVCoordinate;
			this.VertexColour = VertexColour;
		}
	}
}