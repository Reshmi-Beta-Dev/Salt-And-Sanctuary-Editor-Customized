using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MapEdit.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("MapEdit.Properties.Resources", typeof(Resources).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap _new => (Bitmap)ResourceManager.GetObject("_new", resourceCulture);

	internal static Bitmap copy => (Bitmap)ResourceManager.GetObject("copy", resourceCulture);

	internal static Bitmap down2 => (Bitmap)ResourceManager.GetObject("down2", resourceCulture);

	internal static Bitmap down2x => (Bitmap)ResourceManager.GetObject("down2x", resourceCulture);

	internal static Bitmap up => (Bitmap)ResourceManager.GetObject("up", resourceCulture);

	internal static Bitmap upx => (Bitmap)ResourceManager.GetObject("upx", resourceCulture);

	internal static Bitmap x => (Bitmap)ResourceManager.GetObject("x", resourceCulture);

	internal Resources()
	{
	}
}
