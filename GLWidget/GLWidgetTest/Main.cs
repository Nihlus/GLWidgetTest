using System;
using Gtk;
using OpenTK;

namespace GLWidgetTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			// OpenGL
			Toolkit.Init(new ToolkitOptions
			{
				Backend = PlatformBackend.PreferNative,
				EnableHighResolution = true
			});

			Application.Init();
			MainWindow win = new MainWindow();
			win.Show();
			Application.Run();
		}
	}
}