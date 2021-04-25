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
        $(".status").text("underweight");
    } else if (bmi < 25){
        $(".status").text("a healthy weight");
    } else if (bmi < 30){
        $(".status").text("overweight");
    } else if (bmi < 35) {
        $(".status").text("obese");
    } else {
        $(".status").text("extremly obese");
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