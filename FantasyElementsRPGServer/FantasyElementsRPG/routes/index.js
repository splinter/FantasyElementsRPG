
/*
 BL to GET home page.
 */

define([],function (){
	var initHomePage = function(req, res){
		//console.log(seq);
		res.render('index', { title: 'Express' });
	};
	
	return initHomePage;
});

