//BLEL: 18.03.2013
//Presumes that frameset.js is loaded
//the function isUserOfModel should be called in frameset.GotoPage function --> function must be modified accordingly.
//User must be retrieved from Sharepoint Webpart
//this script must be loaded by the visio html output.
var xmlPermission = XMLData("users.xml");
function IsUserOfModel(Modelname, Username) {
    if (xmlPermission != null) {
        var modelQueryString = './/SerializableModelUser[Model = ' + Modelname + ']/Users/SerializableUser[Shortname=' + Username + ']';
        var modelObj = SelectSingleNode(xmlPermission, modelQueryString);
        if (modelObj != null) {
            return true;
        }
        else {
            return false;
        }
    }
}


//add function to get user from webpart

