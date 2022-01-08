//input filtered w/ part 1
var l = In.ReadToEnd().Split("\n");
int p = 0;

long P(string a) {
	int i = 0;
	string e = "";
	void D() {
		if("({[<".IndexOf(a[i]) is var d && d > -1) {
			i++;
			while(i < a.Length) {
				if(a[i] == ")}]>"[d]) {i++;return;}
				D();
			}
			e += ")}]>"[d];
		}
		
	}
	while(i<a.Length)
		D();
	return e.Aggregate(0l, (a,b) => a * 5 + " )]}>".IndexOf(b));
}
List<long> f=new List<long>();
foreach(var s in l) {
	f.Add(P(s));
}
f = f.OrderBy(x=>x).ToList();
Print(f[f.Count/2]);