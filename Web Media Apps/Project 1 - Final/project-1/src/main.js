export {init, songEnded, songPlaying};
import {requestFullscreen, makeColor,getRandomUnitVector,time} from './utils.js';
import {Circle, Rectangle, Triangle, Line} from './shape.js';

// create objects with pre-set oprtons for music
const SOUND_PATH = Object.freeze({
    sound1: "media/Summer-Of-69.mp3",
    sound2: "media/Feel-The-Night.mp3",
	sound3:  "media/The-Power-Of-Love.mp3",
	sound4: "media/What-Have-I-Done.mp3",
    sound5: "media/What-Everybody-Wants.mp3"
});

// make color an object that the internal values are adjusted
const color = {
	red: 65,
	green: 110,
	blue: 80,
	alpha: 255
};

// relatove positions for objects
const currentPosition = {
	x: 740 + getRandomUnitVector(10,100).x,
	y: 200 + getRandomUnitVector(10,100).y
};

// list of total objects in the sceen
let elementsOnSceen = {
	circle: {totalCircles: []},
	triangle:{totalTriangles: []},
	square:{totalSquares: []},
	line:{totalLines: []}
};
// array of objects ithin shapes

let audioElement,canvasElement;

// UI
let playButton;

let showTrails, showSepia, showNoise, showInvert, waveform;

// 3 - our context
let drawCtx, audioCtx;

// 5 - nodes that are part of our WebAudio audio routing graph
let sourceNode, analyserNode, gainNode, delayNode;

// 6 - a typed array to hold the audio frequency data
const NUM_SAMPLES = 256;
// create a new array of 8-bit integers (0-255)
let audioData = new Uint8Array(NUM_SAMPLES/2); 

// hand drawn speaker
let speakerRadius = 45;
let numCircles = 0, numSquares=0, numTriangles=0, numLines=0;

// tempo - how fast is teh song going
// sizeOfShapes - changes depending on the valume
// counter - where am I on the circumferance going around a circle
let tempo, sizeOfShapes, gradiant = 0, timer = 0, i =0, counter = 0, delayAmt = 1;

let triangle, circle, square;
// is the song playing or not, and had the song ended or not
let songEnded = true, songPlaying = false;

function init(){
    setUpWebAudio();
    setUpCanvas();
	setUpUI();
	createBackground(gradiant);
	update();
}

