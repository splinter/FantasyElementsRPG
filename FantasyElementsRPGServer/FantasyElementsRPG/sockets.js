/*
creating the socket connection
*/

define(['socket.io'],function(io){
	var sock = function(app)
	{
		var res = io.listen(app);
		//console.log(io);
		res.sockets.on('connection', function (socket) {
			socket.emit('news', { hello: 'world' });
			socket.on('my other event', function (data) {
				console.log(data);
			});
		});
	};
	
	return sock;
});