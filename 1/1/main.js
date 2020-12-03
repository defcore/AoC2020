var array = require('fs').readFileSync('../input.txt').toString().split("\n").map(Number);

for (i in array)
    for (j = i; j < array.length; j++)
        if (array[i] + array[j] == 2020) {
            console.log(array[i] * array[j]);
            process.exit(1);
        }