function setUpCanvas(){
    canvasElement = document.querySelector("canvas");
	drawCtx = canvasElement.getContext('2d');
}
function setUpWebAudio(){
	const AudioContext = window.AudioContext || window.webkitAudioContext;
	audioCtx = new AudioContext();
	
	audioElement = document.querySelector("audio");
	audioElement.src = SOUND_PATH.sound5;
			
	sourceNode = audioCtx.createMediaElementSource(audioElement);
			
	analyserNode = audioCtx.createAnalyser();
				
	analyserNode.fftSize = NUM_SAMPLES;
			
	gainNode = audioCtx.createGain();
	gainNode.gain.value = 1;
	
	// added delay node before anylysing it for reverb effecrt
	delayNode = audioCtx.createDelay();
	delayNode.delayTime.value = delayAmt;

	sourceNode.connect(delayNode);
	delayNode.connect(analyserNode);
	analyserNode.connect(gainNode);
	gainNode.connect(audioCtx.destination);
}
// setting up UI
function setUpUI(){
	// play button info
    playButton = document.querySelector("#playButton");
	playButton.onclick = e => {
				
		if (audioCtx.state == "suspended") {
			audioCtx.resume();
			songPlaying = true;
		}

		if (e.target.dataset.playing == "no") {
			audioElement.play();
			e.target.dataset.playing = "yes";
			songPlaying = true;
		}
		 // if track is playing pause it
		else if (e.target.dataset.playing == "yes") {
			audioElement.pause();
			e.target.dataset.playing = "no";
			songPlaying = false;
		}
		songEnded = false;
	};

	// checkBox info - ghoasting, waveform, invert, noise, and sepia effects hooked to checkboxes in current state
    document.querySelector('#trailsCB').checked = showTrails;
	document.querySelector('#waveformCB').checked = waveform;
	document.querySelector('#invertCB').checked = showInvert;
	document.querySelector('#noiseCB').checked = showNoise;
	document.querySelector('#sepiaCB').checked = showSepia;

	// effects change as boxes are checked on or off
	document.querySelector('#trailsCB').onchange = e => showTrails = e.target.checked;
	document.querySelector('#waveformCB').onchange = e => waveform = e.target.checked;
	document.querySelector('#invertCB').onchange = e => showInvert = e.target.checked;
	document.querySelector('#noiseCB').onchange = e => showNoise = e.target.checked;
    document.querySelector('#sepiaCB').onchange = e => showSepia = e.target.checked;

	// Radio Buttons - not include line as an option as it serves as a default if none of the other boxes are checked
	circle = document.querySelector("#circleRB").checked;
	triangle = document.querySelector("#triangleRB").checked;
	square = document.querySelector("#rectangleRB").checked;

	// set which shape is current
	document.querySelector('#circleRB').onchange = e => {
		circle = e.target.checked 
		triangle = false;
		square=false;
	};
	document.querySelector('#triangleRB').onchange = e => {
		circle=false;
		triangle = e.target.checked;
		square=false;
	}
	document.querySelector('#rectangleRB').onchange = e => {
		circle=false;
		triangle = false;
		square=e.target.checked;
	}
	document.querySelector('#lineRB').onchange = e => {
		circle=false;
		triangle = false;
		square=false;
	}

	// slider info
    	//Volume Slider
	let volumeSlider = document.querySelector("#volumeSlider");
	volumeSlider.oninput = e => {
		gainNode.gain.value = e.target.value;
		volumeLabel.innerHTML = Math.round((e.target.value/2 * 100));

		// size of shapes is generated by volume
		sizeOfShapes = (e.target.value/2 * 50);
	};
	volumeSlider.dispatchEvent(new InputEvent("input"));

		//Color Slider (R, G, B)
	let RcolorSlider = document.querySelector("#RcolorSlider");
	RcolorSlider.oninput = e => {
		//gainNode.gain.value = e.target.value;
		color.red = e.target.value;
		RcolorLabel.innerHTML = e.target.value;
	};
	RcolorSlider.dispatchEvent(new InputEvent("input"));

	let GcolorSlider = document.querySelector("#GcolorSlider");
	GcolorSlider.oninput = e => {
		//gainNode.gain.value = e.target.value;
		color.green = e.target.value;
		GcolorLabel.innerHTML = e.target.value;
	};
	GcolorSlider.dispatchEvent(new InputEvent("input"));

	let BcolorSlider = document.querySelector("#BcolorSlider");
	BcolorSlider.oninput = e => {
		//gainNode.gain.value = e.target.value;
		color.blue = e.target.value;
		BcolorLabel.innerHTML = e.target.value;
	};
	BcolorSlider.dispatchEvent(new InputEvent("input"));
	
	// set speed of the object
	let speedSlider = document.querySelector("#speedSlider");
	speedSlider.oninput = e=>{
		tempo = speedLabel.innerHTML = e.target.value;
	}
	speedSlider.dispatchEvent(new InputEvent("input"));

	// delay slider to change reverb amount
	let delaySlider = document.querySelector("#delaySlider");
	delaySlider.oninput = e=>{
		delayAmt = e.target.value;
		delayLabel.innerHTML =  delayAmt * 100;
	}
	delaySlider.dispatchEvent(new InputEvent("input"));

	//Track Selector
	document.querySelector("#trackSelect").onchange = e =>{
		audioElement.src = e.target.value;
		// pause the current track if it is playing
		playButton.dispatchEvent(new MouseEvent("click"));
		songEnded = true;
	};
			
			
	// if track ends
	audioElement.onended =  _ => {
		playButton.dataset.playing = "no";
		timer = 0;
		songEnded = true;
		songPlaying = false;
	};
			
	// make full screen
	document.querySelector("#fsButton").onclick = _ =>{
		requestFullscreen(canvasElement);
	};	
	
	// set up timer
	setInterval(function() {time()}, 1000);
}

