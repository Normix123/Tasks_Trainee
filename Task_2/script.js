// Installation of the Keccak family of cryptographic hashing algorithms (https://www.npmjs.com/package/sha3):
// $ npm install sha3

const { SHA3 } = require("sha3")
const fs = require('fs');
var path = require('path');

const folder = process.cwd();

fs.readdir(folder, (err, files) => {
    files.forEach(file => {
        try {
            console.log(file, new SHA3(256)
            .update(fs.readFileSync(path
                .join(folder, file), 'utf8'))
                .digest('hex'))
        }
        catch (err) { }
    });
});
