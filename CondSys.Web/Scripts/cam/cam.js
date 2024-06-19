var width = 220;    // We will scale the photo width to this
var height = 0;     // This will be computed based on the input stream

var streaming = false;

var video = null;
var canvas = null;
var photo = null;
var startbutton = null;
var turnonbutton = null;
var hidImage = null

startup();

function startup() {
    video = document.getElementById('video');
    canvas = document.getElementById('canvas');
    photo = document.getElementById('photo');
    startbutton = document.getElementById('startbutton');
    turnonbutton = document.getElementById('turnonbutton');
    hidImage = document.getElementById('hidFotoVisitante');
    clearphoto();
};

video.addEventListener('canplay', function (ev) {
    if (!streaming) {
        height = video.videoHeight / (video.videoWidth / width);

        video.setAttribute('width', width);
        video.setAttribute('height', height);
        canvas.setAttribute('width', width);
        canvas.setAttribute('height', height);
        streaming = true;
    }
}, false);

turnonbutton.addEventListener('click', function (ev) {
    navigator.mediaDevices.getUserMedia({ video: true, audio: false }).then(function (stream) {
        video.srcObject = stream;
        video.play();
    })
    .catch(function (err) {
        console.log("An error occurred! " + err);
    });
    ev.preventDefault();
}, false);

startbutton.addEventListener('click', function (ev) {
    takepicture();
    ev.preventDefault();
}, false);

function clearphoto() {
    var context = canvas.getContext('2d');
    context.fillStyle = "#AAA";
    context.fillRect(0, 0, canvas.width, canvas.height);

    var data = canvas.toDataURL('image/png');
    photo.setAttribute('src', data);
}

function takepicture() {
    startup();
    var context = canvas.getContext('2d');
    if (width && height) {
        canvas.width = width;
        canvas.height = height;
        context.drawImage(video, 0, 0, width, height);
        
        var data = canvas.toDataURL('image/png');
        photo.setAttribute('src', data);
        hidImage.setAttribute('value', data);
        vidOff();
    } else {
        clearphoto();
    }
}

function vidOff() {
    //clearInterval(theDrawLoop);
    //ExtensionData.vidStatus = 'off';
    video.pause();
    video.src = "";
    video.srcObject.getTracks()[0].stop();
    console.log("Vid off");
}