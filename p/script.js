/*var firstCon = document.getElementById("first_con");
var secondCon = document.getElementById("second_con");
var thirdCon = document.getElementById("third_con");
var fourthCon = document.getElementById("fourth_con");
var firstConTrigger = false;
var secondConTrigger = false;
var thirdConTrigger = false;
var fourthConTrigger = false;

firstCon.addEventListener("click", function() {
    for1stcon();
});

secondCon.addEventListener("click", function() {
    for2ndcon();
});

function for1stcon(){
    if(secondConTrigger){
        secondCon.classList.add("slide_2nd_con_main_back");
        secondCon.classList.remove("slide_2nd_con_main");
        firstCon.classList.add("slide_1st_con_back");
        firstCon.classList.remove("slide_1st_con");
        thirdCon.classList.add("slide_3rd_con_back");
        thirdCon.classList.remove("slide_3rd_con");
        fourthCon.classList.add("slide_4th_con_back");
        fourthCon.classList.remove("slide_4th_con");
        setTimeout(function() {
            firstCon.classList.add("slide_1st_con_main");
            firstCon.classList.remove("slide_1st_con_back");
            secondCon.classList.add("slide_2nd_con");
            secondCon.classList.remove("slide_2nd_con_main_back");
            thirdCon.classList.add("slide_3rd_con");
            thirdCon.classList.remove("slide_3rd_con_back");
            fourthCon.classList.add("slide_4th_con");
            fourthCon.classList.remove("slide_4th_con_back");
            firstConTrigger = true;
            secondConTrigger = false;
        },1000);
        
    }else{
        firstCon.classList.add("slide_1st_con_main");
        secondCon.classList.add("slide_2nd_con");
        thirdCon.classList.add("slide_3rd_con");
        fourthCon.classList.add("slide_4th_con");
        firstConTrigger = true;
    }
    
}

function for2ndcon(){
    if(firstConTrigger){
        firstCon.classList.add("slide_1st_con_main_back");
        firstCon.classList.remove("slide_1st_con_main");
        secondCon.classList.add("slide_2nd_con_back");
        secondCon.classList.remove("slide_2nd_con");
        thirdCon.classList.add("slide_3rd_con_back");
        thirdCon.classList.remove("slide_3rd_con");
        fourthCon.classList.add("slide_4th_con_back");
        fourthCon.classList.remove("slide_4th_con");
        setTimeout(function() {
            secondCon.classList.add("slide_2nd_con_main");
            secondCon.classList.remove("slide_2nd_con_back");
            firstCon.classList.add("slide_1st_con");
            firstCon.classList.remove("slide_1st_con_main_back");
            thirdCon.classList.add("slide_3rd_con");
            thirdCon.classList.remove("slide_3rd_con_back");
            fourthCon.classList.add("slide_4th_con");
            fourthCon.classList.remove("slide_4th_con_back");
            secondConTrigger = true;
            firstConTrigger = false;
        },1000);
    }else{
        secondCon.classList.add("slide_2nd_con_main");
        firstCon.classList.add("slide_1st_con");
        thirdCon.classList.add("slide_3rd_con");
        fourthCon.classList.add("slide_4th_con");
        secondConTrigger = true;
    }
    
    
}*/

// Define an array of containers and their corresponding triggers
const containers = [
    { element: document.getElementById("first_con"), trigger: false },
    { element: document.getElementById("second_con"), trigger: false },
    { element: document.getElementById("third_con"), trigger: false },
    { element: document.getElementById("fourth_con"), trigger: false },
];

// Add click event listeners to each container
containers.forEach((container, index) => {
    container.element.addEventListener("click", () => {
        handleContainerClick(index);
    });
});

// Function to handle a container click
function handleContainerClick(clickedIndex) {
    const clickedContainer = containers[clickedIndex];
    const previousContainer = containers.find((container) => container.trigger);

    if (previousContainer) {
        animateOut(previousContainer);
        animateIn(clickedContainer);

        // Update triggers
        previousContainer.trigger = false;
        clickedContainer.trigger = true;
    } else {
        // If no previous container is triggered, simply animate the clicked container in
        animateIn(clickedContainer);
        clickedContainer.trigger = true;
    }
}

// Function to animate a container out
function animateOut(container) {
    container.element.classList.remove(`slide_${container.element.id}_main`);
    container.element.classList.add(`slide_${container.element.id}_main_back`);
    container.element.firstElementChild.classList.remove(`${container.element.id}_title`);
    container.element.firstElementChild.classList.add(`${container.element.id}_title_back`);

}

// Function to animate a container in
function animateIn(container) {
    container.element.classList.remove(`slide_${container.element.id}_main_back`);
    container.element.classList.add(`slide_${container.element.id}_main`);
    container.element.firstElementChild.classList.remove(`${container.element.id}_title_back`);
    container.element.firstElementChild.classList.add(`${container.element.id}_title`);

}