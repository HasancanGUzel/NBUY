'use strict'; // let falan kullanmak zorunlu olsun diye yazdık

const btnAdd = document.getElementById('btnAddNewTask');
const txtTaskName = document.getElementById('txtTaskName');
const btnClear = document.getElementById('btnClear');
const filters = document.querySelectorAll('.filters span');
let isEditMode = false;//eğer bu false ise newTask modu  aktif true olur ise editTask aktif
let editedId;
btnAdd.addEventListener('click', newTask);
txtTaskName.addEventListener('keypress', function (event) {
    if (event.key == 'Enter') {
        btnAdd.click();
        event.preventDefault();

    }
});

btnClear.addEventListener('click', clearAll);
for (const span of filters) {
    span.addEventListener('click', function () {
        document.querySelector('span.active').classList.remove('active');
        span.classList.add('active');
        displayTasks(span.id);
    });
};

let gorevListesi = [
    // dinamik yapı apmak için local storage olarak tanımlıcaz
    // {
    //     'id': 1,
    //     'gorevAdi': 'Görev 1',// böylede tanımlanır
    //     'durum': 'pending'
    // },
    // { 'id': 2, 'gorevAdi': 'Görev 2', 'durum': 'pending' },// böylede
    // { 'id': 3, 'gorevAdi': 'Görev 3', 'durum': 'completed' },
    // { 'id': 4, 'gorevAdi': 'Görev 4', 'durum': 'pending' },
    // { 'id': 5, 'gorevAdi': 'Görev 5', 'durum': 'completed' }
];
if (localStorage.getItem('gorevListesi')!=null) {
    gorevListesi=JSON.parse(localStorage.getItem('gorevListesi'));
    console.log(gorevListesi);
}
    
let taskBox=document.getElementById('task-box');
function displayTasks(filter) {
    let ul = document.getElementById('task-list');
    ul.innerHTML = '';// yeni li üretmeden ul yi sildik sonra tekrardan ürettik
    if (gorevListesi.length == 0) {
        ul.innerHTML = '<span class="alert alert-danger mb-0  d-flex justify-content-center align-items-center">Görev Listeniz Boş</span>';
    }
    for (const gorev of gorevListesi) {
        let completed = gorev.durum == 'completed' ? 'checked' : '';
        if (filter == gorev.durum || filter=='all')
         {

            let li = `
            <li class=" task list-group-item">
            <div class="form-check">
                <input onclick="updateStatus(this)" type="checkbox"  id="${gorev.id}" class="form-check-input" ${completed}> 
                <label for="${gorev.id}" class="form-check-label ${completed} ">${gorev.gorevAdi}</label>
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
            </li>`;
            ul.insertAdjacentHTML('beforeend', li);
        };

    };

}



function newTask(event) {
    event.preventDefault();
    // let txtTaskName=document.getElementById('txtTaskName'); // bu her zaman lazımdı globalde tanımlıyoruz
    if (isFull(txtTaskName.value)) {
        if (!isEditMode) {
            //yeni kayıt işlemi
            let id;
            if (gorevListesi.length==0) {
                id=1;
            }
            else{
                id=gorevListesi[gorevListesi.length-1].id+1;
            }

            gorevListesi.push(
                {
                    'id': id,
                    'gorevAdi': İlkHarfBuyut(txtTaskName.value),
                    'durum':'pending'
                }
            );
        }
        else {
            // güncelleme işlemi
            for (const gorev of gorevListesi) {
                if (gorev.id == editedId) {
                    gorev.gorevAdi = İlkHarfBuyut(txtTaskName.value);
                    isEditMode = false;
                    btnAdd.innerText = 'Ekle';
                    taskBox.style.display='block';

                    break;

                }
            }
        }
        
    }
    else {
        alert('lütfen boş bırakma');

    }
    txtTaskName.value = '';// her butona tıklandıktan sonra içeriği boşaltıyoruz.
    displayTasks(document.querySelector('span.active').id);
    txtTaskName.focus();
    saveLocal();
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
    displayTasks(document.querySelector('span.active').id);
    saveLocal();

}


function editTask(id, gorevAdi) {
    editedId = id;
    isEditMode = true;
    txtTaskName.value = gorevAdi;
    txtTaskName.focus();
    btnAdd.innerText = 'Kaydet';
    taskBox.style.display='none';
    
    

}

function clearAll() {
    let cevap = confirm('Tüm görevler silinecek!');//confirm alert gibi ama tamam ve iptal tuşları çıkıyor alert de sadece uyarı mesajı çıkıyor
    if (cevap == true) {
        gorevListesi.splice(0);
        displayTasks('all');
        saveLocal();
    }



}


function updateStatus(selectedTask) {
    // console.log(selectedTask.parentElement.lastElementChild);
    // console.log(selectedTask.nextElementSibling);
    let label = selectedTask.nextElementSibling;
    let durum;
    if (selectedTask.checked) {
        label.classList.add('checked');
        durum='completed';
    }
    else {

        label.classList.remove('checked');
        durum='pending';
    };
    for (const gorev of gorevListesi) {
        if (gorev.id == selectedTask.id) {
            gorev.durum=durum;
        }
    }

    displayTasks(document.querySelector('span.active').id);
    saveLocal();



}

function saveLocal(){
        localStorage.setItem('gorevListesi',JSON.stringify(gorevListesi));

}


displayTasks('all');






