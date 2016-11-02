
onmessage=function(event){
	postMessage('你好：'+event.data);
}

setTimeout(function () { console.log('end 2'); }, 2000);
setTimeout(function () { console.log('end 1'); }, 100);
console.log('end');