// create gradient for background
function createBackground(gradiant){
	let grad = drawCtx.createLinearGradient(0,0,canvasElement.width, 0);
	if(gradiant > 1) gradiant = 0;
	grad.addColorStop(gradiant, 'red');
	gradiant += (1 / 6);
	if(gradiant >1) gradiant = 0;
	grad.addColorStop(gradiant, 'orange');
	gradiant += (1 / 6);
	if(gradiant >1) gradiant = 0;
	grad.addColorStop(gradiant, 'yellow');
	gradiant += (1 / 6);
	if(gradiant >1) gradiant = 0;
	grad.addColorStop(gradiant, 'green')
	gradiant += (1 / 6);
	if(gradiant >1) gradiant = 0;
	grad.addColorStop(gradiant, 'aqua');
	gradiant += (1 / 6);
	if(gradiant >1) gradiant = 0;
	grad.addColorStop(gradiant, 'blue');
	gradiant += (1 / 6);
	if(gradiant >1) gradiant = 0;
	grad.addColorStop(gradiant, 'purple');

	drawCtx.fillStyle = grad;
	drawCtx.fillRect(0,0,canvasElement.width, canvasElement.height);
}

//Draws shapes to represent sound
// creates a 3 row repersentation based on what is the current shape being drawn
// will either display according to waveform data OR frequencey data
function drawSound(){
	//drawCtx.clearRect(0, 0, drawCtx.canvas.width, drawCtx.canvas.height);
	let circleWidth = 1;
	let circleSpacing = 17.5;
	let topSpacing = 130;

	let currentHeight;

	for(let i=0; i<audioData.length;i++){
		if (playButton.dataset.playing == "yes") currentHeight = (topSpacing-60) + 256-audioData[i];
		else if (currentHeight < (canvasElement.height - 65)) currentHeight + 5;
		else currentHeight = canvasElement.height - 65;
		drawCtx.save();
		drawCtx.beginPath();
		drawCtx.fillStyle = drawCtx.strokeStyle = makeColor(color.red, color.green, color.blue, color.alpha);

		// draw appropriete shape
		if(circle){
			drawCtx.arc(i * (circleWidth + circleSpacing),currentHeight + 60, 5, 0, Math.PI * 2, false);
			drawCtx.arc(i * (circleWidth + circleSpacing),currentHeight+30, 5, 0, Math.PI * 2, false);
			drawCtx.arc(i * (circleWidth + circleSpacing),currentHeight, 5, 0, Math.PI * 2, false);
		}
		else if(triangle){
			drawCtx.moveTo(i * (circleWidth + circleSpacing),currentHeight + 60);
			drawCtx.lineTo(i * (circleWidth + circleSpacing) - 5,currentHeight + 60 - 10);
			drawCtx.lineTo(i * (circleWidth + circleSpacing) + 5,currentHeight + 60 - 10);

			drawCtx.moveTo(i * (circleWidth + circleSpacing),currentHeight+30);
			drawCtx.lineTo(i * (circleWidth + circleSpacing) - 5,currentHeight+30 - 10);
			drawCtx.lineTo(i * (circleWidth + circleSpacing) + 5,currentHeight+30 - 10);

			drawCtx.moveTo(i * (circleWidth + circleSpacing),(currentHeight));
			drawCtx.lineTo(i * (circleWidth + circleSpacing) - 5,currentHeight - 10);
			drawCtx.lineTo(i * (circleWidth + circleSpacing) + 5,currentHeight - 10);
		}
		else if(square){
			drawCtx.rect(i * (circleWidth + circleSpacing),currentHeight + 60, 5, 5);
			drawCtx.rect(i * (circleWidth + circleSpacing),currentHeight+30, 5, 5);
			drawCtx.rect(i * (circleWidth + circleSpacing),currentHeight, 5, 5);
		}
		else{
			drawCtx.moveTo(i * (circleWidth + circleSpacing),currentHeight + 60);
			drawCtx.lineTo(i * (circleWidth + circleSpacing),currentHeight + 70);

			drawCtx.moveTo(i * (circleWidth + circleSpacing),currentHeight+30);
			drawCtx.lineTo(i * (circleWidth + circleSpacing),currentHeight+40);

			drawCtx.moveTo(i * (circleWidth + circleSpacing),currentHeight);
			drawCtx.lineTo(i * (circleWidth + circleSpacing),currentHeight + 10);

			drawCtx.stroke();
		}
		drawCtx.closePath();
		drawCtx.fill();
		drawCtx.restore();
	}
}

