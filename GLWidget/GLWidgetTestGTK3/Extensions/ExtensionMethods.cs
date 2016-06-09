//
//  ExtensionMethods.cs
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

namespace GLWidgetTestGTK3.Extensions
{
	public static class ExtensionMethods
	{
		public static Quaternion QuaternionFromEuler(float Yaw, float Pitch, float Roll)
		{
			Quaternion XRotation = Quaternion.FromAxisAngle(Vector3.UnitX, Yaw);
			Quaternion YRotation = Quaternion.FromAxisAngle(Vector3.UnitY, Pitch);
			Quaternion ZRotation = Quaternion.FromAxisAngle(Vector3.UnitZ, Roll);

			Quaternion final = Quaternion.Multiply(ZRotation, YRotation);
			final = Quaternion.Multiply(XRotation, final);

			return final;
		}
	}
}