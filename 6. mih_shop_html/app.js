const express = require('express');
const app = express();
const http = require('http');
const server = http.createServer(app);
const SocketIOFileUpload = require('socketio-file-upload');
const { Server } = require("socket.io");
const io = new Server(server);
const { v4: uuidv4 } = require('uuid');
const { Socket } = require('net');

var users = [];
app.use(SocketIOFileUpload.router).use(express.static(__dirname));
var t="";
io.on ('connection' ,socket=> {
 	var run = new SocketIOFileUpload();
 	run.dir = "./uploads";
 	run.listen(socket);
 	socket.on('register', name=>{
 		var index = users.findIndex(u=> u.toLowerCase() == name.toLowerCase());
 		if(index >= 0) { 
 			let nu = name+ (Math.floor(Math.random()*999 )+1).toFixed('000');
			users.push(nu);
			socket.username = nu;
			}
			else {
				socket.username = name;
				users.push(name);
				}
 		socket.emit('regsuccess', socket.username);
 		io.emit('userlist', users);
	});
	socket.on('chat', msg=>{
		socket.broadcast.emit('message', {from:socket.username, msg:msg})
	});
	run.on("start", function(event){
	
        var old_name = event.file.name
        var arr = old_name.split('.');
		var new_name = uuidv4()+'.'+arr[arr.length - 1];
		if(['png', 'jpg', 'jpeg', 'gif', 'svg'].indexOf(arr[arr.length - 1])>=0) {
			t='image';
		}
		else{
			t='file';
		}
		console.log(t);
        return event.file.name = new_name;
    });
	run.on("saved", function(event){
		io.emit('uploaded', {from: socket.username, file:event.file.name, type:t});
    });
    run.on("error", function(event){
        console.log("Error from run", event);
    });
});

server.listen(9191, () => {
    console.log('Server Running @ 9191');
  });