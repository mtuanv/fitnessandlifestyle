
function calBMI() {
    let weightInput = $("#weight").val();
    let heightInput = $("#height").val();

    if(weightInput != "" && heightInput != ""){
        let a = Number(weightInput);
        let b = Number(heightInput);

        let c = a/(b*b/10000);
        let bmi = c.toFixed(1);
        $(".BMIIndex").text(bmi);
        moveArrow(bmi);
        showMess(bmi);
    } else {
        console.log("sai");
    }
}

function showMess(bmi){
    if(bmi < 18.5){
        $(".statusMessage").text("underweight");
    } else if (bmi < 25){
        $(".statusMessage").text("a healthy weight");
    } else if (bmi < 30){
        $(".statusMessage").text("overweight");
    } else if (bmi < 35) {
        $(".statusMessage").text("obese");
    } else {
        $(".statusMessage").text("extremly obese");
    }
}

function moveArrow(bmi){
    let maxWidth = $(".bmi-range").width();
    let ratio = maxWidth/25;
    if(bmi<14){
        $(".bmi-container span").css("padding-left","0px");
    } else if (bmi > 39){
        $(".bmi-container span").css("padding-left",maxWidth+"px");
    } else {
        $(".bmi-container span").css("padding-left",(bmi-14)*ratio+"px");
    }
}

function disposeModal() {
    var modalClose = $("#closeModal");
    if (modalClose != null) {
        $("#exampleModal").remove();
    }
}

function loadModal(link, titleExercise) {
    let container = document.getElementById("loadSection");
    let modal = document.createElement("div");
    modal.setAttribute("class", "modal fade show");
    modal.setAttribute("id", "exampleModal");
    modal.setAttribute("tabindex", "-1");
    modal.setAttribute("aria-labelledby", "exampleModalLabel");
    modal.setAttribute("aria-hidden", "true");
    modal.setAttribute("style", "display: block; padding-right: 16px");
    modal.setAttribute("role", "dialog");


    let modalDialog = document.createElement("div");
    modalDialog.setAttribute("class", "modal-dialog modal-dialog-centered");

    let modalContent = document.createElement("div");
    modalContent.setAttribute("class", "modal-content");

    let modalHeader = document.createElement("div");
    modalHeader.setAttribute("class", "modal-header");

    let title = document.createElement("h5");
    title.setAttribute("class", "modal-title");
    title.setAttribute("id", "exampleModalLabel");
    title.innerHTML = titleExercise;

    let modalBody = document.createElement("div");
    modalBody.setAttribute("class", "modal-body");

    let frame = document.createElement("iframe");
    frame.setAttribute("width", "470");
    frame.setAttribute("height", "315");
    frame.setAttribute("src", "https://www.youtube.com/embed/" + link);
    frame.setAttribute("frameborder", "0");
    frame.setAttribute("allow", "accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture");

    /*let content = document.createElement("div");
    content.setAttribute("class", "content-video");
    content.innerHTML = content_clip;*/

    let modalFooter = document.createElement("div");
    modalFooter.setAttribute("class", "modal-footer");

    let close = document.createElement('button');
    close.setAttribute("type", "button");
    close.setAttribute("class", "btn btn-secondary");
    close.setAttribute("data-bs-dismiss", "modal");
    close.setAttribute("id", "closeModal");
    close.setAttribute("onclick", "disposeModal()");
    close.innerHTML = "Close";

    modalHeader.appendChild(title);
    modalFooter.appendChild(close);
    modalBody.appendChild(frame);
    modalContent.appendChild(modalHeader);
    modalContent.appendChild(modalBody);
    //modalContent.appendChild(content);
    modalContent.appendChild(modalFooter);
    modalDialog.appendChild(modalContent);
    modal.appendChild(modalDialog);
    container.appendChild(modal);
}