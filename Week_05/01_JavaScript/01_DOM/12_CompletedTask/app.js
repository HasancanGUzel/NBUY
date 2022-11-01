'use strict'; // let falan kullanmak zorunlu olsun diye yazdık

const btnAdd = document.getElementById('btnAddNewTask');
const txtTaskName = document.getElementById('txtTaskName');
const btnClear=document.getElementById('btnClear');
let isEditMode=false;//eğer bu false ise newTask modu  aktif true olur ise editTask aktif
let editedId;
btnAdd.addEventListener('click', newTask);
txtTaskName.addEventListener('keypress', function (event) {
    if (event.key == 'Enter') {
        btnAdd.click();
        event.preventDefault();

    }
});

btnClear.addEventListener('click',clearAll);


let gorevListesi = [
    {
        'id': 1,
        'gorevAdi': 'Görev 1' // böylede tanımlanır
    },
    { 'id': 2, 'gorevAdi': 'Görev 2' },// böylede
    { 'id': 3, 'gorevAdi': 'Görev 3' },
    { 'id': 4, 'gorevAdi': 'Görev 4' },
    { 'id': 5, 'gorevAdi': 'Görev 5' }

];


function displayTasks() {
    let ul = document.getElementById('task-list');
    ul.innerHTML = '';// yeni li üretmeden ul yi sildik sonra tekrardan ürettik
    if (gorevListesi.length==0) {
        ul.innerHTML='<span class="alert alert-danger mb-0  d-flex justify-content-center align-items-center">Görev Listeniz Boş</span>';
    }
    for (const gorev of gorevListesi) {
        let li = `
    <li class=" task list-group-item">
      <div class="form-check">
          <input onclick="updateStatus(this)" type="checkbox"  id="${gorev.id}" class="form-check-input"> 
          <label for="${gorev.id}" class="form-check-label ">${gorev.gorevAdi}</label>
      </div>

        <div class="dropdown">
            <button class="btn btn-link dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
            <i class="fa-solid fa-ellipsis"></i> 
            </button>
        <ul class="dropdown-menu ">
            <li><a onclick="removeTask(${gorev.id})" class="dropdown-item" href="#"><i class="fa-solid fa-trash"></i> Sil </a></li>
            <li><a onclick="editTask(${gorev.id},'${gorev.gorevAdi}')" class="dropdown-item" href="#"><i class="fa-solid fa-pen"></i> Düzenle </a></li>
        </ul>
        </div>
    </li>
    `;
        ul.insertAdjacentHTML('beforeend', li);
    }

}



function newTask(event) {
    event.preventDefault();
    // let txtTaskName=document.getElementById('txtTaskName'); // bu her zaman lazımdı globalde tanımlıyoruz
    if (isFull(txtTaskName.value)) {
        if (!isEditMode) {
            //yeni kayıt işlemi
            gorevListesi.push(
                {
                    'id': gorevListesi.length + 1,
                    'gorevAdi': İlkHarfBuyut(txtTaskName.value)
                }
            );
        }
        else{
            // güncelleme işlemi
            for (const gorev of gorevListesi) {
                if (gorev.id==editedId) {
                    gorev.gorevAdi=İlkHarfBuyut(txtTaskName.value);
                    isEditMode=false;
                    btnAdd.innerText='Ekle';
                    
                }
            }           
        }      
        displayTasks();
    }
    else {
        alert('lütfen boş bırakma');

    }
    txtTaskName.value = '';// her butona tıklandıktan sonra içeriği boşaltıyoruz.
    txtTaskName.focus();
};


function isFull(value) {
    if (value.trim() == '') {
        return false;
    }
    return true;
};

//hocanın yaptığı ilk harfi büyük
function İlkHarfBuyut(value) {
    let ilkHarf = value[0].toUpperCase();
    let geriKalan = value.slice(1);
    return ilkHarf + geriKalan;
}



function removeTask(id) {
    let deletedId;
    for (const gorevIndex in gorevListesi) {
        if (gorevListesi[gorevIndex].id == id) {
            deletedId = gorevIndex;
        }
    };


    gorevListesi.splice(deletedId, 1);
    displayTasks();
}


function editTask(id,gorevAdi) {
     editedId=id;
     isEditMode=true;
     txtTaskName.value=gorevAdi;
     txtTaskName.focus();
     btnAdd.innerText='Kaydet';
}

function clearAll() {
    let cevap=confirm('Tüm görevler silinecek!');//confirm alert gibi ama tamam ve iptal tuşları çıkıyor alert de sadece uyarı mesajı çıkıyor
    if (cevap==true) {
        gorevListesi.splice(0);
        displayTasks();
    }
   
    

}


function updateStatus(selectedTask) {
    // console.log(selectedTask.parentElement.lastElementChild);
    // console.log(selectedTask.nextElementSibling);
    let label=selectedTask.nextElementSibling;
    if (selectedTask.checked) {
        label.classList.add('checked');
    }
    else {

        label.classList.remove('checked');
    }



}


displayTasks();






