let pages = ['home', 'calculation', 'surface', 'threads'];
let mapPoints = document.querySelectorAll('.map-point');
let leftArrow = document.getElementById('left-arrow');
let rightArrow = document.getElementById('right-arrow');
let graphicStub = document.getElementById('graphic-stub');
let barChartStub = document.getElementById('bar-chart-stub');
let currentPage = 0;
let errors = {
    x: false,
    y: false,
    step: false
};

for (let i = 0; i < mapPoints.length; i++) {
    mapPoints[i].onclick = jumpFromMap;
}

window.onload = initialize;

function initialize() {
   
    let regexp = /[#].+$/;
    let href = location.href;
    let id = regexp.exec(href);
    let newId = null;

    if (id) {
        newId = id[0].replace('#', '');
        currentPage = pages.indexOf(newId);
        jump(newId);
    }
}

function getData() {
    let xSt = document.getElementById('x-st');
    let xFin = document.getElementById('x-fin');
    let ySt = document.getElementById('y-st');
    let yFin = document.getElementById('y-fin');
    let step = document.getElementById('step');

    if (xSt.value === '') {
        xSt = +xSt.placeholder;
    } else {
        xSt = +xSt.value;
    }

    if (xFin.value === '') {
        xFin = +xFin.placeholder;
    } else {
        xFin = +xFin.value;
    }

    if (ySt.value === '') {
        ySt = +ySt.placeholder;
    } else {
        ySt = +ySt.value;
    }

    if (yFin.value === '') {
        yFin = +yFin.placeholder;
    } else {
        yFin = +yFin.value;
    }

    if (step.value === '') {
        step = +step.placeholder;
    } else {
        step = +step.value;
    }

    return {
        xSt: xSt,
        xFin: xFin,
        ySt: ySt,
        yFin: yFin,
        step: step
    };
}

function jump(id) {
    location.href = "#" + id;                 //Go to the target element.
    document.querySelector('.chosen-point').classList.remove('chosen-point');
    mapPoints[pages.indexOf(id)].classList.add('chosen-point');

    currentPage = pages.indexOf(id);

    if (currentPage === 0) {
        leftArrow.style.opacity = '0';
        setTimeout(function () {
            leftArrow.style.visibility = 'hidden';
        }, 200);
        rightArrow.style.visibility = 'visible';
        rightArrow.style.opacity = '1';
    } else if (currentPage > 0 && currentPage < 3) {
        leftArrow.style.visibility = 'visible';
        leftArrow.style.opacity = '1';
        rightArrow.style.visibility = 'visible';
        rightArrow.style.opacity = '1';
    } else {
        rightArrow.style.opacity = '0';
        setTimeout(function () {
            rightArrow.style.visibility = 'hidden';
        }, 200);
        leftArrow.style.visibility = 'visible';
        leftArrow.style.opacity = '1';
    }
}

function jumpFromMap(event) {
    let id = event.target.id;
    let newId = id.slice(0, id.length - 6);

    jump(newId);
}

function jumpToLeft() {
    if (currentPage > 0) {
        currentPage--;
    }

    if (currentPage === 0) {
        leftArrow.style.opacity = '0';
        setTimeout(function () {
            leftArrow.style.visibility = 'hidden';
        }, 200);
    } else {
        leftArrow.style.visibility = 'visible';
        leftArrow.style.opacity = '1';
    }

    if (currentPage < 3) {
        rightArrow.style.visibility = 'visible';
        rightArrow.style.opacity = '1';
    }

    jump(pages[currentPage]);
}

function jumpToRight() {
    if (currentPage < 3) {
        currentPage++;
    }

    if (currentPage === 3) {
        rightArrow.style.opacity = '0';
        setTimeout(function () {
            rightArrow.style.visibility = 'hidden';
        }, 200);
    } else {
        rightArrow.style.visibility = 'visible';
        rightArrow.style.opacity = '1';
    }

    if (currentPage > 0) {
        leftArrow.style.visibility = 'visible';
        leftArrow.style.opacity = '1';
    }

    jump(pages[currentPage]);
}

function checkError() {
    let data = getData();

    if (data.xSt > data.xFin) {
        errors.x = true;
        document.getElementById('x-st').style.borderColor = 'red';
        document.getElementById('x-st-error').style.opacity = '1';
        document.getElementById('x-fin').style.borderColor = 'red';
        document.getElementById('x-fin-error').style.opacity = '1';
    } else {
        errors.x = false;
        document.getElementById('x-st').style.borderColor = '#e4e4e4';
        document.getElementById('x-st-error').style.opacity = '';
        document.getElementById('x-fin').style.borderColor = '#e4e4e4';
        document.getElementById('x-fin-error').style.opacity = '';
    }

    if (data.ySt > data.yFin) {
        errors.y = true;
        document.getElementById('y-st').style.borderColor = 'red';
        document.getElementById('y-st-error').style.opacity = '1';
        document.getElementById('y-fin').style.borderColor = 'red';
        document.getElementById('y-fin-error').style.opacity = '1';
    } else {
        errors.y = false;
        document.getElementById('y-st').style.borderColor = '#e4e4e4';
        document.getElementById('y-st-error').style.opacity = '';
        document.getElementById('y-fin').style.borderColor = '#e4e4e4';
        document.getElementById('y-fin-error').style.opacity = '';
    }

    if (data.step <= 0) {
        errors.step = true;
        document.getElementById('step').style.borderColor = 'red';
        document.getElementById('step-error').style.opacity = '1';
    } else {
        errors.step = false;
        document.getElementById('step').style.borderColor = '#e4e4e4';
        document.getElementById('step-error').style.opacity = '';
    }

    if (errors.x === false && errors.y === false && errors.step === false) {
        calcButton.disabled = false;
    } else {
        calcButton.disabled = true;
    }
}

function showResults() {
    debugger;
    if (errors.x === false && errors.y === false && errors.step === false) {
        let data = getData();

        graphicStub.style.visibility = 'visible';
        barChartStub.style.visibility = 'visible';

        document.getElementById('graphic-loading-span').innerHTML = 'Calculating...';
        document.getElementById('bar-loading-span').innerHTML = 'Calculating...';

        jump('surface');

        draw3dGraphic(data.xBeg, data.xFin, data.yBeg, data.yFin, data.step);
        drawBarChart(3, [123, 12, 3]);

        setTimeout(function () {
            graphicStub.style.visibility = 'hidden';
            barChartStub.style.visibility = 'hidden';
        }, 1000);
    } else {
        graphicStub.style.visibility = 'visible';
        barChartStub.style.visibility = 'visible';
        document.getElementById('graphic-loading-span').innerHTML = 'Waiting for data entry...';
        document.getElementById('bar-loading-span').innerHTML = 'Waiting for data entry...';
    }
}

function draw3dGraphic(xBeg, xFin, yBeg, yFin, step) {
    let A = 2;
    let B = 2;
    let C = 3;
    let D = 3;

    let Z = [];

    for (let x = xBeg; x <= xFin; x += step) {
        let tempX = [];

        for (let y = yBeg; y <= yFin; y += step) {
            let z = A * Math.pow(x, 2) + B * Math.pow(y, 2) + C * Math.exp(-1 * x) + D * Math.exp(-1 * y);

            tempX.push(z);
        }

        Z.push(tempX);
    }

    debugger;

    var data = [{
        z: Z,
        type: 'surface',
        "showscale": false,
        "colorscale": [
            [
                0,
                "#ff9800"
            ],
            [
                1,
                "#ff9800"
            ]
        ],
        "autocolorscale": false,
        autosize: true
    }];

    var layout = {
        font: {
            size: 18,
            color: 'rgb(24, 40, 64)',
            family: 'Raleway'
        },
        autosize: true,
        scene: {
            xaxis: {
                showticklabels: false
            },
            yaxis: {
                showticklabels: false
            },
            zaxis: {
                showticklabels: false
            }
        }
    };

    setTimeout(function () {
        Plotly.newPlot('graphic', data, layout);
    }, 1000)
}

function drawBarChart(threadsCount, timings) {
    let threads = [];

    for (let i = 1; i <= threadsCount; i++) {
        threads.push(i);
    }

    var data = [
        {
            x: threads,
            y: timings,
            type: 'bar',
            marker: {
                color: '#ff9800',
                line: {
                    width: 1,
                    color: '#444'
                }
            },
            autosize: true
        }
    ];

    var layout = {
        font: {
            size: 18,
            color: 'rgb(24, 40, 64)',
            family: 'Raleway'
        },
        autosize: true,
        margin: {
            l: 80,
            r: 40,
            t: 40,
            b: 40
        },
        xaxis: {
            dtick: 1
        },
        yaxis: {
            title: {
                text: 'sec'
            }
        }
    };

    Plotly.newPlot('bar-chart', data, layout);
}
