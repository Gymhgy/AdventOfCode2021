var l = In.ReadToEnd().Split("\n");
var s = Convert.ToInt32(string.Concat(Enumerable.Range(0, l[0].Count()).Select(x => l.Select(o=>int.Parse(o[x]+"")).Sum() < l.Count()/2 ? 0 : 1)), 2);
Print(s * (~s & (1 << 12)-1));