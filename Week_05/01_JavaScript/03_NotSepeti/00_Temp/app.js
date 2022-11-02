'use strict';

let btnAdd = document.getElementById('btnAddNewTask');
let txtTaskName = document.getElementById('txtTaskName');
btnAdd.addEventListener('click', newTask);
txtTaskName.addEventListener('keypress', function (event) {
    if (event.key == 'Enter') {
        btnAdd.click();
        event.preventDefault();

    }
});

 let notSepeti=[
//     { 'id':1,'gorevAdi':'Görev 1'},
//     {'id':2,'gorevAdi':'Görev 2'},
//     {'id':3,'gorevAdi':'Görev 3' },
//     {'id':4,'gorevAdi':'Görev 4' }

 ];

if (localStorage.getItem('notSepeti')!=null) {
    notSepeti=JSON.parse(localStorage.getItem('notSepeti'));
    console.log(notSepeti);
}

function displayTasks(){
let div=document.getElementById('task-list');
div.innerHTML = '';
for (const gorev of notSepeti) {
    let input=`
                <input type="text"  id="${gorev.id}" class="deneme" value="${gorev.gorevAdi}" disabled>
                <button onclick="removeTask(${gorev.id})" class="clear"><i class="fa-solid fa-trash trash"></i></button>
                <button onclick="updateStatus(this)" class="tik" id="${gorev.id}"><i class="fa-regular fa-square-check tic"></i></button>
               
    `;
    div.insertAdjacentHTML('beforeend',input);
}
}


function newTask(event) {
    event.preventDefault();
    if (isFull(txtTaskName.value) == true) {
        notSepeti.push(
            {
                'id': notSepeti.length + 1,
                'gorevAdi': İlkHarfBuyut(txtTaskName.value)
            }
        );
        displayTasks();


    }

    else {
        alert('lütfen boş bırakma');

    }
    txtTaskName.value = '';
    txtTaskName.focus();
    saveLocal()
};

function isFull(value) {
    if (value.trim() == '') {
        return false;
    }
    return true;
};


function İlkHarfBuyut(value) {
    let ilkHarf = value[0].toUpperCase();
    let geriKalan = value.slice(1);
    return ilkHarf + geriKalan;
}


function removeTask(id) {
    let deletedId;
    for (const gorevIndex in notSepeti) {
            if (notSepeti[gorevIndex].id==id) {
                deletedId=gorevIndex;
            }         
        };
        notSepeti.splice(deletedId,1);
        displayTasks();
        saveLocal()
    }



function updateStatus(selectedTask) {
    let input=selectedTask.previousElementSibling.previousElementSibling;
    console.log(input);
   
    if (selectedTask.checked) {
        input.classList.add('checked');
       console.log('Selem');
        
    }
    else {

        input.classList.remove('checked');
    }
        

    saveLocal()

}

function saveLocal(){
    localStorage.setItem('notSepeti',JSON.stringify(notSepeti));

}



displayTasks();
