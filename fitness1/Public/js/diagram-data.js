let data = {
    datasets: [{
        type: 'line',
        label: 'Weight',
        data: [12, 19, 3, 5, 2, 3],
        borderColor : 'rgb(104,206,15)'

    }, {
        type: 'line',
        label: 'BMI',
        data: [14, 5, 3, 8, 4, 3],
        borderColor : 'rgb(246,225,7)'

    }],
    labels: ['January', 'February', 'March', 'May', 'June'],
}

let option = {
    scales: {
        y: {
            grid : {
                borderColor : 'rgb(243,243,242)',
                color: 'rgba(255,255,255,0.5)',
            },
            ticks : {
                color: '#fff'
            }

        },
        x: {
            grid : {
                borderColor : 'rgb(243,243,242)',
                color: 'rgba(255,255,255,0.5)',
            },
            ticks : {
                color: '#fff'
            },
            title: {
                color: 'white',
                display: true,
                text: 'Month',
                font: {
                    size: 14
                }
            }
        },
    }
}