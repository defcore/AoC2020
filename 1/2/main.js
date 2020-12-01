const { exit } = require('process');

var array = require('fs').readFileSync('../input.txt').toString().split("\n").map(Number);

for (i in array)
    for (j = i; j < array.length; j++)
        for (k = j; k < array.length; k++)
            if (array[i] + array[j] + array[k] == 2020) {
                console.log(array[i] + ' ' + array[j] + ' ' + array[k])
                console.log(array[i] * array[j] * array[k]);
                process.exit(1);
            }