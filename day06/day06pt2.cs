var l = In.ReadToEnd().Split(",").Select(int.Parse).GroupBy(x => x);
ulong k = 0;
var di = new Dictionary<int, ulong >();
int a = 256;
ulong B(int d){
	if(d > a-9) return 0;
	if(di.ContainsKey(d)) return di[d];
	ulong s = 0;
	for(int i = d+9; i <= a; i += 7) {
		s+=B(i)+1;
	}
	di.Add(d, s);
	return s;
}
foreach(var g in l) {
	var t = g.Key;
	ulong z = 1;
	for(int i = t + 1; i <= a; i+=7) {
		z += B(i) + 1;
	}
	k += (uint)g.Count() * z;
}
Print(k);
