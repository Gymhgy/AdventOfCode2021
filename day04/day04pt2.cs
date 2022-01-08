var l = In.ReadToEnd().Split("\n");
var o = l[0].Split(",").Select(int.Parse).ToList();

var s = new List<List<List<int>>>();
for(int i = 2; i < l.Length; i += 6) {
	s.Add(l.Skip(i).Take(5).Select(x => x.Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()).ToList());
}
for(int i = 0; i < o.Count; i++) {
	for(int j = 0; j < s.Count; j++)
		for(int k = 0; k < 5; k++)
			for(int m = 0; m < 5; m++) {
				if(s[j][k][m]==o[i])s[j][k][m]=-1;
			}

	var p = s.Where(x => x.Any(y=>y.All(u=>u==-1)) || Enumerable.Range(0,5).Any(y => Enumerable.Range(0,5).All(u => x[u][y] == -1)));
	if(p.Any()) {
		if(s.Count == 1) {
			Print(p.First().Select(x => x.Sum(y => y==-1 ? 0 : y)).Sum() * o[i]);
			break;
		}
		p.ToList().ForEach(x => s.Remove(x));
	}
}