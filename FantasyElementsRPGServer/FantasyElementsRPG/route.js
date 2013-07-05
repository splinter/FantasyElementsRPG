/*
	defining REST services and 
	setting the business logic functions to them
*/

//loading the routes/index.js file to be used
define(['routes/index'],
function (routes)
{
		var initialize = function(app)
		{
			//defining the localhost:3000, localhost:3000/index REST service
			app.get('/', routes);
		}

		return initialize;

});
