var l = In.ReadToEnd().Split().Select(x => {
	var b = 0;
	List<(int v,int p)>s = new List<(int v,int p)>();
	foreach(var c in x){
		if(c=='[')b++;
		if(c==']')b--;
		if(char.IsDigit(c))s.Add((v:c-48,p:b));
	}
	return s;
}).ToList();
var j = l.SelectMany((x,i) => l.Where((_, y) => y!=i).Select(y => new[]{x,y})).Max(a => {

	var c = a[0].Concat(a[1]).Select(x => (v:x.Item1, p:x.Item2 + 1)).ToList();
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

	for(int i = c.Max(x => x.p); i > 0; i--) {
		try{
			while(true){
				var d = Enumerable.Range(0,c.Count-1).First(x => c[x].p == i && c[x+1].p == i);
				c[d] = (c[d].v*3 + c[d+1].v*2, c[d].p-1);
				c.RemoveAt(d+1);
			}
		}
		catch{
			continue;
		}
	}
	return c[0].v;
});


Print(j);