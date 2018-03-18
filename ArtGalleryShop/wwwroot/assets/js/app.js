import { getText } from './lib';

import '../../../node_modules/bootstrap/dist/css/bootstrap.min.css';
import '../css/custom.css';

import ES6Lib from './es6codelib';

document.getElementById("fillthis").innerHTML = getText();

const Sample = (age) => {
    return `${age} anios de edad`;
};

$("#fillthisj").html(Sample(25));

let myES6Object = new ES6Lib();
$('#fillthiswithes6lib').html(myES6Object.getData());