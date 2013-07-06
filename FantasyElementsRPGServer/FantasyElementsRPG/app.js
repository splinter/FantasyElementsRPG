/*
	run the server
*/

// loading dependency moules
var requirejs = require('requirejs');

//configuring requirejs  
requirejs.config({
    
    nodeRequire: require,
	baseUrl :""
});

//loading dependency scripts route.js, server.js, appConfig.js to be used
requirejs(['route','server','appConfig', 'sockets'],function(routes, server, appConfig, sockets)
{
	//creating the server
	var app = server();
	//configuring the server
	appConfig(app,__dirname);
	
	//creating and configuring the REST services
	routes(app);
	
	//running the sockets
	sockets(app);
	
	//setting the server to listen on port 3000
	app.listen(3000, function(){
		console.log("Express server listening on port %d in %s mode", app.address().port, app.settings.env);
		//console.log(seqInit);
	});

});