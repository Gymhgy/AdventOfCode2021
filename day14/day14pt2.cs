var l = In.ReadToEnd().Split("\n\n");
var t = l[0];
var p = l[1].Split("\n").Select(x => x.Split(" -> ")).ToDictionary(x => x[0], x => (x[0][0]+x[1],x[1]+x[0][1]));
Dictionary<string, long> c = new Dictionary<string, long>();
var a = t.Zip(t.Skip(1), (a,b) => a + "" + b).ToList();
a.ForEach(x => { if(c.ContainsKey(x))c[x]++; else c[x] = 1; });

for(int i = 0; i < 40; i++){
	Dictionary<string, long> n = new Dictionary<string, long>();
	foreach(var(k,v)in c){
		if(n.ContainsKey(p[k].Item1))
			n[p[k].Item1] += v;
		else n[p[k].Item1] = v;
		if(n.ContainsKey(p[k].Item2))
			n[p[k].Item2] += v;
		else n[p[k].Item2] = v;	
	}
	c = n;
}

long[] o = new long[26];
foreach(var(k,v)in c){
	o[k[0]-65] += v;
}
o[t.Last()-65] += 1;
o = o.Where(z => z != 0).ToArray();
Print(o.Max() - o.Min());