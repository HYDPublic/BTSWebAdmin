/*
 <input type="range" min="1" max="3" step="1" onchange="updateSlider(this);" onmouseup="updateStatus(this);"/>
           <input type="range" min="1" max="2" step="1" onchange="updateSlider(this);" onmouseup="updateStatus(this);"/>
           */


function setValue(state) {
    //check connected json object for the before value
    switch (state) {
        case "true":
        case "true":
            // alert(rng.getAttribute("data-prev-value"));
            rng.className = "statebutton-min";
            break;
        case rng.max:
            rng.className = "statebutton-max";

            break;
        default:
            rng.className = "statebutton-mid";
            break;
    }

}

/*
https://msdn.microsoft.com/en-us/library/ee276896(v=bts.10).aspx
The following table shows the actions available from each state, and the result of each.
 	        Bound	        Stopped	        Started
Enlist	    Stopped	        Not available	Not available
Start	    Started	        Started	        Not available
Stop	    Not available	Not available	Stopped
Unenlist	Not available	Bound	        Bound
*/
function createSlider(parent,min,max,state)
{
    //context .application .type SendPorts|ReceiveportLocations|Orchestrations|SendPortGroups .
    //.name name of object (for receive locations the name is an path ReceivePortName/ReceiveLocationName
    //
    /*
    var events= " onchange='updateSlider(this);' onmouseup='updateStatus(this);'";
    format("<input type='range' min='{0}' max='{0}' step='1' ></input>");
    var input = document.createElement("INPUT");
    input.type = "range";
    input.max = max;
    input.min = min;
    input.value = state;
    input.addEventListener('change', input, false);
    input.addEventListener('mouseup', input, false);
    updateSlider(input);
    parent.appendChild(input);
    */
}

function updateStatus(rng) {
    alert(rng.valueAsNumber);
}

function updateSlider(rng) {
    //slider have the attribute data-bts-value i.e status in BizTalk
    //check connected json object for the before value
    switch (rng.value) {
        case rng.min:
            // alert(rng.getAttribute("data-prev-value"));
            rng.className = "statebutton-min";
            break;
        case rng.max:
            rng.className = "statebutton-max";

            break;
        default:
            rng.className = "statebutton-mid";
            break;
    }

}