function update(){
	requestAnimationFrame(update);
	// draw the speaker and "update" the current image of the speaker
	// only update the screen if there is a song playxng

	timer++; // keep track of number of frames

	drawCtx.clearRect(0, 0,canvasElement.width,canvasElement.height);
	createBackground(gradiant);
	
	speaker();

	// "current Position" is reset every frame to be the center fo teh screen for current shape to be drawn with
	currentPosition.x = canvasElement.width/2;
	currentPosition.y = canvasElement.height/2;

	if(playButton.dataset.playing == 'yes'){
		if (timer)
		if(waveform){
			analyserNode.getByteTimeDomainData(audioData);
		}
		else{
			analyserNode.getByteFrequencyData(audioData);
		}

		// make the color - adjusted by brightness
		let currentColor = makeColor(color.red, color.green, color.blue, color.alpha);
		
		//4 times per second, a shape is drawn
		if (timer % 15 == 1){
			// direction around the circle when object is generated
			counter++;
			if (circle){
				// create array ellement withing the object to itterate through to have that number of objects drawn to the screen
				elementsOnSceen.circle.totalCircles.push(numCircles);
				// create new circle objects
				elementsOnSceen.circle.totalCircles[numCircles] = new Circle(currentPosition.x, currentPosition.y, currentColor, sizeOfShapes, tempo, counter);
				// draw circle object
				elementsOnSceen.circle.totalCircles[numCircles].draw(drawCtx);
				// increase total circle count of all circle objects that exist
				numCircles++;
			}
			else if(triangle){
				// create array ellement withing the object to itterate through to have that number of objects drawn to the screen
				elementsOnSceen.triangle.totalTriangles.push(numTriangles);
				elementsOnSceen.triangle.totalTriangles[numTriangles] = new Triangle(currentPosition.x, currentPosition.y, currentColor, sizeOfShapes * 2, tempo, counter);
				elementsOnSceen.triangle.totalTriangles[numTriangles].draw(drawCtx);
				numTriangles++;
			}			
			else if(square){
				// create array ellement withing the object to itterate through to have that number of objects drawn to the screen
				elementsOnSceen.square.totalSquares.push(numSquares);
				elementsOnSceen.square.totalSquares[numSquares] = new Rectangle(currentPosition.x, currentPosition.y, currentColor, sizeOfShapes *2, tempo,counter);
				elementsOnSceen.square.totalSquares[numSquares].draw(drawCtx);
				numSquares++;
			}				
			else{
				// create array ellement withing the object to itterate through to have that number of objects drawn to the screen
				elementsOnSceen.line.totalLines.push(numLines);
				elementsOnSceen.line.totalLines[numLines] = new Line(currentPosition.x, currentPosition.y, currentColor, sizeOfShapes *3, tempo, counter);
				elementsOnSceen.line.totalLines[numLines].draw(drawCtx);
				numLines++;
			}			
		}
		//12 times per second the background color changes
		if(timer%5 == 1){
			if (gradiant > 1) gradiant = 0;
			gradiant += 1/6;
		}
	}

	drawSound();

		//draw all elements on the screen - updating their positions
	for (i = 0; i < numCircles; i++){
		if (playButton.dataset.playing == "yes")
			elementsOnSceen.circle.totalCircles[i].move();
		elementsOnSceen.circle.totalCircles[i].draw(drawCtx);
		if (elementsOnSceen.circle.totalCircles[i].delete(elementsOnSceen.circle.totalCircles, i)){
			i--;
			numCircles--;
		}
	}
	for (i = 0; i < numSquares; i++){
		if (playButton.dataset.playing == "yes")
			elementsOnSceen.square.totalSquares[i].move();
		elementsOnSceen.square.totalSquares[i].draw(drawCtx);
		if (elementsOnSceen.square.totalSquares[i].delete(elementsOnSceen.square.totalSquares, i)){
			i--;
			numSquares--;
		}
		}
	for(i = 0; i < numTriangles;i++){
		if (playButton.dataset.playing == "yes")
			elementsOnSceen.triangle.totalTriangles[i].move();
		elementsOnSceen.triangle.totalTriangles[i].draw(drawCtx);
		if (elementsOnSceen.triangle.totalTriangles[i].delete(elementsOnSceen.triangle.totalTriangles, i)){
			i--;
			numTriangles--;
		}
	}
	for (i=0; i < numLines; i++){
		if (playButton.dataset.playing == "yes")
			elementsOnSceen.line.totalLines[i].move();
		elementsOnSceen.line.totalLines[i].draw(drawCtx);
		if (elementsOnSceen.line.totalLines[i].delete(elementsOnSceen.line.totalLines, i)){
			i--;
			numLines--;
		}
	}
	setInterval(manipulatePixels(drawCtx), 1000);
	delayNode.delayTime.value = delayAmt;
}

