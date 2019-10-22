import {songEnded, songPlaying} from './main.js';
export {requestFullscreen, makeColor,getRandomUnitVector,getRandom, time};
// HELPER FUNCTIONS
function makeColor(red, green, blue, alpha){
    let color='rgba('+red+','+green+','+blue+', '+alpha+')';
    return color;
}

function requestFullscreen(element) {
 if (element.requestFullscreen) {
   element.requestFullscreen();
 } else if (element.mozRequestFullscreen) {
   element.mozRequestFullscreen();
 } else if (element.mozRequestFullScreen) { // camel-cased 'S' was changed to 's' in spec
   element.mozRequestFullScreen();
 } else if (element.webkitRequestFullscreen) {
   element.webkitRequestFullscreen();
 }
 // .. and do nothing if the method is not supported
};

let startingSec = 0;
let startingMin = 0;
let minutesLabel = document.getElementById("minutes");
let secondsLabel = document.getElementById("seconds");
// timer for displaying time since song started to user
function time(){
	if (!songEnded){ // if the song has ended (or changed)
		if (songPlaying){ // if the song is currently playing
			if(startingSec < 59){
				startingSec ++;
			}
			else{
				startingSec = 0;
			}
			if(startingSec < 10){
				secondsLabel.innerHTML = "0" + startingSec;
			}
			else if(startingSec >= 10){
				secondsLabel.innerHTML = startingSec;
			}
			if(startingSec%60 == 0){
				if(startingMin == 59){
					startingMin == 0;
				}
				else{
					startingMin++;
				}
				minutesLabel.innerHTML = startingMin;
			}
		}
	}
	else{	// when a new song starts	
		startingMin = 0;
		startingSec = 0;
	}
}


function getRandomUnitVector(){
	let x = getRandom(-1,1);
	let y = getRandom(-1,1);
	let length = Math.sqrt(x*x + y*y);
	if(length == 0){ // very unlikely
		x=1; // point right
		y=0;
		length = 1;
	} else{
		x /= length;
		y /= length;
	}

	return {x:x, y:y};
}

function getRandom(min, max) {
	return Math.random() * (max - min) + min;
}
