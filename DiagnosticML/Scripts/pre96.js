// Fetching HTML Elements in Variables by ID.
var x = document.getElementById("theDiv");
var createform = document.createElement('form'); // Create New Element Form
createform.setAttribute("action", ""); // Setting Action Attribute on Form
createform.setAttribute("method", "post"); // Setting Method Attribute on Form
x.appendChild(createform);

var heading = document.createElement('h2'); // Heading of Form
heading.innerHTML = "Pre 1996 Data Classification";
createform.appendChild(heading);

var line = document.createElement('hr'); // Giving Horizontal Row After Heading
createform.appendChild(line);

var linebreak = document.createElement('br');
createform.appendChild(linebreak);

/******************************************************************************************/
// Create Labels and Inputs For Pre 1996 Data
/******************************************************************************************/

//Clump Thickness
var clumplabel = document.createElement('label'); // Create Label for Field
clumplabel.innerHTML = "Clump Thickness"; // Set Field Labels
createform.appendChild(clumplabel);
var clumpInelement = document.createElement('input'); // Create Input Field for  Field
clumpInelement.setAttribute("type", "text");
clumpInelement.setAttribute("name", "clump");
createform.appendChild(clumpInelement);
var linebreak1 = document.createElement('br');
createform.appendChild(linebreak1);

//Uniformity
var Uniformitylabel = document.createElement('label'); 
Uniformitylabel.innerHTML = "Uniformity of Cell Size/Shape"; 
createform.appendChild(Uniformitylabel);
var uniInelement = document.createElement('input'); 
uniInelement.setAttribute("type", "text");
uniInelement.setAttribute("name", "uni");
createform.appendChild(uniInelement);
var linebreak2 = document.createElement('br');
createform.appendChild(linebreak2);

//Marginal Adhesion
var marginallabel = document.createElement('label'); 
marginallabel.innerHTML = "Marginal Adhesion"; 
createform.appendChild(marginallabel);
var margInelement = document.createElement('input');
margInelement.setAttribute("type", "text");
margInelement.setAttribute("name", "marg");
createform.appendChild(margInelement);
var linebreak3 = document.createElement('br');
createform.appendChild(linebreak3);

//Single Epithelial Cell Size
var eplabel = document.createElement('label'); 
eplabel.innerHTML = "Single Epithelial Cell Size"; 
createform.appendChild(eplabel);
var epInelement = document.createElement('input');
epInelement.setAttribute("type", "text");
epInelement.setAttribute("name", "ep");
createform.appendChild(epInelement);
var linebreak4 = document.createElement('br');
createform.appendChild(linebreak4);

//Bare Nuclei
var nuclabel = document.createElement('label'); 
nuclabel.innerHTML = "Bare Nuclei         "; 
createform.appendChild(nuclabel);
var nucInelement = document.createElement('input');
nucInelement.setAttribute("type", "text");
nucInelement.setAttribute("name", "nuc");
createform.appendChild(nucInelement);
var linebreak5 = document.createElement('br');
createform.appendChild(linebreak5);

//Bland Chromatin
var blandlabel = document.createElement('label'); 
blandlabel.innerHTML = "Bland Chromatin"; 
createform.appendChild(blandlabel);
var blandInelement = document.createElement('input');
blandInelement.setAttribute("type", "text");
blandInelement.setAttribute("name", "bland");
createform.appendChild(blandInelement);
var linebreak6 = document.createElement('br');
createform.appendChild(linebreak6);

//Normal Nucleoli
var normlabel = document.createElement('label');
normlabel.innerHTML = "Normal Nucleoli"; 
createform.appendChild(normlabel);
var normInelement = document.createElement('input');
normInelement.setAttribute("type", "text");
normInelement.setAttribute("name", "norm");
createform.appendChild(normInelement);
var linebreak7 = document.createElement('br');
createform.appendChild(linebreak7);

//Mitosis
var mitosislabel = document.createElement('label'); 
mitosislabel.innerHTML = "Mitosis"; 
createform.appendChild(mitosislabel);
var mitosisInelement = document.createElement('input');
mitosisInelement.setAttribute("type", "text");
mitosisInelement.setAttribute("name", "mitosis");
createform.appendChild(mitosisInelement);
var linebreak8 = document.createElement('br');
createform.appendChild(linebreak8);

var submitelement = document.createElement('input'); // Append Submit Button
submitelement.setAttribute("type", "submit");
submitelement.setAttribute("name", "submita");
submitelement.setAttribute("value", "Results");
createform.appendChild(submitelement);
/******************************************************************************************/



