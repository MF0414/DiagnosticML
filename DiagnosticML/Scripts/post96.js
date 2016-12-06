
// Fetching HTML Elements in Variables by ID.
var y = document.getElementById("theDiv");
var createform2 = document.createElement('form'); // Create New Element Form
createform2.setAttribute("action", ""); // Setting Action Attribute on Form
createform2.setAttribute("method", "post"); // Setting Method Attribute on Form
y.appendChild(createform2);

var heading2 = document.createElement('h2'); // Heading of Form
heading2.innerHTML = "Post 1996 Data Classification";
createform2.appendChild(heading2);

var line2 = document.createElement('hr'); // Giving Horizontal Row After Heading
createform2.appendChild(line2);

var linebreakx = document.createElement('br');
createform2.appendChild(linebreakx);
/******************************************************************************************/
// Create Labels and Inputs For Post 1996 Data
/******************************************************************************************/

//Radius
var Radius = document.createElement('label'); // Create Label for Field
Radius.innerHTML = "Radius"; // Set Field Labels
createform2.appendChild(Radius);
var radiusInelement = document.createElement('input'); // Create Input Field for  Field
radiusInelement.setAttribute("type", "text");
radiusInelement.setAttribute("name", "radius");
createform2.appendChild(radiusInelement);
var linebreak9 = document.createElement('br');
createform2.appendChild(linebreak9);

//Texture
var texturelabel = document.createElement('label');
texturelabel.innerHTML = "Texture";
createform2.appendChild(texturelabel);
var textureInelement = document.createElement('input');
textureInelement.setAttribute("type", "text");
textureInelement.setAttribute("name", "texture");
createform2.appendChild(textureInelement);
var linebreakt = document.createElement('br');
createform2.appendChild(linebreakt);

//Perimeter
var perimeterlabel = document.createElement('label');
perimeterlabel.innerHTML = "Perimeter";
createform2.appendChild(perimeterlabel);
var perimeterInelement = document.createElement('input');
perimeterInelement.setAttribute("type", "text");
perimeterInelement.setAttribute("name", "perimeter");
createform2.appendChild(perimeterInelement);
var linebreak10 = document.createElement('br');
createform2.appendChild(linebreak10);

//Area
var arealabel = document.createElement('label');
arealabel.innerHTML = "area";
createform2.appendChild(arealabel);
var areaInelement = document.createElement('input');
areaInelement.setAttribute("type", "text");
areaInelement.setAttribute("name", "area");
createform2.appendChild(areaInelement);
var linebreak20 = document.createElement('br');
createform2.appendChild(linebreak20);

//Smoothness
var smoothnesslabel = document.createElement('label');
smoothnesslabel.innerHTML = "Smoothness";
createform2.appendChild(smoothnesslabel);
var smoothnessInelement = document.createElement('input');
smoothnessInelement.setAttribute("type", "text");
smoothnessInelement.setAttribute("name", "smoothness");
createform2.appendChild(smoothnessInelement);
var linebreak11 = document.createElement('br');
createform2.appendChild(linebreak11);

//Compactness
var compactnesslabel = document.createElement('label');
compactnesslabel.innerHTML = "Compactness";
createform2.appendChild(compactnesslabel);
var compactnessInelement = document.createElement('input');
compactnessInelement.setAttribute("type", "text");
compactnessInelement.setAttribute("name", "compactness");
createform2.appendChild(compactnessInelement);
var linebreak12 = document.createElement('br');
createform2.appendChild(linebreak12);

//Concavity
var concavitylabel = document.createElement('label');
concavitylabel.innerHTML = "Concavity";
createform2.appendChild(concavitylabel);
var concavityInelement = document.createElement('input');
concavityInelement.setAttribute("type", "text");
concavityInelement.setAttribute("name", "concavity");
createform2.appendChild(concavityInelement);
var linebreak14 = document.createElement('br');
createform2.appendChild(linebreak14);

//Concave Points
var ConcavePTlabel = document.createElement('label');
ConcavePTlabel.innerHTML = "Concave Points";
createform2.appendChild(ConcavePTlabel);
var ConcavePTInelement = document.createElement('input');
ConcavePTInelement.setAttribute("type", "text");
ConcavePTInelement.setAttribute("name", "ConcavePT");
createform2.appendChild(ConcavePTInelement);
var linebreak15 = document.createElement('br');
createform2.appendChild(linebreak15);

//Symmetry
var symmetrylabel = document.createElement('label');
symmetrylabel.innerHTML = "Symmetry";
createform2.appendChild(symmetrylabel);
var symmetryInelement = document.createElement('input');
symmetryInelement.setAttribute("type", "text");
symmetryInelement.setAttribute("name", "symmetry");
createform2.appendChild(symmetryInelement);
var linebreak16 = document.createElement('br');
createform2.appendChild(linebreak16);

//Fractal Demension
var fractallabel = document.createElement('label');
fractallabel.innerHTML = "Fractal Demension";
createform2.appendChild(fractallabel);
var fractalInelement = document.createElement('input');
fractalInelement.setAttribute("type", "text");
fractalInelement.setAttribute("name", "fractal");
createform2.appendChild(fractalInelement);
var linebreak17 = document.createElement('br');
createform2.appendChild(linebreak17);

/******************************************************************************************/

var submitelement2 = document.createElement('input'); // Append Submit Button
submitelement2.setAttribute("type", "submit");
submitelement2.setAttribute("name", "submitb");
submitelement2.setAttribute("value", "Results");
createform2.appendChild(submitelement2);




