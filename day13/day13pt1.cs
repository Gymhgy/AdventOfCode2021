var l = In.ReadToEnd().Split("\n\n");
var p = l[0].Split("\n").Select(x => x.Split(',')).Select(x => (int.Parse(x[0]),int.Parse(x[1]))).ToList();

var f = l[1].Split("\n").Take(1).Select(x => x.Split()[2]).Select(x => (x[0],int.Parse(x.Substring(2))));
foreach(var (m,c) in f) {
	p = p.Select(s => {
		var (x,y) = s;
		if(m=='x'&&x>c)return (c-(x-c),y);
		if(m=='y'&&y>c)return (x,c-(y-c));
		return (x,y);
	}).Distinct().ToList();
}
Print(p.Count);