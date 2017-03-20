using System;
using Gtk;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

public partial class MainWindow : Gtk.Window
{

	public bool GLinit;

	public MainWindow()
		: base(Gtk.WindowType.Toplevel)
	{
		Build();
		GLinit = false;
	}

	protected virtual void GLWidgetInitialize(object sender, EventArgs e)
	{
		//gl

		Requisition size = this.glwidget7.SizeRequest();
		GL.Viewport(0, 0, size.Width, size.Height);

		GL.ClearColor(0.522f, 0.573f, 0.678f, 1.0f);
		GL.Clear(ClearBufferMask.ColorBufferBit);
		GL.MatrixMode(MatrixMode.Modelview);
		GL.LoadIdentity();
		GL.ShadeModel(ShadingModel.Smooth);

		float aspectRatio = (float)size.Width / (float)size.Height;
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
		GLinit = true;
		GLib.Idle.Add(new GLib.IdleHandler(OnIdleProcessMain));
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}


	protected void RenderFrame()
	{
		Requisition size = this.glwidget7.SizeRequest();
		GL.Viewport(0, 0, size.Width, size.Height);

		float aspectRatio = (float)size.Width / (float)size.Height;
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
		if (!GLinit)
			return false;
		else
		{
			RenderFrame();
			return true;
		}
	}

}
