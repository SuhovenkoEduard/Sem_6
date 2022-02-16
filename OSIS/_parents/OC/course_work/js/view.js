let graphicStub = document.getElementById('graphic-stub');
let barChartStub = document.getElementById('bar-chart-stub');
let calcButton = document.getElementById('calc-button');

calcButton.onclick = drawResults;

function drawResults() {
    graphicStub.style.visibility = 'visible';
    barChartStub.style.visibility = 'visible';

    setTimeout(function () {
        draw3dGraphic();
        drawBarChart();
    }, 100);

    setTimeout(function () {
        graphicStub.style.visibility = 'hidden';
        barChartStub.style.visibility = 'hidden';
    }, 100);

}

async function draw3dGraphic() {
    let A = 2;
    let B = 2;
    let C = 3;
    let D = 3;

    let xBeg = -60;
    let xEnd = 60;
    let yBeg = -60;
    let yEnd = 60;

    let Z = [];

    for (let x = xBeg; x <= xEnd; x++) {
        let tempX = [];

        for (let y = yBeg; y <= yEnd; y++) {
            let z = A * Math.pow(x, 2) + B * Math.pow(y, 2) + C * Math.exp(-1 * x) + D *  Math.exp(-1 * y);

            tempX.push(z);
        }

        Z.push(tempX);
    }

    var data = [{
        z: Z,
        type: 'surface',
        "showscale": false,
        "colorscale": [
            [
                0,
                "#31bfec"
            ],
            [
                1,
                "#31bfec"
            ]
        ],
        "autocolorscale": false
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

    Plotly.newPlot('graphic', data, layout);
}

async function drawBarChart() {
    var data = [
        {
            x: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
            y: [221, 123, 35, 28, 26, 20, 12, 10, 8, 7],
            type: 'bar',
            marker: {
                color: "rgb(49, 191, 236)"
            }
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
            l: 40,
            r: 40,
            t: 40,
            b: 40
        }
    };

    Plotly.newPlot('bar-chart', data, layout);
}