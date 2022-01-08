var l = In.ReadToEnd().Split().Select(x => {
	var b = 0;
	List<(int v,int p)>s = new List<(int v,int p)>();
	foreach(var c in x){
		if(c=='[')b++;
		if(c==']')b--;
		if(char.IsDigit(c))s.Add((v:c-48,p:b));
	}
	return s;
}).Aggregate((a,b) => {
	var c = a.Concat(b).Select(x => (v:x.Item1, p:x.Item2 + 1)).ToList();
	while(true){
		try {
			var i = Enumerable.Range(0,c.Count-1).First(x => c[x].p == 5 && c[x+1].p == 5);
			if(i!=0)c[i-1] = (c[i-1].v+c[i].v, c[i-1].p);
			if(i+2<c.Count)c[i+2] = (c[i+2].v+c[i+1].v, c[i+2].p);
			c[i] = (0, 4);
			c.RemoveAt(i+1);
			continue;
		}
		catch(InvalidOperationException) {
			try {
				var i = Enumerable.Range(0, c.Count).First(x => c[x].v >= 10);
				c.Insert(i+1, ((int)Math.Ceiling(c[i].v/2.0),c[i].p+1));

				c[i] = (c[i].v/2, c[i].p+1);
			} catch{break;}
		}
	}
	return c;
});

for(int i = l.Max(x => x.p); i > 0; i--) {
	try{
		while(true){
			var d = Enumerable.Range(0,l.Count-1).First(x => l[x].p == i && l[x+1].p == i);
			l[d] = (l[d].v*3 + l[d+1].v*2, l[d].p-1);
			l.RemoveAt(d+1);
		}
	}
	catch{
		continue;
	}
}
Print(l[0].v);