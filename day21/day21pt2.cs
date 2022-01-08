var l = In.ReadToEnd().Split("\n");
var a = l[0][^1] - 48;
var b = l[1][^1] - 48;

var p = "123".SelectMany(x => "123".SelectMany(y => "123".Select(u => new[]{x,y,u}))).Select(x => x.Sum(y => y-48)).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
var D = new Dictionary<(int,int,int,int,bool), (long,long)>();
(long p1, long p2) P(int a, int b, int sa, int sb, bool t) {
	if(D.TryGetValue((a,b,sa,sb,t), out var s))return s;
	if(sa >= 21)return (1,0);
	if(sb >= 21)return (0,1);
	long p1 = 0, p2 = 0;
	int aa = a, bb = b, saa = sa, sbb = sb;
	for(int i = 3; i <= 9; i++) {
		if(t){aa = (a+i-1)%10+1;saa = sa + aa;}
		else {bb = (b+i-1)%10+1;sbb = sb + bb;}
		var (q, w) = P(aa, bb, saa, sbb, !t);
		p1 += q * p[i];
		p2 += w * p[i];
	}
	D.Add((a,b,sa,sb,t), (p1,p2));
	return (p1,p2);
}
Print(P(a,b,0,0,true));