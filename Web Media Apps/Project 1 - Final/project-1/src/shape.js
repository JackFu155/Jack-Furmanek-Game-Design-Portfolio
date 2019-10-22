export {Circle, Rectangle, Triangle, Line};
import {getRandomUnitVector, getRandom} from './utils.js';

// base shape class takes current position of object to be drawn, 
//its color, its size (based on volume), and a counter of where it is around 
//the circomference of the circle
    // has a move and delete functionality that will take into account the objects 
    //current position on the screen and act accordingly
// each extended class has it's own draw method depending on the shape being drawn
class Shape{
    constructor(x=0, y=0, color='red', size=1, speed = 1, counter){
        this.x = x;
        this.y = y;
        this.color = color;
        this.size = size;
        this.heading = {
            x: Math.sin(counter),
            y: Math.cos(counter)
        };
        this.speed = speed
        this.directX = getRandom(-1,1);
        this.directY = getRandom(-1,1);
    }
    move(){
        this.x += (this.heading.x * this.speed);
        this.y += (this.heading.y * this.speed);
    }
    delete(obj, num){
        if (obj[num].x > 1480 || obj[num].x < 0 || obj[num].y > 400 || obj[num].y < 0){
            obj.splice(obj[num], 1);
            return true;
        }
        return false;
    }
}

// circle overides the heading of the base class so the movement of the circles will be random instead of counter/ clockwise
class Circle extends Shape{
    constructor(x=0, y=0, color='red', size=1, speed = 1, counter){ super(x, y, color, size, speed, counter);
        this.heading = getRandomUnitVector();
    }
    draw(ctx){
        ctx.save();
		ctx.beginPath();
		ctx.arc(this.x, this.y, this.size, 0, Math.PI * 2, false);
		ctx.closePath();
        ctx.fillStyle = this.color;
        ctx.strokeStyle = this.stroke;
        ctx.fill();
        ctx.stroke();
		ctx.restore();
    }
}

class Rectangle extends Shape{
    constructor(x=0, y=0, color='red', size=1, speed = 1, counter){ super(x, y, color, size, speed, counter);
        this.heading = {
            x: Math.sin(-counter),
            y: Math.cos(-counter)
        };
    }
    draw(ctx){
        ctx.save();
		ctx.beginPath();
		ctx.rect(this.x, this.y, this.size, this.size);
		ctx.closePath();
        ctx.fillStyle = this.color;
        ctx.fill();
        ctx.stroke();
		ctx.restore();
    }
}

class Triangle extends Shape{
    draw(ctx){
        ctx.save();
		ctx.beginPath();
        ctx.moveTo(this.x, this.y);
        ctx.lineTo(this.x - (this.size/2), this.y + this.size);
        ctx.lineTo(this.x + (this.size/2), this.y + this.size);
		ctx.closePath();
        ctx.fillStyle = this.color;
        ctx.fill();
        ctx.stroke();
		ctx.restore();
    }
}

class Line extends Shape{
    draw(ctx){
        ctx.save();
        ctx.beginPath();
        ctx.lineWidth = 10;
        ctx.moveTo(this.x, this.y);
        if (this.directX >=0 && this.directY >=0) ctx.lineTo(this.x + this.size, this.y + this.size);
        else if(this.directX >=0) ctx.lineTo(this.x + this.size, this.y - this.size);
        else if (this.directX < 0 && this.directY >=0) ctx.lineTo(this.x - this.size, this.y + this.size);
        else ctx.lineTo(this.x - this.size, this.y - this.size);
        ctx.strokeStyle = this.color;
        ctx.fill();
        ctx.stroke();
		ctx.restore();
    }
}