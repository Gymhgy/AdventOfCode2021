var l = In.ReadToEnd().Split("\n\n");
var t = l[0];
var p = l[1].Split("\n").Select(x => x.Split(" -> ")).ToList();

for(int i = 0; i < 10; i++) {
t = string.Concat(t.Zip(t.Skip(1), (a,b) => p.Any(x => x[0] == a+""+b) ? a + p.Single(x => x[0] == a+""+b)[1] : a+"")) + t.Last();
}
var g = t.GroupBy(x => x).OrderBy(x => x.Count());

Print(g.Last().Count() - g.First().Count());