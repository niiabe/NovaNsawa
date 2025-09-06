// Your web app's Firebase configuration
var firebaseConfig = {
    apiKey: "AIzaSyA7AzRoQzqGoV57Oc7JgxXFAIP4daC7r30",
    authDomain: "improp-746b3.firebaseapp.com",
    databaseURL: "https://improp-746b3.firebaseio.com",
    projectId: "improp-746b3",
    storageBucket: "improp-746b3.appspot.com",
    messagingSenderId: "354545439430",
    appId: "1:354545439430:web:47615544f99f0800867dc7",
    measurementId: "G-JW1GYC4K1E"
};
// Initialize Firebase
firebase.initializeApp(firebaseConfig);



//Reference messages collection
var messagesRef =   firebase.database().ref('messages');



//listen to contact form
document.getElementById('submit').addEventListener('click',submitForm);

function submitForm(e) {

    e.preventDefault();

    var name    = getInputVal('name');
    var email   = getInputVal('email');
    var subject = getInputVal('subject');
    var phone   = getInputVal('phone');
    var msg     = getInputVal('message');


    saveMsg(name,email,subject,msg,phone);

}

function getInputVal(id) {
    return document.getElementById(id).value;
}


//save the message to firebase
function saveMsg(name,email,subject,msg,phone){
    var newMsgRef = messagesRef.push();
    newMsgRef.set({
       name: name,
       email: email,
       subject: subject,
       phone: phone,
       msg : msg
    });
}