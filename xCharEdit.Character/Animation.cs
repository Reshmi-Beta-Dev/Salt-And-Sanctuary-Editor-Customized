using System.Collections.Generic;

namespace xCharEdit.Character;

public class Animation
{
	public string name;

	public List<KeyFrame> keyFrame;

	public Animation()
	{
		name = "";
		keyFrame = new List<KeyFrame>();
	}

	public Animation(Animation srcAnimation)
	{
		name = srcAnimation.name + " copy";
		keyFrame = new List<KeyFrame>();
		foreach (KeyFrame item in srcAnimation.keyFrame)
		{
			keyFrame.Add(new KeyFrame(item));
		}
	}
}
