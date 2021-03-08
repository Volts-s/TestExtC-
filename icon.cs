using Godot;
using System;
using Newtonsoft.Json;
using Ink.Runtime;

public class icon : Sprite
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello from C#");

		var demo = new DemoClass()
		{
			FirstName = "second",
			LastName = "Last"
		};
		var json = JsonConvert.SerializeObject(demo, Formatting.Indented);
		GD.Print(json);

		string textJson;
		textJson = System.IO.File.ReadAllText("TwoChoices.json");
		// GD.Print(textJson);
		var _inkStory = new Story(textJson);
		while (_inkStory.canContinue)
		{
			GD.Print(_inkStory.Continue());
		}

		if( _inkStory.currentChoices.Count > 0 ) 
		{	
			for (int i = 0; i < _inkStory.currentChoices.Count; ++i)
			{
				Choice choice = _inkStory.currentChoices[i];
				GD.Print("Choice " + (i + 1) + ". " + choice.text);
			}
		}

		_inkStory.ChooseChoiceIndex (0);

		while (_inkStory.canContinue)
		{
			GD.Print(_inkStory.Continue());
		}


}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
