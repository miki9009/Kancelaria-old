

function openBasicz(parameter) {
    closeContent('basic');
    closeContent('participants');
    closeContent('repetytory');
    closeContent('caseInformation');
    closeContent('communicationDetriment');
    document.getElementById(parameter).style.display = 'block';
}

function removeElement(parameter) {
    document.getElementById(parameter).remove();
}


function closeContent(parameter) {
    document.getElementById(parameter).style.display = 'none';
}

function openContent(parameter) {
    document.getElementById(parameter).style.display = 'block';
}



function textAreaAdjust(o) {
    o.style.height = "1px";
    o.style.height = 25 + o.scrollHeight + "px";
}

function onLoadLast(element) {
    document.addEventListener("DOMContentLoaded", function (event) {
        openBasicz(element);
    });
}


//jesli boolean == true, element zostanie rozwiniety
function onLoad(bool, element) {
    document.addEventListener("DOMContentLoaded", function (event) {
        if (bool === "True") {
            resizeContent(element);
        }
    });
}



function resizeContent(parameter) {
    if (document.getElementById(parameter).style.display === 'none') {
        openContent(parameter);
    }
    else {
        closeContent(parameter);
    }
}


//Jeśli wartość elementu == True zmienia go i na False i odwrotnie, pole zostaje zapisane do Modelu, po wczytaniu element sie rozwinie za pomoca funkcji onLoad
function changeBool(element) {
    var val = document.getElementById(element).value;
    if (val === "True") {
        document.getElementById(element).value = "False";
    }
    else {
        document.getElementById(element).value = "True";
    }

}

function changeOverlapInt(parameter) {
    document.getElementById('idvarover').value = parameter;
}

function printpage() {


    
    var restorePage = document.body.innerHTML;

    document.getElementById('participants').style.display = "block";
    document.getElementById('caseInformation').style.display = "block";
    document.getElementById('communicationDetriment').style.display = "block";
    document.getElementById('orzeczenie').style.display = "block";
    document.getElementById('apelacja').style.display = "block";
    document.getElementById('kasacja').style.display = "block";
    document.getElementById('klauzula').style.display = "block";
    document.getElementById('egzekucja').style.display = "block";

    document.getElementById('summon1').style.display = "block";
    document.getElementById('summon2').style.display = "block";
    document.getElementById('summon3').style.display = "block";
    document.getElementById('summon4').style.display = "block";
    document.getElementById('summon5').style.display = "block"; 
    
    document.getElementById('oSummon1').style.display = "block";
    document.getElementById('oSummon2').style.display = "block";
    document.getElementById('oSummon3').style.display = "block";
    document.getElementById('oSummon4').style.display = "block";
    document.getElementById('oSummon5').style.display = "block";

    document.getElementById('aSummon1').style.display = "block";
    document.getElementById('aSummon2').style.display = "block";
    document.getElementById('aSummon3').style.display = "block";
    document.getElementById('aSummon4').style.display = "block";
    document.getElementById('aSummon5').style.display = "block";

    document.getElementById('kSummon1').style.display = "block";
    document.getElementById('kSummon2').style.display = "block";
    document.getElementById('kSummon3').style.display = "block";
    document.getElementById('kSummon4').style.display = "block";
    document.getElementById('kSummon5').style.display = "block";
    
    //PODSTAWOWE
    if (document.getElementById('print-basic').checked) {
        document.getElementById('basic').style.display = "block";
    }
    else {
        document.getElementById('basic').style.display = "none";
    }

    //Participants
    if (document.getElementById('print-participants').checked) {
        document.getElementById('participants').style.display = "block";
    }
    else {
        document.getElementById('participants').style.display = "none";
    }

    //Wartość roszczenia i wezwanie do zapłaty
    if (document.getElementById('print-value').checked) {
        document.getElementById('main-repetytory').style.display = "block";
    }
    else {
        document.getElementById('main-repetytory').style.display = "none";
    }
  
    //Pozew
    if (document.getElementById('print-summons').checked) {
        document.getElementById('summons-div').style.display = "block";
        if (document.getElementById('print-claim-cases').checked) {
            document.getElementById('summons-cases').style.display = "block";
        }
        else {
            document.getElementById('summons-cases').style.display = "none";
        }
    }
    else {
        document.getElementById('summons-div').style.display = "none";
    }

    //Orzeczenie I instancji
    if (document.getElementById('print-judgment').checked) {
        document.getElementById('judgment-div').style.display = "block";
        if (document.getElementById('print-judgment-cases').checked) {
            document.getElementById('judgment-cases').style.display = "block";
        }
        else {
            document.getElementById('judgment-cases').style.display = "none";
        }
    }
    else {
        document.getElementById('judgment-div').style.display = "none";
    }

    //Apelacja II instancji
    if (document.getElementById('print-appeal').checked) {
        document.getElementById('appeal-div').style.display = "block";
        if (document.getElementById('print-appeal-cases').checked) {
            document.getElementById('appeal-cases').style.display = "block";
        }
        else {
            document.getElementById('appeal-cases').style.display = "none";
        }
    }
    else {
        document.getElementById('appeal-div').style.display = "none";
    }
    
    //Skarga kasacyjna
    if (document.getElementById('print-cassation').checked) {
        document.getElementById('cassation-div').style.display = "block";
        if (document.getElementById('print-cassation-cases').checked) {
            document.getElementById('cassation-cases').style.display = "block";
        }
        else {
            document.getElementById('cassation-cases').style.display = "none";
        }
    }
    else {
        document.getElementById('cassation-div').style.display = "none";
    }

    //Postępowanie klauzulowe
    if (document.getElementById('print-clause').checked) {
        document.getElementById('clause-div').style.display = "block";
    }
    else {
        document.getElementById('clause-div').style.display = "none";
    }

    //Postępowanie egzekucyjne
    if (document.getElementById('print-execution').checked) {
        document.getElementById('execution-div').style.display = "block";
    }
    else {
        document.getElementById('execution-div').style.display = "none";
    }

    //Informacje o sprawie
    if (document.getElementById('print-info').checked) {
        document.getElementById('caseInformation').style.display = "block";
    }
    else {
        document.getElementById('caseInformation').style.display = "none";
    }
    
    //Postępowanie egzekucyjne
    if (document.getElementById('print-additional').checked) {
        document.getElementById('communicationDetriment').style.display = "block";
    }
    else {
        document.getElementById('communicationDetriment').style.display = "none";
    }

    document.getElementById('icons').style.display = "none"; 
    document.getElementById('navbar-case').style.display = "none";

    document.getElementById('edit-nav').style.display = "none";

    var printcontent = document.getElementById('mainForm').innerHTML;
    
    document.body.innerHTML = printcontent;
  
    setTimeout(function () {
        window.print();
        document.body.innerHTML = restorePage;
        closeContent('print-prompt');
    }, 1000); 

        
        


}