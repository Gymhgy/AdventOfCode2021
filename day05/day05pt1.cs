var l = In.ReadToEnd().Split("\n").Select(x => x.Split(" -> ").Select(t=>t.Split(",").Select(int.Parse).ToArray()).ToArray()).ToArray();
int h = l.Max(p => p.Max(o => o[1])) + 1;
int w = l.Max(p => p.Max(o => o[0])) + 1;
byte[][] b = new byte[w][];
for (int i = 0; i < w; i++) b[i] = new byte[h];
foreach(var s in l) {
	var t = s[0];
	var e = s[1];

	if(t[0] != e[0] && t[1] != e[1]) continue;
	if(t[0] > e[0]) (t[0],e[0])=(e[0],t[0]);
	if(t[1] > e[1]) (t[1],e[1])=(e[1],t[1]);
	for(int i = t[0]; i <= e[0]; i++) {
		for(int j = t[1]; j <= e[1]; j++) {
			b[i][j]++;
		}

	}
}
Print(b.Sum(x => x.Count(y => y > 1)));