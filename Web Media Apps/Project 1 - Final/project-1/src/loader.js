import {init} from './main.js';

// load fonts here
let head = document.querySelector("head");
let link = document.createElement("link");
link.rel = 'stylesheet';
link.type = 'text/css';
link.href ="https://fonts.googleapis.com/css?family=Lobster&display=swap";
head.appendChild(link);

// load files once window has loaded
window.onload = init;