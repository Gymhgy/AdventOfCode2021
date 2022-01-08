var l = In.ReadToEnd().Split("\n").Select(x => x.Select(y => y-48).ToArray()).ToArray();

//Dijkstra!
bool[,]v = new bool[l.Length, l[0].Length];
int[,]t = new int[l.Length, l[0].Length];
for(int i = 0; i < l.Length; i++)
	for(int j = 0; j < l[0].Length; j++)
		t[i,j] = int.MaxValue;

t[0,0] = 0;
v[0,0] = true;
int x=0,y=0;

while(x != l.Length - 1 || y != l[0].Length - 1) {
	if(x != 0 && !v[x-1,y])t[x-1,y] = Math.Min(t[x,y]+l[x-1][y],t[x-1,y]);
	if(y != 0 && !v[x,y-1])t[x,y-1] = Math.Min(t[x,y]+l[x][y-1],t[x,y-1]);
	if(x < l.Length-1 && !v[x+1,y])t[x+1,y] = Math.Min(t[x,y]+l[x+1][y],t[x+1,y]);
	if(y < l[0].Length-1 && !v[x,y+1])t[x,y+1] = Math.Min(t[x,y]+l[x][y+1],t[x,y+1]);
	v[x, y] = true;

	int m = int.MaxValue;
	for(int i=0;i<l.Length;i++)
		for(int j=0;j<l[0].Length;j++) {
			if(!v[i,j] && t[i,j] < m) {
				m = t[i,j];
				x = i; y = j;
			}
		}
}

Print(t[x,y]);