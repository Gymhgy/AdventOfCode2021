var l = In.ReadToEnd().Split().Select(x => x.Split('-'));
var c = l.SelectMany(x=>x).Distinct().ToList();
var o = c.Count;
List<int>[] adj = new List<int>[o];
for(int i=0;i<o;i++)adj[i]=new List<int>();
foreach(var d in l) { 
	int x = c.IndexOf(d[0]), y = c.IndexOf(d[1]);
	adj[x].Add(y);
	adj[y].Add(x);
}

int s = c.IndexOf("start");
int e = c.IndexOf("end");
int P(int d, HashSet<int>v) {
if(v.Contains(d))return 0;
if(char.IsLower(c[d][0])) {
v.Add(d);
}
if(d == e) return 1;
return adj[d].Sum(x => P(x, v.ToHashSet()));
}

Print(P(s, new HashSet<int>()));