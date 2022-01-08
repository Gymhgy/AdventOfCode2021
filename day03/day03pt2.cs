var l = In.ReadToEnd().Split("\n");
string[] c = l.ToArray(), d = l.ToArray();
for(int i = 0; i < l[0].Length && c.Length > 1; i++) {
	var j = c.Select(x => x[i]-48).Sum() < c.Length/2d ? 0 : 1;
	c = c.Where(x => x[i]-48 == j).ToArray();
}
for(int i = 0; i < l[0].Length && d.Length > 1; i++) {
	var j = d.Select(x => x[i]-48).Sum() < d.Length/2d ? 1 : 0;
	d = d.Where(x => x[i]-48 == j).ToArray();
}
Print(Convert.ToInt32(c[0], 2) * Convert.ToInt32(d[0], 2));