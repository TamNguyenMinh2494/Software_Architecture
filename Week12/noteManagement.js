// set the configuration for your app
const config = { databaseURL: "https://softwarearchitecture-bceee.firebaseio.com/" };
firebase.initializeApp(config);
const dbRef = firebase.database().ref();

/* event-handler methods */
function page_Load() {
    getAll();
}

function lnkID_Click(id) {
    getDetails(id);
}

function btnSearch_Click() {
    var keyword = document.getElementById("txtKeyword").value.trim();
    if (keyword.length > 0)
        search(keyword);
    else
        getAll();
}

function btnAdd_Click() {
    var newNote = {
        ID: document.getElementById("txtID").value,
        Title: document.getElementById("txtTitle").value,
        Date: document.getElementById("txtDate").value,
        Creator: document.getElementById("txtCreator").value,
        Content: document.getElementById("txtContent").value,
        IsSharable: document.getElementById("txtIsSharable").value
    };
    addNew(newNote);
}

function btnUpdate_Click() {
    var newNote = {
        ID: document.getElementById("txtID").value,
        Title: document.getElementById("txtTitle").value,
        Date: document.getElementById("txtDate").value,
        Creator: document.getElementById("txtCreator").value,
        Content: document.getElementById("txtContent").value,
        IsSharable: document.getElementById("txtIsSharable").value
    };
    updateNote(newNote);
}

function btnDelete_Click() {
    if (confirm("ARE YOU SURE ?")) {
        var ID = document.getElementById("txtID").value;
        deleteNote(ID);
    }
}

/* firebase methods */
function getAll() {
    dbRef.child("notes").on("value", (snapshot) => {
        var notes = [];
        snapshot.forEach((child) => {
            //alert(child.key);
            var note = child.val();
            notes.push(note);
        });
        renderNoteList(notes);
    });
}

function getDetails(ID) {
    dbRef.child("notes").once("value", (snapshot) => {
        snapshot.forEach((child) => {
            var note = child.val();
            if (note.ID == ID) {
                renderNoteDetails(note);
            }
        });
    });
}

function search(keyword) {
    dbRef.child("notes").once("value", (snapshot) => {
        var notes = [];
        snapshot.forEach((child) => {
            var note = child.val();
            if (note.Title.includes(keyword)) {
                notes.push(note);
            }
        });
        renderNoteList(notes);
    });
}

function addNew(newNote) {
    //dbRef.child("books").push(newBook); // auto-generated key
    dbRef.child("notes/N" + newNote.ID).set(newNote); // custom key
}

function updateNote(newNote) {
    dbRef.child("notes").once("value", (snapshot) => {
        snapshot.forEach((child) => {
            var note = child.val();
            if (note.ID == newNote.ID) {
                var key = child.key;
                dbRef.child("notes").child(key).set(newNote);
            }
        });
    });
}

function deleteNote(ID) {
    dbRef.child("notes").once("value", (snapshot) => {
        snapshot.forEach((child) => {
            var note = child.val();
            if (note.ID == ID) {
                var key = child.key;
                dbRef.child("notes").child(key).remove();
            }
        });
    });
}

/* helper methods */
function renderNoteList(notes) {
    var rows = "";
    for (var note of notes) {
        rows += "<tr>";
        rows += "<td><a href='#' onclick='lnkID_Click(" + note.ID + ")'>" + note.ID + "</a></td>";
        rows += "<td>" + note.Title + "</td>";
        rows += "<td>" + note.Date + "</td>";
        rows += "<td>" + note.Creator + "</td>";
        rows += "<td>" + note.Content + "</td>";
        rows += "<td>" + note.IsSharable + "</td>";
        rows += "</tr>";
    }
    var header = "<tr><th>ID</th><th>Title</th><th>Date</th><th>Creator</th><th>Content</th><th>IsSharable</th></tr>";
    document.getElementById("listNotes").innerHTML = header + rows;
}

function renderNoteDetails(note) {
    document.getElementById("txtID").value,
        document.getElementById("txtTitle").value,
        document.getElementById("txtDate").value,
        document.getElementById("txtCreator").value,
        document.getElementById("txtContent").value,
        document.getElementById("txtIsSharable").value
}