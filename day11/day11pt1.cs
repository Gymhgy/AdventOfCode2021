var l = In.ReadToEnd().Split().Select(x => x.Select(y=>y-48).ToArray()).ToArray();
int f = 0;

HashSet<(int x,int y)> r = new HashSet<(int x,int y)>();
int F(int x, int y) {
	if(r.Contains((x,y))) return 0;
	if(x == l.Length || x<0) return 0;
	if(y == l[0].Length || y<0) return 0;
	l[x][y]++;
	if(l[x][y] > 9) {
		r.Add((x,y));
		l[x][y] = 0;
		return F(x-1,y-1) + F(x-1, y) + F(x-1, y+1) + F(x, y-1) + F(x, y+1) + F(x+1, y-1) + F(x+1, y) + F(x+1, y+1) + 1;
	}

	return 0;
}

for(int a = 0; a < 100; a++) {
	r.Clear();
	for(int i = 0; i < l.Length; i++)
		for(int j = 0; j < l.Length; j++)
			l[i][j]++;

	for(int i = 0; i < l.Length; i++)
		for(int j = 0; j < l.Length; j++)
			if(l[i][j] > 9) f += F(i,j);

}

Print(f);