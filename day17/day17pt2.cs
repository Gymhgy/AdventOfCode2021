var l = In.ReadToEnd().Replace("target area: x=","").Replace(", y=", "..").Split("..").Select(x=>int.Parse(x)).ToList();
//xmin,xmax,ymin,ymax
int q = l[0],w=l[1],e=l[2],r=l[3];
int d = 0;
for(int x = 0; x <= w; x++)
	for(int y = e; y <= -e-1; y++) {
		int o=0,p=0,a=x,s=y;
		for(;;) {
			o+=a; p+=s; a=Math.Max(a-1, 0); s--;
			if(o >= q && o <= w && p >= e && p <= r){d++;break;}
			if(o > w || p < e)break;
		}
	}

Print(d);