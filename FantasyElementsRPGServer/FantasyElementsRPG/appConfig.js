/*
configuration of the nodejs server
*/

// this is boilerplate code which automatically 
//gets written when a nodeJS application is created using express

//express is a dependency module which is loaded from node_modules
define(['express', 'less-middleware'], function (express, lessMiddleware){
	var config = function(app,__dirname)
	{
		app.configure(function(){
			app.set('views', __dirname + '/views');
			app.set('view engine', 'jade');
			app.use(express.bodyParser());
			app.use(express.methodOverride());
			app.use(express.cookieParser());
			app.use(express.session({secret: 'sercook'}));
			app.use(app.router);
			app.use(express.static(__dirname + '/public'));
			
			// css pre-processor
			app.use(lessMiddleware({
				src      : __dirname + "/public",
				compress : true
			}));
			app.use(express.static(__dirname + '/public'));
		});
		
		

		app.configure('development', function(){
			app.use(express.errorHandler({ dumpExceptions: true, showStack: true }));
		});
		
	}
	
	return config;
});