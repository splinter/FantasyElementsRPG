/*
defining a nodejs server 
*/

//loading dependency module express from node_modules 
define(['express'],function(express){
	var server = function()
	{
		//creating a nodejs server and returning it
		return express.createServer();
	}
	return server;
});