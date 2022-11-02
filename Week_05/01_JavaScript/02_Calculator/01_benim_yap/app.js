const display = document.querySelector('.calculator-input');
const keys = document.querySelector('.calculator-keys');


let displayValue = '0';
let firstValue = null;
let operator = null;
let waitingForSecondValue = false;

updateDisplay();

function updateDisplay() {
    display.value = displayValue.replace('.',',');

}

keys.addEventListener('click', function (event) {

    const element = event.target;
    const value=element.value;
    if (!element.matches('button')) return; /* basılan event.target yani element butona eşit değilse buraya uğramıyor */
    
    switch (value) {
        case '+':
        case '-':
        case '*':
        case '/':
        case '=':
            handleOperator(value);        
            break;

        case '.':
            inputDecimal();
            break;
        case 'clear':
            clearDisplay();
            break;   
    
        default:
            inputNumber(value);
            break;
    }
     
   
   
   
    // if (element.classList.contains('operator')) {
    //     handleOperator(element.value);       
    //     return;
    // }
    // if (element.classList.contains('decimal')) {
    //     inputDecimal();
    //     return;
    // }
    // if (element.classList.contains('clear')) {
    //     clearDisplay();
    //     return;
    // }

    // inputNumber(element.value);





});

function inputNumber(num) {
    // displayValue=num;
    // displayValue+=num;
    if (waitingForSecondValue == true) {
        displayValue = num;
        waitingForSecondValue = false;
    }
    else {
        displayValue = displayValue == '0' ? num : displayValue + num;
    }
    updateDisplay();

}

function inputDecimal() {
    if (!displayValue.includes('.')) {

        displayValue += '.';

        updateDisplay();

    }

}

function clearDisplay() {

    displayValue = '0';
    firstValue=null;
    operator=null;
    waitingForSecondValue=false;
    updateDisplay();

}

function handleOperator(nextOperator) {

    let value = parseFloat(displayValue);
    if (!operator == '' && waitingForSecondValue == true) {
        operator = nextOperator;
        return;
    }
    if (firstValue == null) {
        firstValue = value;
    }
    else if (!operator == '') {
        const result = calculate(firstValue, operator, value);
        displayValue = String(result);
        firstValue = result;

    }
    waitingForSecondValue = true;
    operator = nextOperator;
    updateDisplay();
}

function calculate(num1, op, num2) {
    if (op === '+') {
        return num1 + num2;
    }
    if (op === '-') {
        return num1 - num2;
    }
    if (op === '*') {
        return num1 * num2;
    }
    if (op === '/') {
        return num1 / num2;
    }
    return num2;

}







//benim yaptığım
// function button() {
//     document.querySelectorAll('button').forEach(item => {
//         item.addEventListener('click', (e) => {
//             display.value += e.target.value;
//         })
//     })
// };



// function Clear() {
//     document.querySelector('.clear').addEventListener('click', function() {
//         if(!display.value == '') {
//             display.value = '0';
//         }
//     });
// }

//benim yaptığım
// display.value='';
// Clear();
// button();