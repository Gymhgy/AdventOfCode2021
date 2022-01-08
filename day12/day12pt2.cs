https://tio.run/##XVHNbtswDD5XT8H10EqobaRn1wGGbEUCZFjQ9DIEPsiWHGvzpMBSXBtFnz0jHQdbdqFEfj@kqNLHpTenUydbaCCDlU1etFSv7qtVXCTbQ2MCnbrRZeA9ZHPop@p9fC9EykhZorKZSN@kHXifzXuRfDE@GFuSwatbY8InvkN@mSzc0YaUEfBkbJjvcpDqJ0JWv8HfqstTVrmWYwImm6XmyaXm4UEgd2fy7IpMDZCrZVlzaqTAWGgEvAO7IX0/Nl5ZpfvvFVe7WS4iGP4rPubockP2fZ58VooPl3w45z3mH4yRob/S3vog23CLMGH6GtNWXZDN@BgVwVL6eqvPs3cRFM41UOC4zFS8wwXZII31XAnxjpXi7k59yrwosko2XqcaA7Q6HFsLs/SDRGUt22Tl1@5Nt7zcqZyeSIbdOLkaJ0eegiwDLS7qx5RNN3qmypPt8ff5tze8j6DD/5tG5biwQpwXsGlxbr7hPhq/7N/HEC20R43M0@mwjxdLhnFQbFDxuCRW6bjuWGEIWiwJwgXFhSHg5QezowbvGPF@2LO6i5/X7HkdV5ruWEExWqAYlVSye7LHiK2QNPahlIxRimZojwa/PDFG@A8
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
int P(int d, HashSet<int>v, bool b) {
if(v.Contains(d)){if(b&&d!=s)b=false;else return 0;}
if(char.IsLower(c[d][0])) {
v.Add(d);
}
if(d == e) return 1;
return adj[d].Sum(x => P(x, v.ToHashSet(), b));
}

Print(P(s, new HashSet<int>(), true));