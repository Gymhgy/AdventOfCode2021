var l = In.ReadToEnd().Split("\n").Select(x => x.Select(y => y - 48).ToArray()).ToArray();
int sum = 0;
HashSet<(int x,int y)> r = new HashSet<(int x,int y)>();
int F(int x, int y, int o, int p, bool q=false) {
	if(r.Contains((x,y))) return 0;
	if(x == l.Length || x<0) return 0;
	if(y == l[0].Length || y<0) return 0;
	if(l[x][y] == 9) return 0;
	if(q||l[x][y] > l[o][p]) {
		r.Add((x,y));
		return 1 + F(x+1, y,x,y) + F(x, y+1,x,y) + F(x-1, y,x,y) + F(x, y-1,x,y);
	}
	return 0;
}
List<int> b = new List<int>();
for(int i = 0; i < l.Length; i++) {
	for(int j = 0; j < l[0].Length; j++) {
		bool s = true;
		var v = l[i][j];
		try {
			if(v >= l[i-1][j])s=false;
		} catch{}
		try {
			if(v >= l[i][j-1])s=false;
		} catch{}
		try {
			if(v >= l[i+1][j])s=false;
		} catch{}
		try {
			if(v >= l[i][j+1])s=false;
		} catch{}
		if(s){
			r.Clear();
			b.Add(F(i,j,0,0,true));
		}
	}
}
Print(b.OrderByDescending(x=>x).Take(3).Aggregate(1, (a,b) => a*b));