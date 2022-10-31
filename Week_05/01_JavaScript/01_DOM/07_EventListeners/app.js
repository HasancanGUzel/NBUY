'use strict'; // let falan kullanmak zorunlu olsun diye yazdık


let gorevListesi=[
    {
        'id':1,
        'gorevAdi':'Görev 1' // böylede tanımlanır
    },
    {'id':2,'gorevAdi':'Görev 2'},// böylede
    {'id':3,'gorevAdi':'Görev 3' },
    {'id':4,'gorevAdi':'Görev 4' },
    {'id':5,'gorevAdi':'Görev 5' }

];

let ul=document.getElementById('task-list');
// let ul=document.querySelector('#task-list');// üsttekinin aynısı

for (const gorev of gorevListesi) {
    let li=`
    <li class=" task list-group-item">
      <div class="form-check">
          <input type="checkbox"  id="${gorev.id}" class="form-check-input"> 
          <label for="${gorev.id}" class="form-check-label">${gorev.gorevAdi}</label>
      </div>
    </li>
    `;
    ul.insertAdjacentHTML('beforeend',li);
}
// let btnEkle=document.querySelector('#btnAddNewTask');
// btnEkle.addEventListener('click',function(event) {
//     //btnEkle adlı elemnte tıklandığı zaman çalışacak kodlar burada
//     //buraya gelen event parametresi ilgili elemntin gerçekleşen clik olayı ile ilgili bilgileri barındırıyor
//     event.preventDefault();// default olan özleliklerini kaldırır yani sayfa yenileme özelliği vardı kalktı gibi gibi

//     console.log('btnEkleye tıklandı');
// });

// let btnTemizle=document.querySelector('#btnClear');
// btnTemizle.addEventListener('click',clearAll);

// function clearAll(event) 
// {
//     event.preventDefault();
//     console.log('tıklandı');
// }


let btnAdd=document.querySelector('#btnAddNewTask');
btnAdd.addEventListener('listener',newTask)

function newTask(event) {
    event.preventDefault();
    event.target.classList.add('btn-warning');
    event.target.style.display='none';
    console.log(event.target);
    
}







