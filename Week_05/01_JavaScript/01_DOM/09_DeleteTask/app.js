'use strict'; // let falan kullanmak zorunlu olsun diye yazdık

let btnAdd = document.getElementById('btnAddNewTask');
let txtTaskName = document.getElementById('txtTaskName');

btnAdd.addEventListener('click', newTask);
txtTaskName.addEventListener('keypress', function (event) {
    if (event.key == 'Enter') {
        btnAdd.click();
        event.preventDefault();

    }
});


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
    for (const gorev of gorevListesi) {
        let li = `
    <li class=" task list-group-item">
      <div class="form-check">
          <input type="checkbox"  id="${gorev.id}" class="form-check-input"> 
          <label for="${gorev.id}" class="form-check-label">${gorev.gorevAdi}</label>
      </div>

        <div class="dropdown">
            <button class="btn btn-link dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
            <i class="fa-solid fa-ellipsis"></i> 
            </button>
        <ul class="dropdown-menu ">
            <li><a onclick="removeTask(${gorev.id})" class="dropdown-item" href="#"><i class="fa-solid fa-trash"></i> Sil </a></li>
            <li><a class="dropdown-item" href="#"><i class="fa-solid fa-pen"></i> Düzenle </a></li>
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
    if (isFull(txtTaskName.value) == true) {
        gorevListesi.push(
            {
                'id': gorevListesi.length + 1,
                'gorevAdi': İlkHarfBuyut(txtTaskName.value)
            }
        );
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


//ilk harfi nüyük
function UpperKelime(value) {

    return value.charAt(0).toUpperCase() + value.slice(1).toLowerCase();
}

//her kelimenin ilk harfi büyük
function UpperKelimeler(str) {
    let parcalar = str.split(" ");
    for (let i = 0; i < parcalar.length; i++) {
        let j = parcalar[i].charAt(0).toUpperCase();
        parcalar[i] = j + parcalar[i].substr(1).toLowerCase();
    }
    return parcalar.join(" ");
}

function removeTask(id) {
    let deletedId;
    for (const gorevIndex in gorevListesi) {
            if (gorevListesi[gorevIndex].id==id) {
                deletedId=gorevIndex;
            }         
        };



    //bu kod üstteki kodun birz kısası
    // deletedId=gorevListesi.findIndex(function(gorev){
    //     return gorev.id==id;
    // })


    //buda bir üstteki kodun kısası
    // deletedId=gorevListesi.findIndex(gorev => gorev.id==id);
        
    
    
    
    
    
    //artık görevlistesi dizisinden kaçıncı sıradaki elemanın silineceğini biliyoruz. deletedId sıradaki elemanı sileceğiz.
        gorevListesi.splice(deletedId,1);
        displayTasks();
    }

displayTasks();






