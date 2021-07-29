args = process.argv;
if (args.length === 2) return console.log('');
if (args.length === 3) return console.log(process.argv[2]);
args.shift(); args.shift();
const n = args.length;
let s = args[0];
let len = s.length;
let res = "";
for (let i = 0; i < len; i++) {
	for (let j = i + 1; j <= len; j++) {
		let steam = s.substring(i, j - i);
		let k = 1;
		for (k = 1; k < n; k++)
			if (!args[k].includes(steam))
				break;
		if (k == n && res.length < steam.length)
			res = steam
	}
}
console.log(res);

