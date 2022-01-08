var l = In.ReadToEnd().Split("\n").Select(x => x.Split(" | "));
var a = l.Select(x => x[0].Split(" ")).ToList();
var b = l.Select(x => x[1].Split(" ")).ToList();
int sum = 0;
foreach(var (s,q) in a.Zip(b, (o,p) => (o,p))) {
	HashSet<char>[] p = new HashSet<char>[10];
	for(int i=0;i<p.Length;i++)p[i]=new HashSet<char>();

	var d = s.Select(x => x.ToHashSet()).ToList();

	p[1] = d.Single(x => x.Count == 2);
	p[4] = d.Single(x => x.Count == 4);
	p[7] = d.Single(x => x.Count == 3);
	p[8] = d.Single(x => x.Count == 7);

	p[9] = d.Single(x => x.Count == 6 && x.IsSupersetOf(p[4]));
	p[3] = d.Single(x => x.Count == 5 && x.IsSupersetOf(p[1]));
	p[0] = d.Single(x => x.Count == 6 && x.Intersect(p[7]).Count() == 3 && !x.SetEquals(p[9]));
	p[6] = d.Single(x => x.Count == 6 && !x.SetEquals(p[9]) && !x.SetEquals(p[0]));
	p[5] = d.Single(x => x.Count == 5 && x.Intersect(p[6]).Count() == 5);
	p[2] = d.Single(x => x.Count == 5 && !x.SetEquals(p[5]) && !x.SetEquals(p[3]));
	sum += int.Parse(string.Concat(q.Select(x => Enumerable.Range(0,10).Single(y => p[y].SetEquals(x.ToHashSet())))));
}
Print(sum);