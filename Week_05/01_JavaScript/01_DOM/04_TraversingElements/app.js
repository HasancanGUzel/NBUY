let sonuc;
// let taskList=document.getElementById('task-list');
// sonuc=taskList.children;
// sonuc=taskList.children[0];
// sonuc=taskList.firstElementChild.innerText;
// sonuc=taskList.lastElementChild.innerText;

// sonuc=document.getElementById('title');
// sonuc=sonuc.parentElement.parentElement.parentElement;


// taskList=document.querySelector('.task');
// // sonuc=taskList.nextElementSibling.innerText;//normalde görev1 seçiyildi ama bu next yani bir sonraki olduğu için görev2 seçti
// sonuc=taskList.nextElementSibling.nextElementSibling;
// sonuc=sonuc.previousElementSibling.innerText;//buda aynı seviyedeki bir önceki li ye gitmeye çalışır. yani li 3tü şimdi li 2 yi yazar çünkü geri gttik
let ul=document.getElementById('task-list');
sonuc=ul.children;
sonuc=ul.children[0].children[0].children[0].checked=true;


console.log(sonuc);