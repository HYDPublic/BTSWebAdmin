//context .application .type SendPorts|ReceiveportLocations|Orchestrations|SendPortGroups .
//.name name of object (for receive locations the name is an path ReceivePortName/ReceiveLocationName
//
var sendports;
var sendportgroups;
var receiveports;
var receivelocations;
var orchestrations;
var pipelines;
var transforms
//Active TR of a BTS object table has attributes data-name! Attributes data-type  and data-application 
//is on the TBODY element


function format(str) {
    var len = arguments.length;

    for (i = 1; i < len; i++) {
        str = str.replace("{" + (i - 1) + "}", arguments[i]);

    }

    return str;
}