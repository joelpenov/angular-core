import { getText } from './lib';

import ES6Lib from './es6codelib';
import '../../../node_modules/bootstrap/dist/css/bootstrap.min.css';
import '../css/template.css';
import '../css/custom.css';

document.getElementById("fillthis").innerHTML = getText();

const Sample = (age) => {
    return `${age} anios de edd`;
};

$("#fillthisj").html(Sample(25));

let myES6Object = new ES6Lib();
$('#fillthiswithes6lib').html(myES6Object.getData());

module.hot.accept();