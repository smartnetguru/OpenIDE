/*registerTarget(
	require("completion.js"), 
	require("runner.js"),
	require("properties.js")
);*/

plugin.AddEventListener("OnReady", function() {
	var vw = new ViewBuilder();
	vw.Button();
	
	var v = new Window("Windowname");
	v.ViewBuilder = vw;
	
	register_window(v);
})