
let dataFill = [{ x: '2021-04-26', y: 60 }, { x: '2021-04-25', y: 59 }, { x: '2021-04-24', y: 59 }, { x: '2021-04-23', y: 58 }, { x: '2021-04-22', y: 59 }, { x: '2021-04-21', y: 58 }
    , { x: '2021-04-20', y: 57 }, { x: '2021-04-19', y: 56 }, { x: '2021-04-18', y: 57 }, { x: '2021-04-17', y: 57 }, { x: '2021-04-16', y: 58 }];

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