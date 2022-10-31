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

// document.querySelector('#task-list').remove();// id si task-list olan ul yi sildik
// document.querySelector('#task-list').parentElement.remove();// buda ul nin içinde bulunduğu card ile birlikte sildi çünkü adı üstünde parent
// document.querySelector('#task-list').children[0].remove();//ul nin childrenı olan linin 0 indexsini sildi.
// document.querySelector('#task-list').children[2].remove();

// document.querySelector('#task-list').removeAttribute('class');// bu task-list id si olan ulun içindeki class olan list-group bunu sildi
// document.querySelector('#task-list').children[1].removeAttribute('class');//buda id si task-list olan ulun çocuğu olan indexi 1 olan linin claası nı list -group-item ı sildi
let sonuc;
// sonuc=document.querySelector('#task-list').children[1].getAttribute('class');
// sonuc=document.querySelector('#task-list').children[1].setAttribute('class','bg-danger');


sonuc=document.querySelector('#task-list').children[1].classList;
document.querySelector('#task-list').children[1].classList.add('bg-danger');
sonuc=document.querySelector('#task-list').children[1].classList.contains('bg-danger');

console.log(sonuc);






