
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action ArchivoAction;

	private global::Gtk.Action AbrirAction;

	private global::Gtk.Action CosaAction;

	private global::Gtk.Action CosaAction1;

	private global::Gtk.Action MenuAction;

	private global::Gtk.VBox vbox3;

	private global::Gtk.MenuBar menubar3;

	private global::Gtk.GLWidget glwidget7;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.ArchivoAction = new global::Gtk.Action ("ArchivoAction", "Archivo", null, null);
		this.ArchivoAction.ShortLabel = "Archivo";
		w1.Add (this.ArchivoAction, null);
		this.AbrirAction = new global::Gtk.Action ("AbrirAction", "Abrir", null, null);
		this.AbrirAction.ShortLabel = "Abrir";
		w1.Add (this.AbrirAction, null);
		this.CosaAction = new global::Gtk.Action ("CosaAction", "Cosa", null, null);
		this.CosaAction.ShortLabel = "Cosa";
		w1.Add (this.CosaAction, null);
		this.CosaAction1 = new global::Gtk.Action ("CosaAction1", "Cosa", null, null);
		this.CosaAction1.ShortLabel = "Cosa";
		w1.Add (this.CosaAction1, null);
		this.MenuAction = new global::Gtk.Action ("MenuAction", "Menu", null, null);
		this.MenuAction.ShortLabel = "Cosa";
		w1.Add (this.MenuAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = "MainWindow";
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox3 = new global::Gtk.VBox ();
		this.vbox3.Name = "vbox3";
		// Container child vbox3.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar3'><menu name='MenuAction' action='MenuAction'/></menubar></ui>");
		this.menubar3 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar3")));
		this.menubar3.Name = "menubar3";
		this.vbox3.Add (this.menubar3);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.menubar3]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.glwidget7 = new global::Gtk.GLWidget ();
		this.glwidget7.WidthRequest = 800;
		this.glwidget7.HeightRequest = 600;
		this.glwidget7.Name = "glwidget7";
		this.glwidget7.SingleBuffer = false;
		this.glwidget7.ColorBPP = 24;
		this.glwidget7.AccumulatorBPP = 0;
		this.glwidget7.DepthBPP = 32;
		this.glwidget7.StencilBPP = 0;
		this.glwidget7.Samples = 4;
		this.glwidget7.Stereo = false;
		this.glwidget7.GlVersionMajor = 3;
		this.glwidget7.GlVersionMinor = 3;
		this.vbox3.Add (this.glwidget7);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.glwidget7]));
		w3.Position = 1;
		w3.Expand = false;
		w3.Fill = false;
		this.Add (this.vbox3);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 883;
		this.DefaultHeight = 709;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.glwidget7.Initialized += new global::System.EventHandler (this.GLWidgetInitialize);
	}
}
