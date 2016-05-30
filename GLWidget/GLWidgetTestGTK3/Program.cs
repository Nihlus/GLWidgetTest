using System;
using Gtk;
using OpenTK;

namespace GLWidgetTestGTK3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			// OpenGL
			Toolkit.Init();

			// GTK
			Application.Init();
			MainWindow win = MainWindow.Create();
			win.Show();
			Application.Run();
		}
	}
}