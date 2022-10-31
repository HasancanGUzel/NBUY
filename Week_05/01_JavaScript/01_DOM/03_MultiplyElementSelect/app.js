let sonuc;
// getElementById
// sonuc=document.getElementById('title');
// sonuc=document.getElementById('title').id;
// sonuc=document.getElementById('title').className;
// sonuc=document.getElementById('title').classList;


// // burada style etketleri camelCase olarak adlandırılır
// document.getElementById('title').style.fontSize='70px';
// document.getElementById('title').style.color='red';
// // document.getElementById('title').style.display='none';


// // getElementById sadece ID seçer ama query selector her elemnti seçer
// //querySelector getElementById gibi ama bunda parantez içine style gibi id ye # işareti class olursa '.' işareti konur 
// sonuc=document.querySelector('#title')// geriye tek bir değer döndürür
// sonuc=document.querySelector('div')//ilk karşılatğını seçer
// sonuc=document.querySelector('.h1')


// sonuc=document.querySelector('li');//ilk karşılaştığını seçer
// sonuc=document.querySelector('li:first-child');//first-chil ilk çocuk demek ilk elemnti seçer
// sonuc=document.querySelector('li:last-child');//last-child son çocuk demek son elemnti seçer
// sonuc=document.querySelector('li:nth-child(2)');//nth-child ise li lerin içinde prantez içine yazılan li yi seçer



//getElementByClassName classı seçer adı üstünde class Name olduğu için  parantez içine sadece class adını yazarız '.' koymamıza gerek yok
// geriye birden çok sonuç döndürür
sonuc=document.getElementsByClassName('card-header');
sonuc=document.getElementsByClassName('task');// tüm task class larını diziye atıp bize döndürür
sonuc=document.getElementsByClassName('task')[0];// dizinin içinde 0 indexi olanı getridik
sonuc=document.getElementsByClassName('task')[0];// dizinin içinde 0 indexi olanı getridik
sonuc=document.getElementsByClassName('task');
// for (let i = 0; i < sonuc.length; i++) {
//     console.log(sonuc[i].innerText);
    
// }

let taskList=document.getElementsByClassName('task');
// for (const task of taskList) {
//     task.style.color='red';
//     task.style.fontSize='60px';
//     task.innerText='ITEM';
    
// }

let taskList2=document.getElementById('task-list-2');//tek bir değer döndürür
// sonuc=taskList2.getElementsByClassName('task');
sonuc=taskList2.getElementsByTagName('li');//geriye birden çok değer döndürür

sonuc=document.querySelectorAll('#task-list-2 li')// yukarıdaki örenğin tek satırlı hali aynısı..... geriye birden çok sonuç dödnürür
for (const gorev of sonuc) {
    gorev.style.backgroundColor='aqua';
    gorev.style.color='red';
}


console.log(sonuc);