//Draws animated speaker at center of screen
function speaker(){
    drawCtx.save();
    drawCtx.fillStyle = "blue";
    drawCtx.lineWidth = 10;
    drawCtx.strokeStyle = "green";
    drawCtx.beginPath();
    drawCtx.arc(canvasElement.width/2, canvasElement.height/2, speakerRadius, 0, Math.PI * 2, false);
    drawCtx.closePath();
    drawCtx.fill();
	drawCtx.stroke();
	drawCtx.restore();

	// adjust radius
	if (playButton.dataset.playing == "yes")
    speakerRadius++;
    if (speakerRadius == 60) speakerRadius = 45;
}

//Maniuplates all pixels
function manipulatePixels(ctx){
	//Get all of the rgba pixel data of the canvas by grabbing the ImageData Object
	let imageData = ctx.getImageData(0, 0, ctx.canvas.width, ctx.canvas.height);

	//imageData.data contains 4 values per pixel: 4 x canvas.width x canvas.height = 1,024,000 values!
	//we're looping through this 60 FPS - wow!
	let data = imageData.data;
	let length = data.length;
	let width = imageData.width;

	// pixel data - broken down into the 4 sub chanels
	//data[i] is the red value
	//data[i + 1] is the green value
	//data[i + 2] is the blue value
	//data[i + 3] is the alpha value


	let i; //declaring 'i' outside loop is an optimization
	for(i = 0; i < length; i++){
		//increase red value only
		//For unknown reasons, the program slows when the tint red is checked with the brightness settings
		// #1 Ghosting
		if (showTrails){
			ctx.save();
			ctx.globalAlpha = 0.4;
		}
		else{
			ctx.restore();
			//ctx.globalAlpha = 1.0;
		}
	}
	for(i = 0; i < length; i+=4){
		// sepia
		if(showSepia){
			// change image colors
			data[i] = (data[i] * 0.393) + (data[i+1] * 0.796) + (data[i+2] * 0.189);
			data[i+1] = (data[i] * 0.349) + (data[i+1] * 0.686) + (data[i+2] * 0.168);
			data[i+2] = (data[i] * 0.272) + (data[i+1] * 0.534) + (data[i+2] * 0.131);
		}
		//invert every color channel
		if(showInvert){
			let red = data[i], green = data[i+1], blue = data[i + 2];
			data[i] = 255 - red; //set red value
			data[i+1] = 255 - green; //set green value
			data[i+2] = 255 - blue; //set blue value
		}
		// noise
		if(showNoise && Math.random() < .10){
			data[i] = data[i + 1] = data[i + 2] = 128; //grey noise
			data[i+3] = 255; //alpha
		}
	}

	//put the modified data back on the canvas
	ctx.putImageData(imageData, 0, 0);
}