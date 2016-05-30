//
//  EmptyClass.cs
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
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace GLWidgetTestGTK3
{
	public partial class MainWindow : Gtk.Window
	{
		[UI] Box MainBox;
		[UI] MenuBar MainMenuBar;

		[UI] Alignment GLWidgetAlignment;

		[UI] GLWidget MainGLWidget;

		private bool GLInit;

		public static MainWindow Create()
		{
			Builder builder = new Builder(null, "GLWidgetTestGTK3.interfaces.MainWindow.glade", null);
			return new MainWindow(builder, builder.GetObject("MainWindow").Handle);
		}

		protected MainWindow(Builder builder, IntPtr handle)
			: base(handle)
		{
			builder.Autoconnect(this);
			DeleteEvent += OnDeleteEvent;

			this.GLInit = false;


			this.MainGLWidget = new GLWidget(GraphicsMode.Default, 3, 0, GraphicsContextFlags.Default);
			this.MainGLWidget.Initialized += OnGLWidgetInitialized;

			// Add the GL widget to the UI
			this.GLWidgetAlignment.Add(this.MainGLWidget);
			this.GLWidgetAlignment.ShowAll();

		}

		protected virtual void OnGLWidgetInitialized(object sender, EventArgs e)
		{			
			int WidgetWidth = this.GLWidgetAlignment.AllocatedWidth;
			int WidgetHeight = this.GLWidgetAlignment.AllocatedHeight;

			GL.Viewport(0, 0, WidgetWidth, WidgetHeight);
		
			GL.ClearColor(0.522f, 0.573f, 0.678f, 1.0f);
			GL.Clear(ClearBufferMask.ColorBufferBit);
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadIdentity();
			GL.ShadeModel(ShadingModel.Smooth);	

			float aspectRatio = (float)WidgetWidth / (float)WidgetHeight;
			Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, aspectRatio, 1.0f, 64.0f);
			GL.MatrixMode(MatrixMode.Projection);				
			GL.LoadMatrix(ref projection);
					
			GL.ClearDepth(1);	           
			GL.Disable(EnableCap.DepthTest);	
			GL.Enable(EnableCap.Texture2D); 
			GL.Enable(EnableCap.Blend);
			GL.DepthFunc(DepthFunction.Always);		
			GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest); 

			//add idle event handler to process rendering whenever and as long as time is availble.
			GLInit = true;
			GLib.Idle.Add(new GLib.IdleHandler(OnIdleProcessMain));
		}

		protected void RenderFrame()
		{			
			int WidgetWidth = this.GLWidgetAlignment.AllocatedWidth;
			int WidgetHeight = this.GLWidgetAlignment.AllocatedHeight;

			GL.Viewport(0, 0, WidgetWidth, WidgetHeight);

			float aspectRatio = (float)WidgetWidth / (float)WidgetHeight; 		
			Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, aspectRatio, 1.0f, 64.0f);
			GL.MatrixMode(MatrixMode.Projection);				
			GL.LoadMatrix(ref projection);

			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadMatrix(ref modelview);	
		
			GL.Begin(BeginMode.Triangles);

			GL.Color3(1.0f, 0.0f, 0.0f);
			GL.Vertex3(-1.0f, -1.0f, 4.0f);
			GL.Color3(0.0f, 1.0f, 0.0f);
			GL.Vertex3(1.0f, -1.0f, 4.0f);
			GL.Color3(0.0f, 0.0f, 1.0f);
			GL.Vertex3(0.0f, 1.0f, 4.0f);
			GL.End();
		
			GraphicsContext.CurrentContext.SwapBuffers();
		
		}

		protected bool OnIdleProcessMain()
		{
			if (!GLInit)
				return false;
			else
			{
				RenderFrame();
				return true;
			}
		}

		/// <summary>
		/// Handles application shutdown procedures - terminating render threads, cleaning
		/// up the UI, etc.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="a">The alpha component.</param>
		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}
	}
}

