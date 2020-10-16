function updateDocumentTitle(title) {
    document.title = title;
    document.getElementById("title").innerText = title;
}

function readDocumentTitle() {
    return document.title;
}