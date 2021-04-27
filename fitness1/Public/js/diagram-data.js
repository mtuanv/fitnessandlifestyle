$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "GetListProgress",
        success: function (result) {
            for (var i = 0; i < result.length; i++) {
                dataFill.push({ x: result[i].timestamp, y: result[i].CurrentWeight });
            }
        }
    });
})

let dataFill = [{ x: '2021-04-26', y: 20 }, { x: '2021-04-25', y: 45 }, { x: '2021-04-24', y: 55 }, { x: '2021-04-23', y: 54 }, { x: '2021-04-22', y: 12 }, { x: '2021-04-21', y: 34 }
    , { x: '2021-04-20', y: 42 }, { x: '2021-04-19', y: 24 }, { x: '2021-04-18', y: 37 }, { x: '2021-04-17', y: 48 }, { x: '2021-04-16', y: 34 }];

let data = {
    datasets: [{
        type: 'line',
        label: 'Weight',
        data: dataFill,
        borderColor : 'rgb(104,206,15)'

    }]
}

let option = {
    parsing: {
        xAxisKey: 'x',
        yAxisKey: 'y'
    },
    scales: {
        y: {
            grid: {
                borderColor: 'rgb(243,243,242)',
                color: 'rgba(255,255,255,0.5)',
            },
            ticks: {
                color: '#fff'
            },
        },
        x: {
            grid: {
                borderColor: 'rgb(243,243,242)',
                color: 'rgba(255,255,255,0.5)',
            },
            ticks: {
                color: '#fff'
            },
            title: {
                color: 'white',
                display: true,
            },
            type: 'time',
            time: {
                unit: 'week'
            }
        },
    }
}